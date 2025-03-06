using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MultiArmedBandit.Properties;

namespace MultiArmedBandit
{
    enum CollectionNames { NumberRow, CountArms, NumberBatches, StartBatchSize, GrowthRateBatchSize, TimeChangeBatch, Horizon, ParameterUCB, Deviation }

    partial class FormModeling : Form
    {
        private IEnumerable<double> _deviations;
        private Player _player;

        public event Action<IDictionary<double, double[]>, int> ResultChanged;
        public event Action ClearChart;

        public FormModeling(Color backColor)
        {
            InitializeComponent();
            CreateTable();
            OnBanditsCountChanged(_numBanditsCount, EventArgs.Empty);

            _dataGridView.BackgroundColor = backColor;
            _deviations = CollectionHandler.CreateDoubleCollection(0d, 0.3, 51, 1);
            _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);
            _cmbBatchSizeChangeRule.Items.AddRange(Enum.GetNames(typeof(BatchSizeChangeRule)));
            _cmbStrategy.Items.AddRange(Enum.GetNames(typeof(Strategy)));

            _btnPause.Enabled = _btnCancel.Enabled = _btnSave.Enabled = false;
            _cmbBatchSizeChangeRule.SelectedIndex = _cmbStrategy.SelectedIndex = 0;

            _dataGridView.CellValueChanged += OnDataGridViewCellValueChanged;
        }

        public bool IsSimulationFinished { get; private set; } = true;

        public bool IsDataSaved { get; private set; } = true;

        private bool ControlsEnabled
        {
            set
            {
                _grpSimulationSettings.Enabled = value;
                _dataGridView.CurrentCell.Selected = value;
                _dataGridView.DefaultCellStyle.SelectionBackColor = value ? SystemColors.Highlight : Color.Transparent;
                _dataGridView.Enabled = value;
                _dataGridView.ClearSelection();
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

        private void CreateTable()
        {
            var columnsNames = Enum.GetValues(typeof(CollectionNames)).Cast<CollectionNames>().Where(x => x != CollectionNames.Deviation).ToArray();
            var columnsHeaderText = FileHandler.ReadJsonResource<CollectionNames, string>(Resources.CollectionTitles);
            var dataTypes = FileHandler.ReadJsonResource<CollectionNames, Type>(Resources.CollectionTypes);
            var fontTable = new Font("", 14);
            var i = 0;

            _dataGridView.Columns.Clear();
            _dataGridView.ColumnCount = columnsNames.Length;

            foreach (var column in columnsNames)
            {
                _dataGridView.Columns[i].Name = column.ToString();
                _dataGridView.Columns[i].HeaderText = columnsHeaderText[column];
                _dataGridView.Columns[i].ValueType = dataTypes[column];
                _dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                _dataGridView.Columns[i].HeaderCell.Style.Font = fontTable;
                _dataGridView.Columns[i].DefaultCellStyle.Font = fontTable;
                _dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dataGridView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                _dataGridView.Columns[i].DefaultCellStyle.Format = dataTypes[column] == typeof(double) ? "f2" : "f0";

                if (column != CollectionNames.NumberRow) _dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                i++;
            }

            _dataGridView.Columns[(int)CollectionNames.NumberRow].Width = 40;
            _dataGridView.Columns[(int)CollectionNames.NumberRow].ReadOnly = true;
            _dataGridView.Columns[(int)CollectionNames.Horizon].ReadOnly = true;
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

        private T[] GetColumn<T>(CollectionNames collectionName)
        {
            var arr = new T[_dataGridView.Rows.Count];
            var nameColumn = collectionName.ToString();

            for (int i = 0; i < _dataGridView.Rows.Count; i++)
                try
                {
                    arr[i] = (T)Convert.ChangeType(_dataGridView.Rows[i].Cells[nameColumn].Value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    arr[i] = default;
                }

            return arr;
        }

        private void SetColumn<T>(CollectionNames collectionName, IEnumerable<T> values) =>
            SetColumn<T>(collectionName.ToString(), values);

        private void SetColumn<T>(string nameColumn, IEnumerable<T> values)
        {
            var i = 0;

            foreach (var value in values)
                _dataGridView.Rows[i++].Cells[nameColumn].Value = value;
        }

        private void ChangeHorizon(int rowIndex)
        {
            var row = _dataGridView.Rows[rowIndex];

            row.Cells[CollectionNames.Horizon.ToString()].Value =
                HorizonBuilder.GetHorizon(
                    (BatchSizeChangeRule)_cmbBatchSizeChangeRule.SelectedIndex,
                    (int)row.Cells[CollectionNames.NumberBatches.ToString()].Value,
                    (int)row.Cells[CollectionNames.StartBatchSize.ToString()].Value,
                    (double)row.Cells[CollectionNames.GrowthRateBatchSize.ToString()].Value,
                    (int)row.Cells[CollectionNames.TimeChangeBatch.ToString()].Value
                    );
        }

        private void AdjustDataGridViewCellValue(DataGridViewCellEventArgs e, double minValue)
        {
            if (Convert.ToDouble(_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) < minValue)
            {
                if (_dataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format.Equals(typeof(double)))
                    _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = minValue;
                else
                    _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (int)minValue;

                MessageBox.Show($"Значение \"{_dataGridView.Columns[e.ColumnIndex].HeaderText}\" не может быть меньше {minValue}", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                CountArms = GetColumn<int>(CollectionNames.CountArms),
                NumberBatches = GetColumn<int>(CollectionNames.NumberBatches),
                StartBatchSize = GetColumn<int>(CollectionNames.StartBatchSize),
                GrowthRateBatchSize = GetColumn<double>(CollectionNames.GrowthRateBatchSize),
                TimeChangeBatch = GetColumn<int>(CollectionNames.TimeChangeBatch),
                ParameterUCB = GetColumn<double>(CollectionNames.ParameterUCB),
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

            _numBanditsCount.Value = gameData.CountBandits;
            _numCountGames.Value = gameData.CountGames;
            _numCountThreads.Value = gameData.CountThreads;

            _numCentralExpectation.Value = (decimal)gameData.CentralExpectation;
            _numMaxVariance.Value = (decimal)gameData.MaxVariance;

            SetColumn(CollectionNames.CountArms, gameData.CountArms);
            SetColumn(CollectionNames.NumberBatches, gameData.NumberBatches);
            SetColumn(CollectionNames.StartBatchSize, gameData.StartBatchSize);
            SetColumn(CollectionNames.GrowthRateBatchSize, gameData.GrowthRateBatchSize);
            SetColumn(CollectionNames.TimeChangeBatch, gameData.TimeChangeBatch);
            SetColumn(CollectionNames.ParameterUCB, gameData.ParameterUCB);

            _cmbStrategy.SelectedIndex = (int)gameData.Strategy;
            _cmbBatchSizeChangeRule.SelectedIndex = (int)gameData.BatchSizeChangeRule;

            _dataGridView.CellValueChanged += OnDataGridViewCellValueChanged;

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
            var numberBatches = GetColumn<int>(CollectionNames.NumberBatches);
            var startBatchSize = GetColumn<int>(CollectionNames.StartBatchSize);
            var timeChangeBatch = GetColumn<int>(CollectionNames.TimeChangeBatch);
            var growthRateBatchSize = GetColumn<double>(CollectionNames.GrowthRateBatchSize);

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
                        GameData.DefaultCountArms,
                        GameData.DefaultNumberBatches,
                        GameData.DefaultStartBatchSize,
                        GameData.DefaultGrowthRateBatchSize,
                        GameData.DefaultTimeChangeBatch,
                        0,
                        GameData.DefaultParameterUCB
                        );

                    ChangeHorizon(numberRow - 1);
                    numberRow++;
                }
            }
            else
                _dataGridView.RowCount = (int)_numBanditsCount.Value;
        }

        private void OnChkPlaySoundCheckedChanged(object sender, EventArgs e)
        {
            if (_chkSoundPlay.Checked)
                Sound.Play(Properties.Resources.SoundDone);
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
                    _deviations = form.GetDoubleCollection();
                    _txtDeviations.Text = CollectionHandler.ConvertToShortString(_deviations);
                }
                else if (_dataGridView.Columns[form.CollectionName].ValueType == typeof(double))
                    SetColumn(form.CollectionName, form.GetDoubleCollection());
                else
                    SetColumn(form.CollectionName, form.GetIntCollection());

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

        private void OnDataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var nameColumn = (CollectionNames)e.ColumnIndex;

            if (nameColumn == CollectionNames.NumberRow || nameColumn == CollectionNames.Horizon)
                return;

            var title = _dataGridView.Columns[e.ColumnIndex].HeaderText;
            var decimalPlaces = _dataGridView.Columns[e.ColumnIndex].ValueType == typeof(double) ? 2 : 0;
            var count = _dataGridView.RowCount;
            var (start, step, minStart, maxStart) = (0d, 0d, 0d, 0d);

            switch (nameColumn)
            {
                case CollectionNames.CountArms:
                    (start, step, minStart, maxStart) = (GameData.DefaultCountArms, 0, Bandit.MinCountArms, 10);
                    break;
                case CollectionNames.NumberBatches:
                    (start, step, minStart, maxStart) = (GameData.DefaultNumberBatches, 0, 1, int.MaxValue);
                    break;
                case CollectionNames.StartBatchSize:
                    (start, step, minStart, maxStart) = (GameData.DefaultStartBatchSize, 0, 2, int.MaxValue);
                    break;
                case CollectionNames.GrowthRateBatchSize:
                    (start, step, minStart, maxStart) = (GameData.DefaultGrowthRateBatchSize, 0.2d, 1d, int.MaxValue);
                    break;
                case CollectionNames.TimeChangeBatch:
                    (start, step, minStart, maxStart) = (GameData.DefaultTimeChangeBatch, 5, 1, int.MaxValue);
                    break;
                case CollectionNames.ParameterUCB:
                    (start, step, minStart, maxStart) = (GameData.DefaultParameterUCB, 0.01d, 0d, int.MaxValue);
                    break;
            }

            var form = new FormCollectionSettings(nameColumn.ToString(), title, start, step, count, minStart, maxStart, decimalPlaces, true);

            form.FormClosing += OnFormCollectionSettingsClosing;
            form.ShowDialog();
        }

        private void OnDataGridViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                var lines = Clipboard.GetText(TextDataFormat.Text).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                var rowIndex = _dataGridView.CurrentCell.RowIndex;
                var colIndex = _dataGridView.Columns.IndexOf(_dataGridView.CurrentCell.OwningColumn);

                if (_dataGridView.Columns[colIndex].Index == (int)CollectionNames.NumberRow)
                    return;

                foreach (var line in lines)
                    if (rowIndex < _dataGridView.RowCount && line.Length > 0)
                    {
                        string[] cells = line.Split('\t');

                        for (int i = 0; i < cells.Length; ++i)
                            if (colIndex + i < _dataGridView.ColumnCount)
                                if (_dataGridView.Columns[colIndex + i].ValueType == typeof(int))
                                    _dataGridView[colIndex + i, rowIndex].Value = int.Parse(cells[i]);
                                else
                                    _dataGridView[colIndex + i, rowIndex].Value = double.Parse(cells[i]);

                        rowIndex++;
                    }
            }
        }

        private void OnDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            switch ((CollectionNames)e.ColumnIndex)
            {
                case CollectionNames.CountArms:
                    AdjustDataGridViewCellValue(e, Bandit.MinCountArms);
                    break;

                case CollectionNames.NumberBatches:
                case CollectionNames.StartBatchSize:
                case CollectionNames.TimeChangeBatch:
                case CollectionNames.GrowthRateBatchSize:
                    AdjustDataGridViewCellValue(e, 1);
                    ChangeHorizon(e.RowIndex);
                    break;

                case CollectionNames.ParameterUCB:
                    AdjustDataGridViewCellValue(e, 0);
                    break;
            }
        }

        private void OnDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e) =>
            MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}