namespace MultiArmedBandit
{
    partial class FormChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this._btnSaveGraph = new System.Windows.Forms.Button();
            this._lbl8 = new System.Windows.Forms.Label();
            this._numFontSize = new System.Windows.Forms.NumericUpDown();
            this._chkItalics = new System.Windows.Forms.CheckBox();
            this._lbl10 = new System.Windows.Forms.Label();
            this._txtNameY = new System.Windows.Forms.TextBox();
            this._lbl9 = new System.Windows.Forms.Label();
            this._txtNameX = new System.Windows.Forms.TextBox();
            this._btnLineSettings = new System.Windows.Forms.Button();
            this._grpBoxAxis = new System.Windows.Forms.GroupBox();
            this._lbl11 = new System.Windows.Forms.Label();
            this._lbl12 = new System.Windows.Forms.Label();
            this._lbl13 = new System.Windows.Forms.Label();
            this._numYMin = new System.Windows.Forms.NumericUpDown();
            this._numYMax = new System.Windows.Forms.NumericUpDown();
            this._numYInterval = new System.Windows.Forms.NumericUpDown();
            this._lbl3 = new System.Windows.Forms.Label();
            this._lbl2 = new System.Windows.Forms.Label();
            this._numXInterval = new System.Windows.Forms.NumericUpDown();
            this._lbl1 = new System.Windows.Forms.Label();
            this._numXMin = new System.Windows.Forms.NumericUpDown();
            this._numXMax = new System.Windows.Forms.NumericUpDown();
            this._numDecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this._lbl5 = new System.Windows.Forms.Label();
            this._grpBox_numerics = new System.Windows.Forms.GroupBox();
            this._grpBoxOther = new System.Windows.Forms.GroupBox();
            this._rbAllGraph = new System.Windows.Forms.RadioButton();
            this._rbOneGraph = new System.Windows.Forms.RadioButton();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this._numFontSize)).BeginInit();
            this._grpBoxAxis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numYMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numYInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numXInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numXMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDecimalPlaces)).BeginInit();
            this._grpBox_numerics.SuspendLayout();
            this._grpBoxOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnSaveGraph
            // 
            this._btnSaveGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveGraph.BackColor = System.Drawing.Color.White;
            this._btnSaveGraph.ForeColor = System.Drawing.Color.Black;
            this._btnSaveGraph.Location = new System.Drawing.Point(647, 376);
            this._btnSaveGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnSaveGraph.Name = "_btnSaveGraph";
            this._btnSaveGraph.Size = new System.Drawing.Size(163, 44);
            this._btnSaveGraph.TabIndex = 2;
            this._btnSaveGraph.Text = "Сохранить";
            this._btnSaveGraph.UseVisualStyleBackColor = false;
            this._btnSaveGraph.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnSaveGraph.Click += new System.EventHandler(this.OnSaveGraphClick);
            // 
            // _lbl8
            // 
            this._lbl8.AutoSize = true;
            this._lbl8.Location = new System.Drawing.Point(10, 26);
            this._lbl8.Name = "_lbl8";
            this._lbl8.Size = new System.Drawing.Size(64, 20);
            this._lbl8.TabIndex = 15;
            this._lbl8.Text = "Шрифт";
            // 
            // _numFontSize
            // 
            this._numFontSize.Location = new System.Drawing.Point(84, 24);
            this._numFontSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numFontSize.Name = "_numFontSize";
            this._numFontSize.Size = new System.Drawing.Size(92, 26);
            this._numFontSize.TabIndex = 17;
            this._numFontSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this._numFontSize.ValueChanged += new System.EventHandler(this.OnFontAxisChanged);
            // 
            // _chkItalics
            // 
            this._chkItalics.AutoSize = true;
            this._chkItalics.Location = new System.Drawing.Point(84, 56);
            this._chkItalics.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chkItalics.Name = "_chkItalics";
            this._chkItalics.Size = new System.Drawing.Size(80, 24);
            this._chkItalics.TabIndex = 22;
            this._chkItalics.Text = "Курсив";
            this._chkItalics.UseVisualStyleBackColor = true;
            this._chkItalics.CheckedChanged += new System.EventHandler(this.OnFontAxisChanged);
            // 
            // _lbl10
            // 
            this._lbl10.AutoSize = true;
            this._lbl10.Location = new System.Drawing.Point(203, 64);
            this._lbl10.Name = "_lbl10";
            this._lbl10.Size = new System.Drawing.Size(28, 20);
            this._lbl10.TabIndex = 21;
            this._lbl10.Text = "Oy";
            // 
            // _txtNameY
            // 
            this._txtNameY.Location = new System.Drawing.Point(247, 60);
            this._txtNameY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txtNameY.Name = "_txtNameY";
            this._txtNameY.Size = new System.Drawing.Size(92, 26);
            this._txtNameY.TabIndex = 20;
            this._txtNameY.TextChanged += new System.EventHandler(this.OnAxisYTextChanged);
            // 
            // _lbl9
            // 
            this._lbl9.AutoSize = true;
            this._lbl9.Location = new System.Drawing.Point(203, 28);
            this._lbl9.Name = "_lbl9";
            this._lbl9.Size = new System.Drawing.Size(28, 20);
            this._lbl9.TabIndex = 19;
            this._lbl9.Text = "Ox";
            // 
            // _txtNameX
            // 
            this._txtNameX.Location = new System.Drawing.Point(247, 26);
            this._txtNameX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txtNameX.Name = "_txtNameX";
            this._txtNameX.Size = new System.Drawing.Size(92, 26);
            this._txtNameX.TabIndex = 18;
            this._txtNameX.TextChanged += new System.EventHandler(this.OnAxisXTextChanged);
            // 
            // _btnLineSettings
            // 
            this._btnLineSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnLineSettings.BackColor = System.Drawing.Color.White;
            this._btnLineSettings.ForeColor = System.Drawing.Color.Black;
            this._btnLineSettings.Location = new System.Drawing.Point(465, 376);
            this._btnLineSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnLineSettings.Name = "_btnLineSettings";
            this._btnLineSettings.Size = new System.Drawing.Size(163, 44);
            this._btnLineSettings.TabIndex = 19;
            this._btnLineSettings.Text = "Настройки линий";
            this._btnLineSettings.UseVisualStyleBackColor = false;
            this._btnLineSettings.EnabledChanged += new System.EventHandler(this.OnButtonEnabledChanged);
            this._btnLineSettings.Click += new System.EventHandler(this.OnLineSettingsClick);
            // 
            // _grpBoxAxis
            // 
            this._grpBoxAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpBoxAxis.Controls.Add(this._chkItalics);
            this._grpBoxAxis.Controls.Add(this._numFontSize);
            this._grpBoxAxis.Controls.Add(this._lbl10);
            this._grpBoxAxis.Controls.Add(this._lbl8);
            this._grpBoxAxis.Controls.Add(this._txtNameY);
            this._grpBoxAxis.Controls.Add(this._txtNameX);
            this._grpBoxAxis.Controls.Add(this._lbl9);
            this._grpBoxAxis.ForeColor = System.Drawing.Color.White;
            this._grpBoxAxis.Location = new System.Drawing.Point(465, 187);
            this._grpBoxAxis.Name = "_grpBoxAxis";
            this._grpBoxAxis.Size = new System.Drawing.Size(346, 104);
            this._grpBoxAxis.TabIndex = 23;
            this._grpBoxAxis.TabStop = false;
            this._grpBoxAxis.Text = "Подписи";
            // 
            // _lbl11
            // 
            this._lbl11.AutoSize = true;
            this._lbl11.Location = new System.Drawing.Point(184, 97);
            this._lbl11.Name = "_lbl11";
            this._lbl11.Size = new System.Drawing.Size(53, 20);
            this._lbl11.TabIndex = 12;
            this._lbl11.Text = "Max Y";
            // 
            // _lbl12
            // 
            this._lbl12.AutoSize = true;
            this._lbl12.Location = new System.Drawing.Point(184, 127);
            this._lbl12.Name = "_lbl12";
            this._lbl12.Size = new System.Drawing.Size(53, 20);
            this._lbl12.TabIndex = 5;
            this._lbl12.Text = "Шаг Y";
            // 
            // _lbl13
            // 
            this._lbl13.AutoSize = true;
            this._lbl13.Location = new System.Drawing.Point(188, 67);
            this._lbl13.Name = "_lbl13";
            this._lbl13.Size = new System.Drawing.Size(49, 20);
            this._lbl13.TabIndex = 3;
            this._lbl13.Text = "Min Y";
            // 
            // _numYMin
            // 
            this._numYMin.Location = new System.Drawing.Point(247, 65);
            this._numYMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numYMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this._numYMin.Name = "_numYMin";
            this._numYMin.Size = new System.Drawing.Size(92, 26);
            this._numYMin.TabIndex = 12;
            this._numYMin.ValueChanged += new System.EventHandler(this.OnYMinChanged);
            // 
            // _numYMax
            // 
            this._numYMax.Location = new System.Drawing.Point(247, 95);
            this._numYMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numYMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this._numYMax.Name = "_numYMax";
            this._numYMax.Size = new System.Drawing.Size(92, 26);
            this._numYMax.TabIndex = 13;
            this._numYMax.ValueChanged += new System.EventHandler(this.OnYMaxChanged);
            // 
            // _numYInterval
            // 
            this._numYInterval.Location = new System.Drawing.Point(247, 125);
            this._numYInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numYInterval.Name = "_numYInterval";
            this._numYInterval.Size = new System.Drawing.Size(92, 26);
            this._numYInterval.TabIndex = 14;
            this._numYInterval.ValueChanged += new System.EventHandler(this.OnYIntervalChanged);
            // 
            // _lbl3
            // 
            this._lbl3.AutoSize = true;
            this._lbl3.Location = new System.Drawing.Point(17, 125);
            this._lbl3.Name = "_lbl3";
            this._lbl3.Size = new System.Drawing.Size(53, 20);
            this._lbl3.TabIndex = 5;
            this._lbl3.Text = "Шаг X";
            // 
            // _lbl2
            // 
            this._lbl2.AutoSize = true;
            this._lbl2.Location = new System.Drawing.Point(17, 95);
            this._lbl2.Name = "_lbl2";
            this._lbl2.Size = new System.Drawing.Size(53, 20);
            this._lbl2.TabIndex = 12;
            this._lbl2.Text = "Max X";
            // 
            // _numXInterval
            // 
            this._numXInterval.Location = new System.Drawing.Point(80, 123);
            this._numXInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numXInterval.Name = "_numXInterval";
            this._numXInterval.Size = new System.Drawing.Size(92, 26);
            this._numXInterval.TabIndex = 11;
            this._numXInterval.ValueChanged += new System.EventHandler(this.OnXIntervalChanged);
            // 
            // _lbl1
            // 
            this._lbl1.AutoSize = true;
            this._lbl1.Location = new System.Drawing.Point(21, 65);
            this._lbl1.Name = "_lbl1";
            this._lbl1.Size = new System.Drawing.Size(49, 20);
            this._lbl1.TabIndex = 3;
            this._lbl1.Text = "Min X";
            // 
            // _numXMin
            // 
            this._numXMin.Location = new System.Drawing.Point(80, 63);
            this._numXMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numXMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this._numXMin.Name = "_numXMin";
            this._numXMin.Size = new System.Drawing.Size(92, 26);
            this._numXMin.TabIndex = 9;
            this._numXMin.ValueChanged += new System.EventHandler(this.OnXMinChanged);
            // 
            // _numXMax
            // 
            this._numXMax.Location = new System.Drawing.Point(80, 93);
            this._numXMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._numXMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this._numXMax.Name = "_numXMax";
            this._numXMax.Size = new System.Drawing.Size(92, 26);
            this._numXMax.TabIndex = 10;
            this._numXMax.ValueChanged += new System.EventHandler(this.OnXMaxChanged);
            // 
            // _numDecimalPlaces
            // 
            this._numDecimalPlaces.Location = new System.Drawing.Point(192, 25);
            this._numDecimalPlaces.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._numDecimalPlaces.Name = "_numDecimalPlaces";
            this._numDecimalPlaces.Size = new System.Drawing.Size(92, 26);
            this._numDecimalPlaces.TabIndex = 13;
            this._numDecimalPlaces.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._numDecimalPlaces.ValueChanged += new System.EventHandler(this.OnDecimalPlacesChanged);
            // 
            // _lbl5
            // 
            this._lbl5.AutoSize = true;
            this._lbl5.Location = new System.Drawing.Point(73, 27);
            this._lbl5.Name = "_lbl5";
            this._lbl5.Size = new System.Drawing.Size(113, 20);
            this._lbl5.TabIndex = 14;
            this._lbl5.Text = "Число знаков";
            // 
            // _grpBox_numerics
            // 
            this._grpBox_numerics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpBox_numerics.Controls.Add(this._lbl11);
            this._grpBox_numerics.Controls.Add(this._lbl3);
            this._grpBox_numerics.Controls.Add(this._lbl12);
            this._grpBox_numerics.Controls.Add(this._lbl5);
            this._grpBox_numerics.Controls.Add(this._lbl13);
            this._grpBox_numerics.Controls.Add(this._lbl2);
            this._grpBox_numerics.Controls.Add(this._numYMin);
            this._grpBox_numerics.Controls.Add(this._numYMax);
            this._grpBox_numerics.Controls.Add(this._numDecimalPlaces);
            this._grpBox_numerics.Controls.Add(this._numYInterval);
            this._grpBox_numerics.Controls.Add(this._numXInterval);
            this._grpBox_numerics.Controls.Add(this._numXMax);
            this._grpBox_numerics.Controls.Add(this._lbl1);
            this._grpBox_numerics.Controls.Add(this._numXMin);
            this._grpBox_numerics.ForeColor = System.Drawing.Color.White;
            this._grpBox_numerics.Location = new System.Drawing.Point(465, 12);
            this._grpBox_numerics.Name = "_grpBox_numerics";
            this._grpBox_numerics.Size = new System.Drawing.Size(346, 169);
            this._grpBox_numerics.TabIndex = 24;
            this._grpBox_numerics.TabStop = false;
            this._grpBox_numerics.Text = "Настройки осей";
            // 
            // _grpBoxOther
            // 
            this._grpBoxOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpBoxOther.Controls.Add(this._rbAllGraph);
            this._grpBoxOther.Controls.Add(this._rbOneGraph);
            this._grpBoxOther.ForeColor = System.Drawing.Color.White;
            this._grpBoxOther.Location = new System.Drawing.Point(465, 297);
            this._grpBoxOther.Name = "_grpBoxOther";
            this._grpBoxOther.Size = new System.Drawing.Size(346, 62);
            this._grpBoxOther.TabIndex = 24;
            this._grpBoxOther.TabStop = false;
            this._grpBoxOther.Text = "Графики";
            // 
            // _rbAllGraph
            // 
            this._rbAllGraph.AutoSize = true;
            this._rbAllGraph.Location = new System.Drawing.Point(229, 25);
            this._rbAllGraph.Name = "_rbAllGraph";
            this._rbAllGraph.Size = new System.Drawing.Size(55, 24);
            this._rbAllGraph.TabIndex = 21;
            this._rbAllGraph.Text = "Все";
            this._rbAllGraph.UseVisualStyleBackColor = true;
            // 
            // _rbOneGraph
            // 
            this._rbOneGraph.AutoSize = true;
            this._rbOneGraph.Checked = true;
            this._rbOneGraph.Location = new System.Drawing.Point(77, 25);
            this._rbOneGraph.Name = "_rbOneGraph";
            this._rbOneGraph.Size = new System.Drawing.Size(86, 24);
            this._rbOneGraph.TabIndex = 22;
            this._rbOneGraph.TabStop = true;
            this._rbOneGraph.Text = "Лучший";
            this._rbOneGraph.UseVisualStyleBackColor = true;
            this._rbOneGraph.CheckedChanged += new System.EventHandler(this.OnRadioButtonChanged);
            // 
            // _chart
            // 
            this._chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Crossing = 0D;
            chartArea1.AxisX.Interval = 2.5D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 7.5D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.Interval = 0.2D;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this._chart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this._chart.Legends.Add(legend1);
            this._chart.Location = new System.Drawing.Point(12, 11);
            this._chart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._chart.Name = "_chart";
            this._chart.Size = new System.Drawing.Size(447, 409);
            this._chart.TabIndex = 0;
            this._chart.Text = "chart";
            this._chart.SizeChanged += new System.EventHandler(this.OnChartSizeChanged);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(822, 431);
            this.Controls.Add(this._grpBoxOther);
            this.Controls.Add(this._grpBox_numerics);
            this.Controls.Add(this._btnLineSettings);
            this.Controls.Add(this._btnSaveGraph);
            this.Controls.Add(this._grpBoxAxis);
            this.Controls.Add(this._chart);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChart";
            ((System.ComponentModel.ISupportInitialize)(this._numFontSize)).EndInit();
            this._grpBoxAxis.ResumeLayout(false);
            this._grpBoxAxis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numYMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numYInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numXInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numXMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numXMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDecimalPlaces)).EndInit();
            this._grpBox_numerics.ResumeLayout(false);
            this._grpBox_numerics.PerformLayout();
            this._grpBoxOther.ResumeLayout(false);
            this._grpBoxOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _btnSaveGraph;
        private System.Windows.Forms.Label _lbl8;
        private System.Windows.Forms.NumericUpDown _numFontSize;
        private System.Windows.Forms.Button _btnLineSettings;
        private System.Windows.Forms.CheckBox _chkItalics;
        private System.Windows.Forms.Label _lbl10;
        private System.Windows.Forms.TextBox _txtNameY;
        private System.Windows.Forms.Label _lbl9;
        private System.Windows.Forms.TextBox _txtNameX;
        private System.Windows.Forms.GroupBox _grpBoxAxis;
        private System.Windows.Forms.Label _lbl11;
        private System.Windows.Forms.Label _lbl12;
        private System.Windows.Forms.Label _lbl13;
        private System.Windows.Forms.NumericUpDown _numYMin;
        private System.Windows.Forms.NumericUpDown _numYMax;
        private System.Windows.Forms.NumericUpDown _numYInterval;
        private System.Windows.Forms.Label _lbl3;
        private System.Windows.Forms.Label _lbl2;
        private System.Windows.Forms.NumericUpDown _numXInterval;
        private System.Windows.Forms.Label _lbl1;
        private System.Windows.Forms.NumericUpDown _numXMin;
        private System.Windows.Forms.NumericUpDown _numXMax;
        private System.Windows.Forms.NumericUpDown _numDecimalPlaces;
        private System.Windows.Forms.Label _lbl5;
        private System.Windows.Forms.GroupBox _grpBox_numerics;
        private System.Windows.Forms.GroupBox _grpBoxOther;
        private System.Windows.Forms.RadioButton _rbAllGraph;
        private System.Windows.Forms.RadioButton _rbOneGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chart;
    }
}
