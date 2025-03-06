namespace MultiArmedBandit
{
    partial class FormLineSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._numNumberLine = new System.Windows.Forms.NumericUpDown();
            this._lbl1 = new System.Windows.Forms.Label();
            this._lbl2 = new System.Windows.Forms.Label();
            this._cmbBorderDashStyle = new System.Windows.Forms.ComboBox();
            this._lbl5 = new System.Windows.Forms.Label();
            this._numBorderWidth = new System.Windows.Forms.NumericUpDown();
            this._lbl4 = new System.Windows.Forms.Label();
            this._lbl6 = new System.Windows.Forms.Label();
            this._lbl7 = new System.Windows.Forms.Label();
            this._lbl8 = new System.Windows.Forms.Label();
            this._lbl9 = new System.Windows.Forms.Label();
            this._lbl10 = new System.Windows.Forms.Label();
            this._lbl11 = new System.Windows.Forms.Label();
            this._lbl12 = new System.Windows.Forms.Label();
            this._lbl13 = new System.Windows.Forms.Label();
            this._lbl14 = new System.Windows.Forms.Label();
            this._lbl15 = new System.Windows.Forms.Label();
            this._lbl16 = new System.Windows.Forms.Label();
            this._lbl17 = new System.Windows.Forms.Label();
            this._lbl18 = new System.Windows.Forms.Label();
            this._lbl19 = new System.Windows.Forms.Label();
            this._lbl20 = new System.Windows.Forms.Label();
            this._lbl21 = new System.Windows.Forms.Label();
            this._lbl22 = new System.Windows.Forms.Label();
            this._lbl23 = new System.Windows.Forms.Label();
            this._lbl24 = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            this._lblCurrentColor = new System.Windows.Forms.Label();
            this._lbl3 = new System.Windows.Forms.Label();
            this._numR = new System.Windows.Forms.NumericUpDown();
            this._numG = new System.Windows.Forms.NumericUpDown();
            this._lbl25 = new System.Windows.Forms.Label();
            this._numB = new System.Windows.Forms.NumericUpDown();
            this._lbl26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._numNumberLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numB)).BeginInit();
            this.SuspendLayout();
            // 
            // _numNumberLine
            // 
            this._numNumberLine.Location = new System.Drawing.Point(165, 9);
            this._numNumberLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numNumberLine.Name = "_numNumberLine";
            this._numNumberLine.Size = new System.Drawing.Size(56, 26);
            this._numNumberLine.TabIndex = 3;
            this._numNumberLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numNumberLine.ValueChanged += new System.EventHandler(this.OnLineChanged);
            // 
            // _lbl1
            // 
            this._lbl1.AutoSize = true;
            this._lbl1.Location = new System.Drawing.Point(26, 11);
            this._lbl1.Name = "_lbl1";
            this._lbl1.Size = new System.Drawing.Size(133, 20);
            this._lbl1.TabIndex = 4;
            this._lbl1.Text = "Номер графика:";
            // 
            // _lbl2
            // 
            this._lbl2.AutoSize = true;
            this._lbl2.Location = new System.Drawing.Point(7, 76);
            this._lbl2.Name = "_lbl2";
            this._lbl2.Size = new System.Drawing.Size(90, 20);
            this._lbl2.TabIndex = 5;
            this._lbl2.Text = "Тип линии:";
            // 
            // _cmbBorderDashStyle
            // 
            this._cmbBorderDashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbBorderDashStyle.FormattingEnabled = true;
            this._cmbBorderDashStyle.Location = new System.Drawing.Point(103, 73);
            this._cmbBorderDashStyle.Name = "_cmbBorderDashStyle";
            this._cmbBorderDashStyle.Size = new System.Drawing.Size(118, 28);
            this._cmbBorderDashStyle.TabIndex = 6;
            this._cmbBorderDashStyle.SelectedIndexChanged += new System.EventHandler(this.OnBorderDashStyleChanged);
            // 
            // _lbl5
            // 
            this._lbl5.AutoSize = true;
            this._lbl5.Location = new System.Drawing.Point(78, 43);
            this._lbl5.Name = "_lbl5";
            this._lbl5.Size = new System.Drawing.Size(81, 20);
            this._lbl5.TabIndex = 10;
            this._lbl5.Text = "Толщина:";
            // 
            // _numBorderWidth
            // 
            this._numBorderWidth.Location = new System.Drawing.Point(165, 41);
            this._numBorderWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numBorderWidth.Name = "_numBorderWidth";
            this._numBorderWidth.Size = new System.Drawing.Size(56, 26);
            this._numBorderWidth.TabIndex = 11;
            this._numBorderWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numBorderWidth.ValueChanged += new System.EventHandler(this.OnBorderWidthChanged);
            // 
            // _lbl4
            // 
            this._lbl4.AutoSize = true;
            this._lbl4.BackColor = System.Drawing.Color.Red;
            this._lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl4.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl4.Location = new System.Drawing.Point(150, 114);
            this._lbl4.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl4.Name = "_lbl4";
            this._lbl4.Size = new System.Drawing.Size(30, 30);
            this._lbl4.TabIndex = 32;
            this._lbl4.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl6
            // 
            this._lbl6.AutoSize = true;
            this._lbl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this._lbl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl6.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl6.Location = new System.Drawing.Point(186, 114);
            this._lbl6.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl6.Name = "_lbl6";
            this._lbl6.Size = new System.Drawing.Size(30, 30);
            this._lbl6.TabIndex = 33;
            this._lbl6.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl7
            // 
            this._lbl7.AutoSize = true;
            this._lbl7.BackColor = System.Drawing.Color.Green;
            this._lbl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl7.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl7.Location = new System.Drawing.Point(258, 114);
            this._lbl7.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl7.Name = "_lbl7";
            this._lbl7.Size = new System.Drawing.Size(30, 30);
            this._lbl7.TabIndex = 35;
            this._lbl7.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl8
            // 
            this._lbl8.AutoSize = true;
            this._lbl8.BackColor = System.Drawing.Color.Yellow;
            this._lbl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl8.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl8.Location = new System.Drawing.Point(222, 114);
            this._lbl8.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl8.Name = "_lbl8";
            this._lbl8.Size = new System.Drawing.Size(30, 30);
            this._lbl8.TabIndex = 34;
            this._lbl8.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl9
            // 
            this._lbl9.AutoSize = true;
            this._lbl9.BackColor = System.Drawing.Color.DeepSkyBlue;
            this._lbl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl9.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl9.Location = new System.Drawing.Point(294, 114);
            this._lbl9.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl9.Name = "_lbl9";
            this._lbl9.Size = new System.Drawing.Size(30, 30);
            this._lbl9.TabIndex = 36;
            this._lbl9.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl10
            // 
            this._lbl10.AutoSize = true;
            this._lbl10.BackColor = System.Drawing.Color.Maroon;
            this._lbl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl10.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl10.Location = new System.Drawing.Point(114, 114);
            this._lbl10.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl10.Name = "_lbl10";
            this._lbl10.Size = new System.Drawing.Size(30, 30);
            this._lbl10.TabIndex = 41;
            this._lbl10.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl11
            // 
            this._lbl11.AutoSize = true;
            this._lbl11.BackColor = System.Drawing.Color.Gray;
            this._lbl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl11.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl11.Location = new System.Drawing.Point(78, 114);
            this._lbl11.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl11.Name = "_lbl11";
            this._lbl11.Size = new System.Drawing.Size(30, 30);
            this._lbl11.TabIndex = 40;
            this._lbl11.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl12
            // 
            this._lbl12.AutoSize = true;
            this._lbl12.BackColor = System.Drawing.Color.Black;
            this._lbl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl12.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl12.Location = new System.Drawing.Point(42, 114);
            this._lbl12.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl12.Name = "_lbl12";
            this._lbl12.Size = new System.Drawing.Size(30, 30);
            this._lbl12.TabIndex = 39;
            this._lbl12.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl13
            // 
            this._lbl13.AutoSize = true;
            this._lbl13.BackColor = System.Drawing.Color.Purple;
            this._lbl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl13.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl13.Location = new System.Drawing.Point(366, 114);
            this._lbl13.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl13.Name = "_lbl13";
            this._lbl13.Size = new System.Drawing.Size(30, 30);
            this._lbl13.TabIndex = 38;
            this._lbl13.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl14
            // 
            this._lbl14.AutoSize = true;
            this._lbl14.BackColor = System.Drawing.Color.Blue;
            this._lbl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl14.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl14.Location = new System.Drawing.Point(330, 114);
            this._lbl14.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl14.Name = "_lbl14";
            this._lbl14.Size = new System.Drawing.Size(30, 30);
            this._lbl14.TabIndex = 37;
            this._lbl14.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl15
            // 
            this._lbl15.AutoSize = true;
            this._lbl15.BackColor = System.Drawing.Color.Peru;
            this._lbl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl15.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl15.Location = new System.Drawing.Point(114, 153);
            this._lbl15.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl15.Name = "_lbl15";
            this._lbl15.Size = new System.Drawing.Size(30, 30);
            this._lbl15.TabIndex = 51;
            this._lbl15.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl16
            // 
            this._lbl16.AutoSize = true;
            this._lbl16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._lbl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl16.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl16.Location = new System.Drawing.Point(78, 153);
            this._lbl16.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl16.Name = "_lbl16";
            this._lbl16.Size = new System.Drawing.Size(30, 30);
            this._lbl16.TabIndex = 50;
            this._lbl16.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl17
            // 
            this._lbl17.AutoSize = true;
            this._lbl17.BackColor = System.Drawing.Color.White;
            this._lbl17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl17.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl17.Location = new System.Drawing.Point(42, 153);
            this._lbl17.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl17.Name = "_lbl17";
            this._lbl17.Size = new System.Drawing.Size(30, 30);
            this._lbl17.TabIndex = 49;
            this._lbl17.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl18
            // 
            this._lbl18.AutoSize = true;
            this._lbl18.BackColor = System.Drawing.Color.MediumOrchid;
            this._lbl18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl18.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl18.Location = new System.Drawing.Point(366, 153);
            this._lbl18.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl18.Name = "_lbl18";
            this._lbl18.Size = new System.Drawing.Size(30, 30);
            this._lbl18.TabIndex = 48;
            this._lbl18.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl19
            // 
            this._lbl19.AutoSize = true;
            this._lbl19.BackColor = System.Drawing.Color.CornflowerBlue;
            this._lbl19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl19.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl19.Location = new System.Drawing.Point(330, 153);
            this._lbl19.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl19.Name = "_lbl19";
            this._lbl19.Size = new System.Drawing.Size(30, 30);
            this._lbl19.TabIndex = 47;
            this._lbl19.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl20
            // 
            this._lbl20.AutoSize = true;
            this._lbl20.BackColor = System.Drawing.Color.Cyan;
            this._lbl20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl20.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl20.Location = new System.Drawing.Point(294, 153);
            this._lbl20.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl20.Name = "_lbl20";
            this._lbl20.Size = new System.Drawing.Size(30, 30);
            this._lbl20.TabIndex = 46;
            this._lbl20.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl21
            // 
            this._lbl21.AutoSize = true;
            this._lbl21.BackColor = System.Drawing.Color.Lime;
            this._lbl21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl21.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl21.Location = new System.Drawing.Point(258, 153);
            this._lbl21.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl21.Name = "_lbl21";
            this._lbl21.Size = new System.Drawing.Size(30, 30);
            this._lbl21.TabIndex = 45;
            this._lbl21.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl22
            // 
            this._lbl22.AutoSize = true;
            this._lbl22.BackColor = System.Drawing.Color.LemonChiffon;
            this._lbl22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl22.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl22.Location = new System.Drawing.Point(222, 153);
            this._lbl22.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl22.Name = "_lbl22";
            this._lbl22.Size = new System.Drawing.Size(30, 30);
            this._lbl22.TabIndex = 44;
            this._lbl22.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl23
            // 
            this._lbl23.AutoSize = true;
            this._lbl23.BackColor = System.Drawing.Color.Gold;
            this._lbl23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl23.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl23.Location = new System.Drawing.Point(186, 153);
            this._lbl23.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl23.Name = "_lbl23";
            this._lbl23.Size = new System.Drawing.Size(30, 30);
            this._lbl23.TabIndex = 43;
            this._lbl23.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _lbl24
            // 
            this._lbl24.AutoSize = true;
            this._lbl24.BackColor = System.Drawing.Color.Fuchsia;
            this._lbl24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbl24.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbl24.Location = new System.Drawing.Point(150, 153);
            this._lbl24.MinimumSize = new System.Drawing.Size(30, 30);
            this._lbl24.Name = "_lbl24";
            this._lbl24.Size = new System.Drawing.Size(30, 30);
            this._lbl24.TabIndex = 42;
            this._lbl24.Click += new System.EventHandler(this.OnColorClick);
            // 
            // _btnOK
            // 
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnOK.Location = new System.Drawing.Point(150, 186);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(138, 35);
            this._btnOK.TabIndex = 62;
            this._btnOK.Text = "ОК";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _lblCurrentColor
            // 
            this._lblCurrentColor.AutoSize = true;
            this._lblCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblCurrentColor.Location = new System.Drawing.Point(234, 9);
            this._lblCurrentColor.MinimumSize = new System.Drawing.Size(95, 95);
            this._lblCurrentColor.Name = "_lblCurrentColor";
            this._lblCurrentColor.Size = new System.Drawing.Size(95, 95);
            this._lblCurrentColor.TabIndex = 63;
            // 
            // _lbl3
            // 
            this._lbl3.AutoSize = true;
            this._lbl3.Location = new System.Drawing.Point(335, 13);
            this._lbl3.Name = "_lbl3";
            this._lbl3.Size = new System.Drawing.Size(25, 20);
            this._lbl3.TabIndex = 64;
            this._lbl3.Text = "R:";
            // 
            // _numR
            // 
            this._numR.Location = new System.Drawing.Point(366, 11);
            this._numR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numR.Name = "_numR";
            this._numR.Size = new System.Drawing.Size(57, 26);
            this._numR.TabIndex = 65;
            this._numR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numR.ValueChanged += new System.EventHandler(this.OnRGBChanged);
            // 
            // _numG
            // 
            this._numG.Location = new System.Drawing.Point(366, 43);
            this._numG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numG.Name = "_numG";
            this._numG.Size = new System.Drawing.Size(57, 26);
            this._numG.TabIndex = 67;
            this._numG.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numG.ValueChanged += new System.EventHandler(this.OnRGBChanged);
            // 
            // _lbl25
            // 
            this._lbl25.AutoSize = true;
            this._lbl25.Location = new System.Drawing.Point(334, 45);
            this._lbl25.Name = "_lbl25";
            this._lbl25.Size = new System.Drawing.Size(26, 20);
            this._lbl25.TabIndex = 66;
            this._lbl25.Text = "G:";
            // 
            // _numB
            // 
            this._numB.Location = new System.Drawing.Point(366, 75);
            this._numB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numB.Name = "_numB";
            this._numB.Size = new System.Drawing.Size(57, 26);
            this._numB.TabIndex = 69;
            this._numB.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numB.ValueChanged += new System.EventHandler(this.OnRGBChanged);
            // 
            // _lbl26
            // 
            this._lbl26.AutoSize = true;
            this._lbl26.Location = new System.Drawing.Point(337, 77);
            this._lbl26.Name = "_lbl26";
            this._lbl26.Size = new System.Drawing.Size(24, 20);
            this._lbl26.TabIndex = 68;
            this._lbl26.Text = "B:";
            // 
            // FormLineSettings
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnOK;
            this.ClientSize = new System.Drawing.Size(438, 230);
            this.Controls.Add(this._numB);
            this.Controls.Add(this._lbl26);
            this.Controls.Add(this._numG);
            this.Controls.Add(this._lbl25);
            this.Controls.Add(this._numR);
            this.Controls.Add(this._lbl3);
            this.Controls.Add(this._lblCurrentColor);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._lbl15);
            this.Controls.Add(this._lbl16);
            this.Controls.Add(this._lbl17);
            this.Controls.Add(this._lbl18);
            this.Controls.Add(this._lbl19);
            this.Controls.Add(this._lbl20);
            this.Controls.Add(this._lbl21);
            this.Controls.Add(this._lbl22);
            this.Controls.Add(this._lbl23);
            this.Controls.Add(this._lbl24);
            this.Controls.Add(this._lbl10);
            this.Controls.Add(this._lbl11);
            this.Controls.Add(this._lbl12);
            this.Controls.Add(this._lbl13);
            this.Controls.Add(this._lbl14);
            this.Controls.Add(this._lbl9);
            this.Controls.Add(this._lbl7);
            this.Controls.Add(this._lbl8);
            this.Controls.Add(this._lbl6);
            this.Controls.Add(this._lbl4);
            this.Controls.Add(this._numBorderWidth);
            this.Controls.Add(this._lbl5);
            this.Controls.Add(this._cmbBorderDashStyle);
            this.Controls.Add(this._lbl2);
            this.Controls.Add(this._lbl1);
            this.Controls.Add(this._numNumberLine);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLineSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки линии";
            ((System.ComponentModel.ISupportInitialize)(this._numNumberLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown _numNumberLine;
        private System.Windows.Forms.Label _lbl1;
        private System.Windows.Forms.Label _lbl2;
        private System.Windows.Forms.ComboBox _cmbBorderDashStyle;
        private System.Windows.Forms.Label _lbl5;
        private System.Windows.Forms.NumericUpDown _numBorderWidth;
        private System.Windows.Forms.Label _lbl4;
        private System.Windows.Forms.Label _lbl6;
        private System.Windows.Forms.Label _lbl7;
        private System.Windows.Forms.Label _lbl8;
        private System.Windows.Forms.Label _lbl9;
        private System.Windows.Forms.Label _lbl10;
        private System.Windows.Forms.Label _lbl11;
        private System.Windows.Forms.Label _lbl12;
        private System.Windows.Forms.Label _lbl13;
        private System.Windows.Forms.Label _lbl14;
        private System.Windows.Forms.Label _lbl15;
        private System.Windows.Forms.Label _lbl16;
        private System.Windows.Forms.Label _lbl17;
        private System.Windows.Forms.Label _lbl18;
        private System.Windows.Forms.Label _lbl19;
        private System.Windows.Forms.Label _lbl20;
        private System.Windows.Forms.Label _lbl21;
        private System.Windows.Forms.Label _lbl22;
        private System.Windows.Forms.Label _lbl23;
        private System.Windows.Forms.Label _lbl24;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Label _lblCurrentColor;
        private System.Windows.Forms.Label _lbl3;
        private System.Windows.Forms.NumericUpDown _numR;
        private System.Windows.Forms.NumericUpDown _numG;
        private System.Windows.Forms.Label _lbl25;
        private System.Windows.Forms.NumericUpDown _numB;
        private System.Windows.Forms.Label _lbl26;
    }
}