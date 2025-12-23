using MultiArmedBandit.Properties;
using MultiArmedBandit.Structs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormModeling : Form
    {
        private IEnumerable<double> _deviations;
        private Player _player;

        public FormModeling(Color backColor)
        {
            InitializeComponent();

            _dataGridView.BackgroundColor = backColor;
            _deviations = NumbersFactory.CreateDoubleCollection(0d, 0.3d, 51, 1);
            _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);

            CreateTable();
            OnBanditsCountChanged(_numBanditsCount, EventArgs.Empty);

            EnumFactory.SetComboBoxValues<Strategy>(_cmbStrategy);
            EnumFactory.SetComboBoxValues<ConjugateDistribution>(_cmbConjugateDistribution);
            EnumFactory.SetComboBoxValues<BatchSizeChangeRule>(_cmbBatchSizeChangeRule);

            _btnPause.Enabled = _btnCancel.Enabled = _btnSave.Enabled = false;

            foreach (Control ctrl in _grpSimulationSettings.Controls)
                if (ctrl is ComboBox box)
                    box.SelectedIndex = 0;

            _dataGridView.CellValueChanged += OnDataGridViewCellValueChanged;
        }

        public bool IsSimulationFinished { get; private set; } = true;
        public bool IsDataSaved { get; private set; } = true;

        public event Action<IEnumerable<Regret[]>> ResultChanged;
        public event Action ClearChart;

        private void SetButtonsSimulationsEnabled(bool enabled)
        {
            _btnNew.Enabled = enabled;
            _btnOpen.Enabled = enabled;

            _btnPause.Enabled = enabled == false;
            _btnCancel.Enabled = enabled == false;
            _progressBar.Visible = enabled == false;
        }

        private void SetControlsEnabled(bool enabled)
        {
            _grpSimulationSettings.Enabled = enabled;
            _dataGridView.ClearSelection();

            foreach (DataGridViewColumn column in _dataGridView.Columns)
                column.ReadOnly = enabled == false || CollectionsData.Data[(CollectionNames)column.Tag].ReadOnly;
        }

        private void CreateTable()
        {
            var columnsNames = EnumFactory.GetEnumValuesSkip(CollectionNames.Deviation).ToArray();
            var fontTable = new Font("", 14);
            var i = 0;

            _dataGridView.Columns.Clear();
            _dataGridView.ColumnCount = columnsNames.Length;

            foreach (var name in columnsNames)
            {
                _dataGridView.Columns[i].Tag = name;
                _dataGridView.Columns[i].Name = name.ToString();
                _dataGridView.Columns[i].HeaderText = CollectionsData.Data[name].Title;
                _dataGridView.Columns[i].ReadOnly = CollectionsData.Data[name].ReadOnly;
                _dataGridView.Columns[i].ValueType = typeof(double);
                _dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                _dataGridView.Columns[i].HeaderCell.Style.Font = fontTable;
                _dataGridView.Columns[i].DefaultCellStyle.Font = fontTable;
                _dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dataGridView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                _dataGridView.Columns[i].DefaultCellStyle.Format = $"f{CollectionsData.Data[name].DecimalPlaces}";

                if (name != CollectionNames.NumberRow)
                    _dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                i++;
            }

            _dataGridView.Columns[(int)CollectionNames.NumberRow].Width = 40;
        }

        private void UpdateProgressBar(int percent)
        {
            _progressBar.Value = percent;
        }

        private void EndGame(bool isCorrect, string result)
        {
            _timer.Stop();
            _progressBar.Value = _progressBar.Minimum;
            _btnSave.Enabled = isCorrect;
            _btnStart.Enabled = IsDataSaved = isCorrect == false;

            _player.ProgressChanged -= UpdateProgressBar;
            _lblDialog.Text = result;

            SetControlsEnabled(isCorrect == false);
            SetButtonsSimulationsEnabled(IsSimulationFinished = true);

            if (isCorrect)
            {
                ResultChanged?.Invoke(_player.Regrets);
                OnCheckBoxPlaySoundCheckedChanged(_chkSoundPlay, EventArgs.Empty);
            }
        }

        private void ClearPlayer()
        {
            if (_player != null)
            {
                _player.ProgressChanged -= UpdateProgressBar;
                _player.GameOver -= EndGame;
                _player.Clear();
                _player = null;
            }
        }

        private int[] GetColumnInt(CollectionNames collectionName)
        {
            var nameColumn = collectionName.ToString();
            var column = new int[_dataGridView.RowCount];

            for (int i = 0; i < _dataGridView.RowCount; i++)
                column[i] = Convert.ToInt32(_dataGridView.Rows[i].Cells[nameColumn].Value);

            return column;
        }

        private double[] GetColumnDouble(CollectionNames collectionName)
        {
            var nameColumn = collectionName.ToString();
            var column = new double[_dataGridView.RowCount];

            for (int i = 0; i < _dataGridView.RowCount; i++)
                column[i] = Convert.ToDouble(_dataGridView.Rows[i].Cells[nameColumn].Value);

            return column;
        }

        private void SetColumn<T>(CollectionNames collectionName, IEnumerable<T> values, int startRowIndex = 0)
        {
            SetColumn(collectionName.ToString(), values, startRowIndex);
        }

        private void SetColumn<T>(string nameColumn, IEnumerable<T> values, int startRowIndex = 0)
        {
            var enumerator = values.GetEnumerator();
            var index = startRowIndex;

            while (enumerator.MoveNext() && index < _dataGridView.RowCount)
                _dataGridView.Rows[index++].Cells[nameColumn].Value = enumerator.Current;
        }

        private void ChangeHorizon(int rowIndex)
        {
            var row = _dataGridView.Rows[rowIndex];
            var rule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex;
            var batchesCount = Convert.ToInt32(row.Cells[CollectionNames.BatchesCount.ToString()].Value);
            var startBatchSize = Convert.ToInt32(row.Cells[CollectionNames.StartBatchSize.ToString()].Value);
            var growthRateBatchSize = Convert.ToDouble(row.Cells[CollectionNames.GrowthRateBatchSize.ToString()].Value);
            var timeChangeBatch = Convert.ToInt32(row.Cells[CollectionNames.TimeChangeBatch.ToString()].Value);

            row.Cells[CollectionNames.Horizon.ToString()].Value = HorizonBuilder.GetHorizon(rule, batchesCount, startBatchSize, growthRateBatchSize, timeChangeBatch);
        }

        private GeneralBanditsData CopyFormValues()
        {
            return new GeneralBanditsData
            {
                BatchSizeChangeRule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex,
                Strategy = (Strategy)_cmbStrategy.SelectedIndex,
                ConjugateDistribution = (ConjugateDistribution)_cmbConjugateDistribution.SelectedIndex,
                GamesCount = (int)_numGamesCount.Value,
                ThreadsMaxCount = (int)_numThreadsCount.Value,
                CentralExpectation = (double)_numCentralExpectation.Value,
                MaxVariance = (double)_numMaxVariance.Value,
                Deviations = _deviations.ToArray()
            };
        }

        private IEnumerable<Bandit> CreateBandits()
        {
            var countBandits = (int)_numBanditsCount.Value;
            var centralExpectation = (double)_numCentralExpectation.Value;
            var maxVariance = (double)_numMaxVariance.Value;

            var rule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex;
            var strategy = (Strategy)_cmbStrategy.SelectedIndex;
            var conjugateDistribution = (ConjugateDistribution)_cmbConjugateDistribution.SelectedIndex;

            var countArms = GetColumnInt(CollectionNames.ArmsCount);
            var batchesCount = GetColumnInt(CollectionNames.BatchesCount);
            var startBatchSize = GetColumnInt(CollectionNames.StartBatchSize);
            var growthRateBatchSize = GetColumnDouble(CollectionNames.GrowthRateBatchSize);
            var timeChangeBatch = GetColumnInt(CollectionNames.TimeChangeBatch);
            var parameterUCB = GetColumnDouble(CollectionNames.ParameterUCB);

            if (strategy == Strategy.UCB)
                for (int i = 0; i < countBandits; i++)
                    yield return new BanditUCB(centralExpectation, maxVariance, countArms[i], rule, batchesCount[i], startBatchSize[i], growthRateBatchSize[i], timeChangeBatch[i], parameterUCB[i]);
            else
                for (int i = 0; i < countBandits; i++)
                    yield return new BanditThompsonSampling(centralExpectation, maxVariance, countArms[i], rule, batchesCount[i], startBatchSize[i], growthRateBatchSize[i], timeChangeBatch[i], conjugateDistribution);
        }

        private void OnNewClick(object sender, EventArgs e)
        {
            if (IsDataSaved == false && DialogResult.No == MessageBox.Show($"Несохранённые данные будут удалены.\nПродолжить?", "Данные не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            ClearChart?.Invoke();
            ClearPlayer();

            _lblDialog.Text = string.Empty;
            _btnSave.Enabled = false;

            SetControlsEnabled(IsDataSaved = _btnStart.Enabled = true);
        }

        [Obsolete]
        private void OnStartClick(object sender, EventArgs e)
        {
            ClearPlayer();
            SetControlsEnabled(false);
            SetButtonsSimulationsEnabled(false);

            IsSimulationFinished = IsDataSaved = false;
            _btnStart.Enabled = _btnSave.Enabled = false;

            var data = CopyFormValues();
            var bandits = CreateBandits().ToArray();
            var gamesCount = (int)_numGamesCount.Value;
            var threadsCount = (int)_numThreadsCount.Value;

            _player = new Player(data, bandits);
            _player.ProgressChanged += UpdateProgressBar;
            _player.GameOver += EndGame;

            _player.Play(_deviations, gamesCount, threadsCount);
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _lblDialog.Text = _player?.GameInformation;
        }

        [Obsolete]
        private void OnCancelClick(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Вы действительно хотите отменить вычисления?", "Отмена операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            else if (_player.IsPaused)
                OnPauseClick(_btnPause, EventArgs.Empty);

            _player.CancelGame();
        }

        [Obsolete]
        private void OnPauseClick(object sender, EventArgs e)
        {
            if (_player.IsPaused)
            {
                _btnPause.Text = "Пауза";
                _timer.Start();
                ModifyProgressBarColor.SetState(_progressBar, 1);
            }
            else
            {
                _btnPause.Text = "Продолжить";
                _timer.Stop();
                ModifyProgressBarColor.SetState(_progressBar, 2);
            }

            _player.ChangePause();
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            if (IsDataSaved == false && DialogResult.No == MessageBox.Show($"Несохранённые данные будут удалены.\nПродолжить?", "Данные не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            else if (FileReader.TryOpen(out Player player))
            {
                ClearPlayer();

                var generalBanditsData = player.GeneralBanditsData;
                var dataTable = player.GetDataGridViewValues();

                _player = player;
                _deviations = generalBanditsData.Deviations;
                _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);

                _dataGridView.CellValueChanged -= OnDataGridViewCellValueChanged;
                _cmbBatchSizeChangeRule.SelectedIndexChanged -= OnBatchSizeChangeRuleChanged;

                _numBanditsCount.Value = player.BanditsCount;
                _numGamesCount.Value = generalBanditsData.GamesCount;
                _numThreadsCount.Value = generalBanditsData.ThreadsMaxCount;

                _numCentralExpectation.Value = (decimal)generalBanditsData.CentralExpectation;
                _numMaxVariance.Value = (decimal)generalBanditsData.MaxVariance;

                _cmbStrategy.SelectedIndex = (int)generalBanditsData.Strategy;
                _cmbBatchSizeChangeRule.SelectedIndex = (int)generalBanditsData.BatchSizeChangeRule;
                _cmbConjugateDistribution.SelectedIndex = (int)generalBanditsData.ConjugateDistribution;

                foreach (var data in dataTable)
                    SetColumn(data.Key, data.Value);

                OnBatchSizeChangeRuleChanged(_cmbBatchSizeChangeRule, EventArgs.Empty);

                _dataGridView.CellValueChanged += OnDataGridViewCellValueChanged;
                _cmbBatchSizeChangeRule.SelectedIndexChanged += OnBatchSizeChangeRuleChanged;

                _lblDialog.Text = generalBanditsData.GameResult;
                _btnSave.Enabled = IsDataSaved = true;

                ResultChanged?.Invoke(_player.Regrets);
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var form = new FormDataSave();
            form.SaveDataSelected += OnSaveDataSelected;
            form.ShowDialog();
        }

        private void OnDeviationsSettingsClick(object sender, EventArgs e)
        {
            var collectionName = CollectionNames.Deviation.ToString();
            var title = "Отклонения d от мат. ожидания m";
            var start = _deviations.First();
            var count = _deviations.Count();
            var step = count > 1 ? (_deviations.Last() - start) / (count - 1) : Player.DefaultDeviationsStep;
            var form = new FormCollectionSettings(collectionName, title, start, step, count, Player.MinDeviation, Player.MaxDeviation, 1, false);

            form.FormClosing += OnFormCollectionSettingsClosing;
            form.ShowDialog();
        }

        private void OnBatchSizeChangeRuleChanged(object sender, EventArgs e)
        {
            var rule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex;
            var indexHorizon = (int)CollectionNames.Horizon;
            var batchesCount = GetColumnInt(CollectionNames.BatchesCount);
            var startBatchSize = GetColumnInt(CollectionNames.StartBatchSize);
            var timeChangeBatch = GetColumnInt(CollectionNames.TimeChangeBatch);
            var growthRateBatchSize = GetColumnDouble(CollectionNames.GrowthRateBatchSize);

            for (int i = 0; i < _dataGridView.RowCount; i++)
                _dataGridView.Rows[i].Cells[indexHorizon].Value = HorizonBuilder.GetHorizon(rule, batchesCount[i], startBatchSize[i], growthRateBatchSize[i], timeChangeBatch[i]);
        }

        private void OnBanditsCountChanged(object sender, EventArgs e)
        {
            int rowDifference = (int)_numBanditsCount.Value - _dataGridView.RowCount;

            if (rowDifference > 0)
            {
                var numberRow = _dataGridView.RowCount + 1;

                for (int i = 0; i < rowDifference; i++)
                {
                    _dataGridView.Rows.Add(
                        numberRow,
                        CollectionsData.Data[CollectionNames.ArmsCount].DefaultValue,
                        CollectionsData.Data[CollectionNames.BatchesCount].DefaultValue,
                        CollectionsData.Data[CollectionNames.StartBatchSize].DefaultValue,
                        CollectionsData.Data[CollectionNames.GrowthRateBatchSize].DefaultValue,
                        CollectionsData.Data[CollectionNames.TimeChangeBatch].DefaultValue,
                        CollectionsData.Data[CollectionNames.Horizon].DefaultValue,
                        CollectionsData.Data[CollectionNames.ParameterUCB].DefaultValue);

                    ChangeHorizon(numberRow++ - 1);
                }
            }
            else
            {
                _dataGridView.RowCount = (int)_numBanditsCount.Value;
            }
        }

        private void OnCheckBoxPlaySoundCheckedChanged(object sender, EventArgs e)
        {
            if (_chkSoundPlay.Checked)
                Sound.Play(Resources.Sound_Done);
        }

        private void OnComboBoxStrategySelectedIndexChanged(object sender, EventArgs e)
        {
            _cmbConjugateDistribution.Enabled = _cmbStrategy.SelectedIndex == (int)Strategy.ThompsonSampling;
        }

        private void OnButtonEnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn)
                btn.BackColor = btn.Enabled ? Color.White : Color.Gray;
        }

        private void OnFormCollectionSettingsClosing(object sender, FormClosingEventArgs e)
        {
            if (sender is FormCollectionSettings form && form.IsCollectionChanged)
            {
                if (form.CollectionName == CollectionNames.Deviation.ToString())
                {
                    _deviations = form.GetCollection();
                    _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);
                }
                else
                {
                    SetColumn(form.CollectionName, form.GetCollection());
                }

                form.FormClosing -= OnFormCollectionSettingsClosing;
            }
        }

        private void OnSaveDataSelected(Form sender, SavingData data)
        {
            if (sender is FormDataSave form)
            {
                if (data == SavingData.All)
                {
                    _player.SaveGameResult(out bool isSaved);
                    IsDataSaved = isSaved;
                }
                else
                {
                    FileWriter.Save(_player.GetStringRegretTable());
                }

                form.SaveDataSelected -= OnSaveDataSelected;
                form.Close();
            }
        }

        private void OnDataGridViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                var selectedColumnIndex = _dataGridView.SelectedCells[0].ColumnIndex;
                var clipboardText = Clipboard.GetText();

                if (_dataGridView.Columns[selectedColumnIndex].ReadOnly || string.IsNullOrEmpty(clipboardText))
                    return;

                var columnName = _dataGridView.Columns[selectedColumnIndex].Name;
                var rowIndex = _dataGridView.CurrentCell.RowIndex;
                var rows = clipboardText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var column = rows.Select(row => row.Split('\t')[0]);
                var values = CollectionHandler.ConvertToDoubles(column);

                SetColumn(columnName, values, rowIndex);
            }
        }

        private void OnDataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex].ReadOnly == false)
            {
                var nameColumn = (CollectionNames)e.ColumnIndex;
                var title = _dataGridView.Columns[e.ColumnIndex].HeaderText;
                var decimalPlaces = CollectionsData.Data[nameColumn].DecimalPlaces;

                var start = CollectionsData.Data[nameColumn].DefaultValue;
                var step = 0d;
                var count = _dataGridView.RowCount;

                var minStart = CollectionsData.Data[nameColumn].Minimum;
                var maxStart = int.MaxValue;

                var form = new FormCollectionSettings(nameColumn.ToString(), title, start, step, count, minStart, maxStart, decimalPlaces, true);

                form.FormClosing += OnFormCollectionSettingsClosing;
                form.ShowDialog();
            }
        }

        private void OnDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var name = (CollectionNames)e.ColumnIndex;
                var minValue = CollectionsData.Data[name].Minimum;
                var input = _dataGridView[e.ColumnIndex, e.RowIndex].Value;

                if (input.ToString() == string.Empty)
                {
                    _dataGridView[e.ColumnIndex, e.RowIndex].Value = CollectionsData.Data[name].DefaultValue;
                    new Notification().ShowNotification($"Значение \"{_dataGridView.Columns[e.ColumnIndex].HeaderText}\" не может быть пустым.");
                }
                else if (Convert.ToDouble(input) < minValue)
                {
                    _dataGridView[e.ColumnIndex, e.RowIndex].Value = minValue;
                    new Notification().ShowNotification($"Значение \"{_dataGridView.Columns[e.ColumnIndex].HeaderText}\" не может быть меньше {minValue}.");
                }

                switch (name)
                {
                    case CollectionNames.BatchesCount:
                    case CollectionNames.StartBatchSize:
                    case CollectionNames.TimeChangeBatch:
                    case CollectionNames.GrowthRateBatchSize:
                        ChangeHorizon(e.RowIndex);
                        break;
                }
            }
        }

        private void OnDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            new Notification().ShowNotification(e.Exception.Message);
        }
    }
}