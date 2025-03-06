namespace MultiArmedBandit
{
    partial class FormInfo
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
            this._txtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _txtBox
            // 
            this._txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this._txtBox.ForeColor = System.Drawing.Color.White;
            this._txtBox.Location = new System.Drawing.Point(0, 0);
            this._txtBox.Multiline = true;
            this._txtBox.Name = "_txtBox";
            this._txtBox.ReadOnly = true;
            this._txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtBox.Size = new System.Drawing.Size(318, 217);
            this._txtBox.TabIndex = 1;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 217);
            this.Controls.Add(this._txtBox);
            this.Name = "FormInfo";
            this.Text = "FormInfo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox _txtBox;
    }
}