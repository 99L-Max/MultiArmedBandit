using System.Threading;

namespace MultiArmedBandit
{
    partial class FormModeling
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._lbl8 = new System.Windows.Forms.Label();
            this._numMaxVariance = new System.Windows.Forms.NumericUpDown();
            this._lbl1 = new System.Windows.Forms.Label();
            this._numCentralExpectation = new System.Windows.Forms.NumericUpDown();
            this._numCountGames = new System.Windows.Forms.NumericUpDown();
            this._lbl3 = new System.Windows.Forms.Label();
            this._lbl4 = new System.Windows.Forms.Label();
            this._numBanditsCount = new System.Windows.Forms.NumericUpDown();
            this._numCountThreads = new System.Windows.Forms.NumericUpDown();
            this._lbl5 = new System.Windows.Forms.Label();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._grpButtons = new System.Windows.Forms.GroupBox();
            this._btnNew = new System.Windows.Forms.Button();
            this._chkSoundPlay = new System.Windows.Forms.CheckBox();
            this._btnOpen = new System.Windows.Forms.Button();
            this._btnPause = new System.Windows.Forms.Button();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._grpSimulationSettings = new System.Windows.Forms.GroupBox();
            this._btnDeviationsSettings = new System.Windows.Forms.Button();
            this._lbl2 = new System.Windows.Forms.Label();
            this._txtDeviations = new System.Windows.Forms.TextBox();
            this._lbl7 = new System.Windows.Forms.Label();
            this._cmbBatchSizeChangeRule = new System.Windows.Forms.ComboBox();
            this._lbl6 = new System.Windows.Forms.Label();
            this._cmbStrategy = new System.Windows.Forms.ComboBox();
            this._lblDialog = new System.Windows.Forms.Label();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._lbl9 = new System.Windows.Forms.Label();
            this._cmbConjugateDistribution = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._numMaxVariance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCentralExpectation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCountGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numBanditsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCountThreads)).BeginInit();
            this._grpButtons.SuspendLayout();
            this._grpSimulationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _lbl8
            // 
            this._lbl8.AutoSize = true;
            this._lbl8.Location = new System.Drawing.Point(193, 190);
            this._lbl8.Name = "_lbl8";
            this._lbl8.Size = new System.Drawing.Size(160, 20);
            this._lbl8.TabIndex = 32;
            this._lbl8.Text = "Макс.  дисперсия D:";
            // 
            // _numMaxVariance
            // 
            this._numMaxVariance.DecimalPlaces = 2;
            this._numMaxVariance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._numMaxVariance.Location = new System.Drawing.Point(359, 188);
            this._numMaxVariance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numMaxVariance.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this._numMaxVariance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._numMaxVariance.Name = "_numMaxVariance";
            this._numMaxVariance.Size = new System.Drawing.Size(112, 26);
            this._numMaxVariance.TabIndex = 33;
            this._numMaxVariance.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // _lbl1
            // 
            this._lbl1.AutoSize = true;
            this._lbl1.Location = new System.Drawing.Point(208, 160);
            this._lbl1.Name = "_lbl1";
            this._lbl1.Size = new System.Drawing.Size(145, 20);
            this._lbl1.TabIndex = 1;
            this._lbl1.Text = "Мат. ожидание m:";
            // 
            // _numCentralExpectation
            // 
            this._numCentralExpectation.DecimalPlaces = 2;
            this._numCentralExpectation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._numCentralExpectation.Location = new System.Drawing.Point(359, 158);
            this._numCentralExpectation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numCentralExpectation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numCentralExpectation.Name = "_numCentralExpectation";
            this._numCentralExpectation.Size = new System.Drawing.Size(112, 26);
            this._numCentralExpectation.TabIndex = 2;
            this._numCentralExpectation.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // _numCountGames
            // 
            this._numCountGames.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this._numCountGames.Location = new System.Drawing.Point(359, 278);
            this._numCountGames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numCountGames.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._numCountGames.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._numCountGames.Name = "_numCountGames";
            this._numCountGames.Size = new System.Drawing.Size(112, 26);
            this._numCountGames.TabIndex = 6;
            this._numCountGames.Value = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            // 
            // _lbl3
            // 
            this._lbl3.AutoSize = true;
            this._lbl3.Location = new System.Drawing.Point(207, 280);
            this._lbl3.Name = "_lbl3";
            this._lbl3.Size = new System.Drawing.Size(146, 20);
            this._lbl3.TabIndex = 5;
            this._lbl3.Text = "Число симуляций:";
            // 
            // _lbl4
            // 
            this._lbl4.AutoSize = true;
            this._lbl4.Location = new System.Drawing.Point(215, 220);
            this._lbl4.Name = "_lbl4";
            this._lbl4.Size = new System.Drawing.Size(139, 20);
            this._lbl4.TabIndex = 18;
            this._lbl4.Text = "Число бандитов:";
            // 
            // _numBanditsCount
            // 
            this._numBanditsCount.Location = new System.Drawing.Point(359, 218);
            this._numBanditsCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numBanditsCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this._numBanditsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numBanditsCount.Name = "_numBanditsCount";
            this._numBanditsCount.Size = new System.Drawing.Size(112, 26);
            this._numBanditsCount.TabIndex = 23;
            this._numBanditsCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._numBanditsCount.ValueChanged += new System.EventHandler(this.OnBanditsCountChanged);
            // 
            // _numCountThreads
            // 
            this._numCountThreads.Location = new System.Drawing.Point(359, 248);
            this._numCountThreads.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numCountThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numCountThreads.Name = "_numCountThreads";
            this._numCountThreads.Size = new System.Drawing.Size(112, 26);
            this._numCountThreads.TabIndex = 25;
            this._numCountThreads.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // _lbl5
            // 
            this._lbl5.AutoSize = true;
            this._lbl5.Location = new System.Drawing.Point(226, 250);
            this._lbl5.Name = "_lbl5";
            this._lbl5.Size = new System.Drawing.Size(127, 20);
            this._lbl5.TabIndex = 24;
            this._lbl5.Text = "Число потоков:";
            // 
            // _btnStart
            // 
            this._btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnStart.BackColor = System.Drawing.Color.White;
            this._btnStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnStart.ForeColor = System.Drawing.Color.Black;
            this._btnStart.Location = new System.Drawing.Point(255, 29);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(199, 40);
            this._btnStart.TabIndex = 4;
            this._btnStart.Text = "Запуск";
            this._btnStart.UseVisualStyleBackColor = false;
            this._btnStart.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnStart.Click += new System.EventHandler(this.OnStartClick);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnSave.BackColor = System.Drawing.Color.White;
            this._btnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnSave.ForeColor = System.Drawing.Color.Black;
            this._btnSave.Location = new System.Drawing.Point(50, 120);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(199, 40);
            this._btnSave.TabIndex = 7;
            this._btnSave.Text = "Сохранить";
            this._btnSave.UseVisualStyleBackColor = false;
            this._btnSave.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnCancel.BackColor = System.Drawing.Color.White;
            this._btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnCancel.ForeColor = System.Drawing.Color.Black;
            this._btnCancel.Location = new System.Drawing.Point(255, 120);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(199, 40);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Отмена";
            this._btnCancel.UseVisualStyleBackColor = false;
            this._btnCancel.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnCancel.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // _grpButtons
            // 
            this._grpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpButtons.Controls.Add(this._btnNew);
            this._grpButtons.Controls.Add(this._chkSoundPlay);
            this._grpButtons.Controls.Add(this._btnCancel);
            this._grpButtons.Controls.Add(this._btnOpen);
            this._grpButtons.Controls.Add(this._btnPause);
            this._grpButtons.Controls.Add(this._btnSave);
            this._grpButtons.Controls.Add(this._btnStart);
            this._grpButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._grpButtons.ForeColor = System.Drawing.Color.White;
            this._grpButtons.Location = new System.Drawing.Point(611, 333);
            this._grpButtons.Name = "_grpButtons";
            this._grpButtons.Size = new System.Drawing.Size(482, 198);
            this._grpButtons.TabIndex = 8;
            this._grpButtons.TabStop = false;
            this._grpButtons.Text = "Управление";
            // 
            // _btnNew
            // 
            this._btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnNew.BackColor = System.Drawing.Color.White;
            this._btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnNew.ForeColor = System.Drawing.Color.Black;
            this._btnNew.Location = new System.Drawing.Point(50, 28);
            this._btnNew.Name = "_btnNew";
            this._btnNew.Size = new System.Drawing.Size(199, 40);
            this._btnNew.TabIndex = 47;
            this._btnNew.Text = "Новый";
            this._btnNew.UseVisualStyleBackColor = false;
            this._btnNew.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnNew.Click += new System.EventHandler(this.OnNewClick);
            // 
            // _chkSoundPlay
            // 
            this._chkSoundPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._chkSoundPlay.AutoSize = true;
            this._chkSoundPlay.Checked = true;
            this._chkSoundPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkSoundPlay.Location = new System.Drawing.Point(50, 166);
            this._chkSoundPlay.Name = "_chkSoundPlay";
            this._chkSoundPlay.Size = new System.Drawing.Size(180, 24);
            this._chkSoundPlay.TabIndex = 0;
            this._chkSoundPlay.Text = "Сигнал завершения";
            this._chkSoundPlay.UseVisualStyleBackColor = false;
            this._chkSoundPlay.CheckedChanged += new System.EventHandler(this.OnChkPlaySoundCheckedChanged);
            // 
            // _btnOpen
            // 
            this._btnOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnOpen.BackColor = System.Drawing.Color.White;
            this._btnOpen.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnOpen.ForeColor = System.Drawing.Color.Black;
            this._btnOpen.Location = new System.Drawing.Point(50, 74);
            this._btnOpen.Name = "_btnOpen";
            this._btnOpen.Size = new System.Drawing.Size(199, 40);
            this._btnOpen.TabIndex = 46;
            this._btnOpen.Text = "Открыть";
            this._btnOpen.UseVisualStyleBackColor = false;
            this._btnOpen.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnOpen.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // _btnPause
            // 
            this._btnPause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnPause.BackColor = System.Drawing.Color.White;
            this._btnPause.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnPause.ForeColor = System.Drawing.Color.Black;
            this._btnPause.Location = new System.Drawing.Point(255, 75);
            this._btnPause.Name = "_btnPause";
            this._btnPause.Size = new System.Drawing.Size(199, 40);
            this._btnPause.TabIndex = 45;
            this._btnPause.Text = "Пауза";
            this._btnPause.UseVisualStyleBackColor = false;
            this._btnPause.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnPause.Click += new System.EventHandler(this.OnPauseClick);
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(12, 771);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(1081, 23);
            this._progressBar.TabIndex = 10;
            this._progressBar.Visible = false;
            // 
            // _grpSimulationSettings
            // 
            this._grpSimulationSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSimulationSettings.Controls.Add(this._lbl9);
            this._grpSimulationSettings.Controls.Add(this._cmbConjugateDistribution);
            this._grpSimulationSettings.Controls.Add(this._btnDeviationsSettings);
            this._grpSimulationSettings.Controls.Add(this._lbl2);
            this._grpSimulationSettings.Controls.Add(this._numCountThreads);
            this._grpSimulationSettings.Controls.Add(this._txtDeviations);
            this._grpSimulationSettings.Controls.Add(this._lbl3);
            this._grpSimulationSettings.Controls.Add(this._lbl7);
            this._grpSimulationSettings.Controls.Add(this._numCountGames);
            this._grpSimulationSettings.Controls.Add(this._cmbBatchSizeChangeRule);
            this._grpSimulationSettings.Controls.Add(this._lbl4);
            this._grpSimulationSettings.Controls.Add(this._lbl6);
            this._grpSimulationSettings.Controls.Add(this._lbl5);
            this._grpSimulationSettings.Controls.Add(this._cmbStrategy);
            this._grpSimulationSettings.Controls.Add(this._numBanditsCount);
            this._grpSimulationSettings.Controls.Add(this._numCentralExpectation);
            this._grpSimulationSettings.Controls.Add(this._lbl8);
            this._grpSimulationSettings.Controls.Add(this._lbl1);
            this._grpSimulationSettings.Controls.Add(this._numMaxVariance);
            this._grpSimulationSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._grpSimulationSettings.ForeColor = System.Drawing.Color.White;
            this._grpSimulationSettings.Location = new System.Drawing.Point(611, 12);
            this._grpSimulationSettings.Name = "_grpSimulationSettings";
            this._grpSimulationSettings.Size = new System.Drawing.Size(482, 315);
            this._grpSimulationSettings.TabIndex = 42;
            this._grpSimulationSettings.TabStop = false;
            this._grpSimulationSettings.Text = "Настройки симуляций";
            // 
            // _btnDeviationsSettings
            // 
            this._btnDeviationsSettings.BackColor = System.Drawing.Color.White;
            this._btnDeviationsSettings.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Button_Settings;
            this._btnDeviationsSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnDeviationsSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnDeviationsSettings.ForeColor = System.Drawing.Color.Black;
            this._btnDeviationsSettings.Location = new System.Drawing.Point(231, 127);
            this._btnDeviationsSettings.Name = "_btnDeviationsSettings";
            this._btnDeviationsSettings.Size = new System.Drawing.Size(26, 26);
            this._btnDeviationsSettings.TabIndex = 48;
            this._btnDeviationsSettings.UseVisualStyleBackColor = false;
            this._btnDeviationsSettings.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnDeviationsSettings.Click += new System.EventHandler(this.OnDeviationsSettingsClick);
            // 
            // _lbl2
            // 
            this._lbl2.AutoSize = true;
            this._lbl2.Location = new System.Drawing.Point(17, 130);
            this._lbl2.Name = "_lbl2";
            this._lbl2.Size = new System.Drawing.Size(208, 20);
            this._lbl2.TabIndex = 39;
            this._lbl2.Text = "Откл. от мат. ожидания d:";
            // 
            // _txtDeviations
            // 
            this._txtDeviations.Location = new System.Drawing.Point(263, 127);
            this._txtDeviations.Name = "_txtDeviations";
            this._txtDeviations.ReadOnly = true;
            this._txtDeviations.Size = new System.Drawing.Size(208, 26);
            this._txtDeviations.TabIndex = 38;
            // 
            // _lbl7
            // 
            this._lbl7.AutoSize = true;
            this._lbl7.Location = new System.Drawing.Point(110, 96);
            this._lbl7.Name = "_lbl7";
            this._lbl7.Size = new System.Drawing.Size(115, 20);
            this._lbl7.TabIndex = 37;
            this._lbl7.Text = "Правило M(k):";
            // 
            // _cmbBatchSizeChangeRule
            // 
            this._cmbBatchSizeChangeRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbBatchSizeChangeRule.FormattingEnabled = true;
            this._cmbBatchSizeChangeRule.Location = new System.Drawing.Point(231, 93);
            this._cmbBatchSizeChangeRule.Name = "_cmbBatchSizeChangeRule";
            this._cmbBatchSizeChangeRule.Size = new System.Drawing.Size(240, 28);
            this._cmbBatchSizeChangeRule.TabIndex = 36;
            this._cmbBatchSizeChangeRule.SelectedIndexChanged += new System.EventHandler(this.OnBatchSizeChangeRuleChanged);
            // 
            // _lbl6
            // 
            this._lbl6.AutoSize = true;
            this._lbl6.Location = new System.Drawing.Point(131, 28);
            this._lbl6.Name = "_lbl6";
            this._lbl6.Size = new System.Drawing.Size(94, 20);
            this._lbl6.TabIndex = 35;
            this._lbl6.Text = "Стратегия:";
            // 
            // _cmbStrategy
            // 
            this._cmbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbStrategy.FormattingEnabled = true;
            this._cmbStrategy.Location = new System.Drawing.Point(231, 25);
            this._cmbStrategy.Name = "_cmbStrategy";
            this._cmbStrategy.Size = new System.Drawing.Size(240, 28);
            this._cmbStrategy.TabIndex = 34;
            // 
            // _lblDialog
            // 
            this._lblDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblDialog.BackColor = System.Drawing.Color.White;
            this._lblDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this._lblDialog.ForeColor = System.Drawing.Color.Black;
            this._lblDialog.Location = new System.Drawing.Point(612, 534);
            this._lblDialog.Name = "_lblDialog";
            this._lblDialog.Size = new System.Drawing.Size(481, 225);
            this._lblDialog.TabIndex = 47;
            this._lblDialog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumPurple;
            this._dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this._dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this._dataGridView.EnableHeadersVisualStyles = false;
            this._dataGridView.Location = new System.Drawing.Point(12, 12);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlueViolet;
            this._dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this._dataGridView.RowTemplate.Height = 30;
            this._dataGridView.Size = new System.Drawing.Size(593, 747);
            this._dataGridView.TabIndex = 48;
            this._dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnDataGridViewColumnHeaderMouseClick);
            this._dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDataGridViewDataError);
            this._dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnDataGridViewKeyDown);
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // _lbl99
            // 
            this._lbl9.AutoSize = true;
            this._lbl9.Location = new System.Drawing.Point(27, 62);
            this._lbl9.Name = "_lbl99";
            this._lbl9.Size = new System.Drawing.Size(198, 20);
            this._lbl9.TabIndex = 50;
            this._lbl9.Text = "Сопряж. распределение:";
            // 
            // _cmbConjugateDistribution
            // 
            this._cmbConjugateDistribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbConjugateDistribution.FormattingEnabled = true;
            this._cmbConjugateDistribution.Location = new System.Drawing.Point(231, 59);
            this._cmbConjugateDistribution.Name = "_cmbConjugateDistribution";
            this._cmbConjugateDistribution.Size = new System.Drawing.Size(240, 28);
            this._cmbConjugateDistribution.TabIndex = 49;
            // 
            // FormModeling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1100, 808);
            this.Controls.Add(this._lblDialog);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._grpSimulationSettings);
            this.Controls.Add(this._grpButtons);
            this.Controls.Add(this._progressBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormModeling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormModeling";
            ((System.ComponentModel.ISupportInitialize)(this._numMaxVariance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCentralExpectation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCountGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numBanditsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numCountThreads)).EndInit();
            this._grpButtons.ResumeLayout(false);
            this._grpButtons.PerformLayout();
            this._grpSimulationSettings.ResumeLayout(false);
            this._grpSimulationSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnDeviationsSettings;
        private System.Windows.Forms.Button _btnNew;
        private System.Windows.Forms.Button _btnOpen;
        private System.Windows.Forms.Button _btnPause;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.CheckBox _chkSoundPlay;
        private System.Windows.Forms.ComboBox _cmbBatchSizeChangeRule;
        private System.Windows.Forms.ComboBox _cmbConjugateDistribution;
        private System.Windows.Forms.ComboBox _cmbStrategy;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.GroupBox _grpButtons;
        private System.Windows.Forms.GroupBox _grpSimulationSettings;
        private System.Windows.Forms.Label _lbl1;
        private System.Windows.Forms.Label _lbl2;
        private System.Windows.Forms.Label _lbl3;
        private System.Windows.Forms.Label _lbl4;
        private System.Windows.Forms.Label _lbl5;
        private System.Windows.Forms.Label _lbl6;
        private System.Windows.Forms.Label _lbl7;
        private System.Windows.Forms.Label _lbl8;
        private System.Windows.Forms.Label _lbl9;
        private System.Windows.Forms.Label _lblDialog;
        private System.Windows.Forms.NumericUpDown _numBanditsCount;
        private System.Windows.Forms.NumericUpDown _numCentralExpectation;
        private System.Windows.Forms.NumericUpDown _numCountGames;
        private System.Windows.Forms.NumericUpDown _numCountThreads;
        private System.Windows.Forms.NumericUpDown _numMaxVariance;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.TextBox _txtDeviations;
        private System.Windows.Forms.Timer _timer;

    }
}