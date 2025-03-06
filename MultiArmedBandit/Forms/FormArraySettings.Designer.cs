namespace MultiArmedBandit
{
    partial class FormCollectionSettings
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
            this._numCount = new System.Windows.Forms.NumericUpDown();
            this._lbl8 = new System.Windows.Forms.Label();
            this._numStep = new System.Windows.Forms.NumericUpDown();
            this._lbl9 = new System.Windows.Forms.Label();
            this._numStart = new System.Windows.Forms.NumericUpDown();
            this._lbl10 = new System.Windows.Forms.Label();
            this._txtEndValue = new System.Windows.Forms.TextBox();
            this._lbl11 = new System.Windows.Forms.Label();
            this._lblTitle = new System.Windows.Forms.Label();
            this._btnApply = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._numCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numStart)).BeginInit();
            this.SuspendLayout();
            // 
            // _numCount
            // 
            this._numCount.Location = new System.Drawing.Point(231, 118);
            this._numCount.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._numCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this._numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numCount.Name = "_numCount";
            this._numCount.Size = new System.Drawing.Size(119, 29);
            this._numCount.TabIndex = 23;
            this._numCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numCount.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // _lbl8
            // 
            this._lbl8.AutoSize = true;
            this._lbl8.Location = new System.Drawing.Point(17, 46);
            this._lbl8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._lbl8.Name = "_lbl8";
            this._lbl8.Size = new System.Drawing.Size(202, 24);
            this._lbl8.TabIndex = 16;
            this._lbl8.Text = "Начальное значение:";
            // 
            // _numStep
            // 
            this._numStep.Location = new System.Drawing.Point(231, 81);
            this._numStep.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._numStep.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this._numStep.Name = "_numStep";
            this._numStep.Size = new System.Drawing.Size(119, 29);
            this._numStep.TabIndex = 22;
            this._numStep.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // _lbl9
            // 
            this._lbl9.AutoSize = true;
            this._lbl9.Location = new System.Drawing.Point(67, 83);
            this._lbl9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._lbl9.Name = "_lbl9";
            this._lbl9.Size = new System.Drawing.Size(152, 24);
            this._lbl9.TabIndex = 17;
            this._lbl9.Text = "Шаг изменения:";
            // 
            // _numStart
            // 
            this._numStart.Location = new System.Drawing.Point(231, 44);
            this._numStart.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this._numStart.Name = "_numStart";
            this._numStart.Size = new System.Drawing.Size(119, 29);
            this._numStart.TabIndex = 20;
            this._numStart.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // _lbl10
            // 
            this._lbl10.AutoSize = true;
            this._lbl10.Location = new System.Drawing.Point(48, 120);
            this._lbl10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._lbl10.Name = "_lbl10";
            this._lbl10.Size = new System.Drawing.Size(171, 24);
            this._lbl10.TabIndex = 18;
            this._lbl10.Text = "Число элементов:";
            // 
            // _txtEndValue
            // 
            this._txtEndValue.Location = new System.Drawing.Point(231, 152);
            this._txtEndValue.Margin = new System.Windows.Forms.Padding(6);
            this._txtEndValue.Name = "_txtEndValue";
            this._txtEndValue.ReadOnly = true;
            this._txtEndValue.Size = new System.Drawing.Size(119, 29);
            this._txtEndValue.TabIndex = 21;
            // 
            // _lbl11
            // 
            this._lbl11.AutoSize = true;
            this._lbl11.Location = new System.Drawing.Point(26, 155);
            this._lbl11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._lbl11.Name = "_lbl11";
            this._lbl11.Size = new System.Drawing.Size(193, 24);
            this._lbl11.TabIndex = 19;
            this._lbl11.Text = "Конечное значение:";
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Location = new System.Drawing.Point(14, 9);
            this._lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._lblTitle.MinimumSize = new System.Drawing.Size(350, 24);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(350, 24);
            this._lblTitle.TabIndex = 24;
            this._lblTitle.Text = "<НАЗВАНИЕ>";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnApply
            // 
            this._btnApply.Location = new System.Drawing.Point(18, 190);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(132, 37);
            this._btnApply.TabIndex = 25;
            this._btnApply.Text = "Применить";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this.OnApplyClick);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(218, 190);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(132, 37);
            this._btnCancel.TabIndex = 26;
            this._btnCancel.Text = "Отмена";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormCollectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(373, 243);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._numCount);
            this.Controls.Add(this._lbl8);
            this.Controls.Add(this._numStep);
            this.Controls.Add(this._lbl9);
            this.Controls.Add(this._numStart);
            this.Controls.Add(this._lbl10);
            this.Controls.Add(this._txtEndValue);
            this.Controls.Add(this._lbl11);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCollectionSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка массива";
            ((System.ComponentModel.ISupportInitialize)(this._numCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown _numCount;
        private System.Windows.Forms.Label _lbl8;
        private System.Windows.Forms.NumericUpDown _numStep;
        private System.Windows.Forms.Label _lbl9;
        private System.Windows.Forms.NumericUpDown _numStart;
        private System.Windows.Forms.Label _lbl10;
        private System.Windows.Forms.TextBox _txtEndValue;
        private System.Windows.Forms.Label _lbl11;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.Button _btnCancel;
    }
}