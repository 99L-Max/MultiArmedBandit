using System.ComponentModel;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class Notification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.CloseButton = new System.Windows.Forms.Button();
            this._lblMessage = new System.Windows.Forms.Label();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Button_Close;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(620, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.MinimumSize = new System.Drawing.Size(40, 40);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(40, 40);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.OnCloseButtonClick);
            // 
            // _lblMessage
            // 
            this._lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblMessage.ForeColor = System.Drawing.Color.White;
            this._lblMessage.Location = new System.Drawing.Point(0, 0);
            this._lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(660, 125);
            this._lblMessage.TabIndex = 2;
            this._lblMessage.Text = "Сообщение для пользователя";
            this._lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _backgroundWorker
            // 
            this._backgroundWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnBackgroundWorkerDoWork);
            this._backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnBackgroundWorkerRunWorkerCompleted);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(660, 125);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this._lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private Button CloseButton;
        private Label _lblMessage;
        private BackgroundWorker _backgroundWorker;
    }
}