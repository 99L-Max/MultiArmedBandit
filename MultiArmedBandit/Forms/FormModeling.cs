using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MultiArmedBandit.Properties;

namespace MultiArmedBandit
{
    partial class FormModeling : Form
    {
        private readonly ReadOnlyDictionary<string, bool> _collectionReadOnly;

        private IEnumerable<double> _deviations;
        private Player _player;

        public event Action<IDictionary<double, double[]>, int> ResultChanged;
        public event Action ClearChart;

        public FormModeling(Color backColor)
        {
            InitializeComponent();

            _dataGridView.BackgroundColor = backColor;
            _collectionReadOnly = FileHandler.ReadJsonResource<string, bool>(Resources.Dictionary_Collection_ReadOnly);
            _deviations = CollectionHandler.CreateCollection(0d, 0.3, 51, 1);
            _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);

            CreateTable();
            OnBanditsCountChanged(_numBanditsCount, EventArgs.Empty);

            SetComboBoxValues<Strategy>(_cmbStrategy);
            SetComboBoxValues<ConjugateDistribution>(_cmbConjugateDistribution);
            SetComboBoxValues<BatchSizeChangeRule>(_cmbBatchSizeChangeRule);

            _btnPause.Enabled = _btnCancel.Enabled = _btnSave.Enabled = false;

            foreach (Control ctrl in _grpSimulationSettings.Controls)
                if (ctrl is ComboBox cmb) cmb.SelectedIndex = 0;

            _dataGridView.CellValueChanged += OnDataGridViewCellValueChanged;
        }

        public bool IsSimulationFinished { get; private set; } = true;

        public bool IsDataSaved { get; private set; } = true;

        private bool ControlsEnabled
        {
            set
            {
                _grpSimulationSettings.Enabled = value;
                _dataGridView.ClearSelection();

                foreach (DataGridViewColumn col in _dataGridView.Columns)
                    col.ReadOnly = !value || _collectionReadOnly[col.Name];
            }
        }

        private bool ButtonsSimulationsEnabled
        {
            set
            {
                _btnNew.Enabled = value;
                _btnOpen.Enabled = value;

                _btnPause.Enabled = !value;
                _btnCancel.Enabled = !value;
                _progressBar.Visible = !value;
            }
        }

        private void SetComboBoxValues<T>(ComboBox comboBox) =>
            comboBox.Items.AddRange(Enum.GetNames(typeof(T)));

        private void CreateTable()
        {
            var columnsNames = Enum.GetValues(typeof(CollectionNames)).Cast<CollectionNames>().Where(x => x != CollectionNames.Deviation).ToArray();
            var columnsHeaderText = FileHandler.ReadJsonResource<CollectionNames, string>(Resources.Dictionary_Collection_Titles);
            var fontTable = new Font("", 14);
            var i = 0;

            _dataGridView.Columns.Clear();
            _dataGridView.ColumnCount = columnsNames.Length;

            foreach (var column in columnsNames)
            {
                _dataGridView.Columns[i].Name = column.ToString();
                _dataGridView.Columns[i].HeaderText = columnsHeaderText[column];
                _dataGridView.Columns[i].ValueType = typeof(double);
                _dataGridView.Columns[i].ReadOnly = _collectionReadOnly[column.ToString()];
                _dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                _dataGridView.Columns[i].HeaderCell.Style.Font = fontTable;
                _dataGridView.Columns[i].DefaultCellStyle.Font = fontTable;
                _dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dataGridView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                _dataGridView.Columns[i].DefaultCellStyle.Format = $"f{GameData.CollectionDecimalPlaces[column]}";

                if (column != CollectionNames.NumberRow)
                    _dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                i++;
            }

            _dataGridView.Columns[(int)CollectionNames.NumberRow].Width = 40;
        }

        private void ShowResult()
        {
            _lblDialog.Text = _player.GameData.GameResult;
            ResultChanged?.Invoke(_player.GameData.Regrets, _player.GameData.IndexBestBandit);
        }

        private void UpdateProgressBar(int percent) =>
            _progressBar.Value = percent;

        private void FinishSimulation(bool isCorrect)
        {
            _timer.Stop();
            _progressBar.Value = _progressBar.Minimum;
            _btnSave.Enabled = isCorrect;
            _btnStart.Enabled = ControlsEnabled = IsDataSaved = !isCorrect;
            _player.ProgressChanged -= UpdateProgressBar;

            ButtonsSimulationsEnabled = IsSimulationFinished = true;

            if (isCorrect)
            {
                ShowResult();
                OnChkPlaySoundCheckedChanged(_chkSoundPlay, EventArgs.Empty);
            }
            else
            {
                _lblDialog.Text = string.Empty;
            }
        }

        private void ClearPlayer()
        {
            if (_player != null)
            {
                _player.ProgressChanged -= UpdateProgressBar;
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

        private void SetColumn<T>(CollectionNames collectionName, IEnumerable<T> values, int startRowIndex = 0) =>
            SetColumn<T>(collectionName.ToString(), values, startRowIndex);

        private void SetColumn<T>(string nameColumn, IEnumerable<T> values, int startRowIndex = 0)
        {
            var enumerator = values.GetEnumerator();
            var i = startRowIndex;

            while (enumerator.MoveNext() && i < _dataGridView.RowCount)
                _dataGridView.Rows[i++].Cells[nameColumn].Value = enumerator.Current;
        }

        private void ChangeHorizon(int rowIndex)
        {
            var row = _dataGridView.Rows[rowIndex];
            var rule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex;
            var numberBatches = Convert.ToInt32(row.Cells[CollectionNames.NumberBatches.ToString()].Value);
            var startBatchSize = Convert.ToInt32(row.Cells[CollectionNames.StartBatchSize.ToString()].Value);
            var growthRateBatchSize = Convert.ToDouble(row.Cells[CollectionNames.GrowthRateBatchSize.ToString()].Value);
            var timeChangeBatch = Convert.ToInt32(row.Cells[CollectionNames.TimeChangeBatch.ToString()].Value);

            row.Cells[CollectionNames.Horizon.ToString()].Value =
                HorizonBuilder.GetHorizon(rule, numberBatches, startBatchSize, growthRateBatchSize, timeChangeBatch);
        }

        private void OnNewClick(object sender, EventArgs e)
        {
            if (!IsDataSaved && DialogResult.No == MessageBox.Show($"Несохранённые данные будут удалены.\nПродолжить?", "Данные не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            ClearChart?.Invoke();
            ClearPlayer();

            _lblDialog.Text = string.Empty;
            _btnSave.Enabled = false;

            IsDataSaved = ControlsEnabled = _btnStart.Enabled = true;
        }

        [Obsolete]
        private void OnStartClick(object sender, EventArgs e)
        {
            ClearPlayer();
            ControlsEnabled = ButtonsSimulationsEnabled = IsSimulationFinished =
                IsDataSaved = _btnStart.Enabled = _btnSave.Enabled = false;

            var gameData = new GameData
            {
                CountBandits = (int)_numBanditsCount.Value,
                CentralExpectation = (double)_numCentralExpectation.Value,
                MaxVariance = (double)_numMaxVariance.Value,

                BatchSizeChangeRule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex,
                Strategy = (Strategy)_cmbStrategy.SelectedIndex,
                ConjugateDistribution = (ConjugateDistribution)_cmbConjugateDistribution.SelectedIndex,

                CountArms = GetColumnInt(CollectionNames.CountArms),
                NumberBatches = GetColumnInt(CollectionNames.NumberBatches),
                StartBatchSize = GetColumnInt(CollectionNames.StartBatchSize),
                GrowthRateBatchSize = GetColumnDouble(CollectionNames.GrowthRateBatchSize),
                TimeChangeBatch = GetColumnInt(CollectionNames.TimeChangeBatch),
                ParameterUCB = GetColumnDouble(CollectionNames.ParameterUCB),
                Deviations = _deviations.ToArray(),

                CountGames = (int)_numCountGames.Value,
                CountThreads = (int)_numCountThreads.Value
            };

            _player = new Player(gameData);
            _player.ProgressChanged += UpdateProgressBar;

            _player.Play();
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (_player.IsPlaying)
                _lblDialog.Text = _player.GameInformation;
            else
                FinishSimulation(true);
        }

        [Obsolete]
        private void OnCancelClick(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Вы действительно хотите отменить вычисления?", "Отмена операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            if (_player.IsPaused)
                OnPauseClick(_btnPause, EventArgs.Empty);

            _player.CancelGame();

            FinishSimulation(false);
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
            if (!IsDataSaved && DialogResult.No == MessageBox.Show($"Несохранённые данные будут удалены.\nПродолжить?", "Данные не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            var gameData = FileHandler.Open();

            if (gameData == null)
                return;

            ClearPlayer();

            _player = new Player(gameData);
            _deviations = gameData.Deviations;
            _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);

            _dataGridView.CellValueChanged -= OnDataGridViewCellValueChanged;
            _cmbBatchSizeChangeRule.SelectedIndexChanged -= OnBatchSizeChangeRuleChanged;

            _numBanditsCount.Value = gameData.CountBandits;
            _numCountGames.Value = gameData.CountGames;
            _numCountThreads.Value = gameData.CountThreads;

            _numCentralExpectation.Value = (decimal)gameData.CentralExpectation;
            _numMaxVariance.Value = (decimal)gameData.MaxVariance;

            _cmbStrategy.SelectedIndex = (int)gameData.Strategy;
            _cmbBatchSizeChangeRule.SelectedIndex = (int)gameData.BatchSizeChangeRule;
            _cmbConjugateDistribution.SelectedIndex = (int)gameData.ConjugateDistribution;

            SetColumn(CollectionNames.CountArms, gameData.CountArms);
            SetColumn(CollectionNames.NumberBatches, gameData.NumberBatches);
            SetColumn(CollectionNames.StartBatchSize, gameData.StartBatchSize);
            SetColumn(CollectionNames.GrowthRateBatchSize, gameData.GrowthRateBatchSize);
            SetColumn(CollectionNames.TimeChangeBatch, gameData.TimeChangeBatch);
            SetColumn(CollectionNames.ParameterUCB, gameData.ParameterUCB);

            OnBatchSizeChangeRuleChanged(_cmbBatchSizeChangeRule, EventArgs.Empty);

            _dataGridView.CellValueChanged += OnDataGridViewCellValueChanged;
            _cmbBatchSizeChangeRule.SelectedIndexChanged += OnBatchSizeChangeRuleChanged;

            ShowResult();
            _btnSave.Enabled = IsDataSaved = true;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var form = new FormDataSave(_player.GameData, IsDataSaved);
            form.FormClosing += OnFormDataSaveClosing;
            form.ShowDialog();
        }

        private void OnDeviationsSettingsClick(object sender, EventArgs e)
        {
            var collectionName = CollectionNames.Deviation.ToString();
            var title = "Отклонения d от мат. ожидания m";
            var start = _deviations.First();
            var count = _deviations.Count();
            var step = count > 1 ? (_deviations.Last() - start) / (count - 1) : 0.3d;
            var form = new FormCollectionSettings(collectionName, title, start, step, count, -100d, 100d, 1, false);

            form.FormClosing += OnFormCollectionSettingsClosing;
            form.ShowDialog();
        }

        private void OnBatchSizeChangeRuleChanged(object sender, EventArgs e)
        {
            var rule = (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex;
            var indexHorizon = (int)CollectionNames.Horizon;
            var numberBatches = GetColumnInt(CollectionNames.NumberBatches);
            var startBatchSize = GetColumnInt(CollectionNames.StartBatchSize);
            var timeChangeBatch = GetColumnInt(CollectionNames.TimeChangeBatch);
            var growthRateBatchSize = GetColumnDouble(CollectionNames.GrowthRateBatchSize);

            for (int i = 0; i < _dataGridView.RowCount; i++)
                _dataGridView.Rows[i].Cells[indexHorizon].Value = HorizonBuilder.GetHorizon(rule, numberBatches[i], startBatchSize[i], growthRateBatchSize[i], timeChangeBatch[i]);
        }

        private void OnBanditsCountChanged(object sender, EventArgs e)
        {
            int delta = (int)_numBanditsCount.Value - _dataGridView.RowCount;

            if (delta > 0)
            {
                var numberRow = _dataGridView.RowCount + 1;

                while (delta-- > 0)
                {
                    _dataGridView.Rows.Add(
                        numberRow,
                        GameData.CollectionDefault[CollectionNames.CountArms],
                        GameData.CollectionDefault[CollectionNames.NumberBatches],
                        GameData.CollectionDefault[CollectionNames.StartBatchSize],
                        GameData.CollectionDefault[CollectionNames.GrowthRateBatchSize],
                        GameData.CollectionDefault[CollectionNames.TimeChangeBatch],
                        GameData.CollectionDefault[CollectionNames.Horizon],
                        GameData.CollectionDefault[CollectionNames.ParameterUCB]
                        );

                    ChangeHorizon(numberRow++ - 1);
                }
            }
            else
                _dataGridView.RowCount = (int)_numBanditsCount.Value;
        }

        private void OnChkPlaySoundCheckedChanged(object sender, EventArgs e)
        {
            if (_chkSoundPlay.Checked)
                Sound.Play(Properties.Resources.Sound_Done);
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
                    SetColumn(form.CollectionName, form.GetCollection());

                form.FormClosing -= OnFormCollectionSettingsClosing;
            }
        }

        private void OnFormDataSaveClosing(object sender, FormClosingEventArgs e)
        {
            if (sender is FormDataSave form)
            {
                IsDataSaved = form.IsAllDataSaved;
                form.FormClosing -= OnFormDataSaveClosing;
            }
        }

        private void OnDataGridViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                var selectedColumnIndex = _dataGridView.SelectedCells[0].ColumnIndex;
                var clipboardText = Clipboard.GetText();

                if (_dataGridView.Columns[selectedColumnIndex].ReadOnly) return;
                if (string.IsNullOrEmpty(clipboardText)) return;

                var columnName = _dataGridView.Columns[selectedColumnIndex].Name;
                var rowIndex = _dataGridView.CurrentCell.RowIndex;
                var rows = clipboardText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var column = rows.Select(x => x.Split('\t')[0]);
                var values = column.Select(s => { return double.TryParse(s, out double value) ? (double?)value : null; }).Where(d => d.HasValue).Select(d => d.Value);

                SetColumn(columnName, values, rowIndex);
            }
        }

        private void OnDataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex].ReadOnly) return;

            var nameColumn = (CollectionNames)e.ColumnIndex;
            var title = _dataGridView.Columns[e.ColumnIndex].HeaderText;
            var decimalPlaces = GameData.CollectionDecimalPlaces[nameColumn];

            var start = GameData.CollectionDefault[nameColumn];
            var step = 0d;
            var count = _dataGridView.RowCount;

            var minStart = GameData.CollectionMinimum[nameColumn];
            var maxStart = int.MaxValue;

            var form = new FormCollectionSettings(nameColumn.ToString(), title, start, step, count, minStart, maxStart, decimalPlaces, true);

            form.FormClosing += OnFormCollectionSettingsClosing;
            form.ShowDialog();
        }

        private void OnDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var name = (CollectionNames)e.ColumnIndex;
            var minValue = GameData.CollectionMinimum[name];
            var input = _dataGridView[e.ColumnIndex, e.RowIndex].Value;

            if (input.ToString() == string.Empty)
            {
                _dataGridView[e.ColumnIndex, e.RowIndex].Value = GameData.CollectionDefault[name];
                Notificator.ShowNotification($"Значение \"{_dataGridView.Columns[e.ColumnIndex].HeaderText}\" не может быть пустым.");
            }
            else if (Convert.ToDouble(input) < minValue)
            {
                _dataGridView[e.ColumnIndex, e.RowIndex].Value = minValue;
                Notificator.ShowNotification($"Значение \"{_dataGridView.Columns[e.ColumnIndex].HeaderText}\" не может быть меньше {minValue}.");
            }

            switch (name)
            {
                case CollectionNames.NumberBatches:
                case CollectionNames.StartBatchSize:
                case CollectionNames.TimeChangeBatch:
                case CollectionNames.GrowthRateBatchSize:
                    ChangeHorizon(e.RowIndex);
                    break;
            }
        }

        private void OnDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e) =>
            Notificator.ShowNotification(e.Exception.Message);
    }
}