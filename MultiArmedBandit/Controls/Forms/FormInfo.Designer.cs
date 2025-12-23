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
            this._richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _richTextBox
            // 
            this._richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._richTextBox.ForeColor = System.Drawing.Color.White;
            this._richTextBox.Location = new System.Drawing.Point(0, 0);
            this._richTextBox.Name = "_richTextBox";
            this._richTextBox.ReadOnly = true;
            this._richTextBox.Size = new System.Drawing.Size(318, 217);
            this._richTextBox.TabIndex = 0;
            this._richTextBox.Text = "";
            this._richTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.OnRichTextBoxLinkClicked);
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 217);
            this.Controls.Add(this._richTextBox);
            this.Name = "FormInfo";
            this.Text = "FormInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _richTextBox;
    }
}