namespace MultiArmedBandit
{
    partial class FormDataSave
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
            this._btnSaveAll = new System.Windows.Forms.Button();
            this._btnSaveStringTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnSaveAll
            // 
            this._btnSaveAll.BackColor = System.Drawing.Color.White;
            this._btnSaveAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnSaveAll.ForeColor = System.Drawing.Color.Black;
            this._btnSaveAll.Location = new System.Drawing.Point(15, 15);
            this._btnSaveAll.Margin = new System.Windows.Forms.Padding(6);
            this._btnSaveAll.Name = "_btnSaveAll";
            this._btnSaveAll.Size = new System.Drawing.Size(233, 45);
            this._btnSaveAll.TabIndex = 8;
            this._btnSaveAll.Text = "Сохранить всё";
            this._btnSaveAll.UseVisualStyleBackColor = false;
            this._btnSaveAll.Click += new System.EventHandler(this.OnSaveAllClick);
            // 
            // _btnSaveStringTable
            // 
            this._btnSaveStringTable.BackColor = System.Drawing.Color.White;
            this._btnSaveStringTable.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this._btnSaveStringTable.ForeColor = System.Drawing.Color.Black;
            this._btnSaveStringTable.Location = new System.Drawing.Point(15, 72);
            this._btnSaveStringTable.Margin = new System.Windows.Forms.Padding(6);
            this._btnSaveStringTable.Name = "_btnSaveStringTable";
            this._btnSaveStringTable.Size = new System.Drawing.Size(233, 45);
            this._btnSaveStringTable.TabIndex = 9;
            this._btnSaveStringTable.Text = "Сохранить таблицей";
            this._btnSaveStringTable.UseVisualStyleBackColor = false;
            this._btnSaveStringTable.Click += new System.EventHandler(this.OnSaveStringTableClick);
            // 
            // FormDataSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 128);
            this.Controls.Add(this._btnSaveStringTable);
            this.Controls.Add(this._btnSaveAll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDataSave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохранение данных";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnSaveAll;
        private System.Windows.Forms.Button _btnSaveStringTable;
    }
}