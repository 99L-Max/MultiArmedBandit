namespace MultiArmedBandit
{
    partial class FormDateTime
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
            this.components = new System.ComponentModel.Container();
            this._pbLogo = new System.Windows.Forms.PictureBox();
            this._lblDate = new System.Windows.Forms.Label();
            this._lblTime = new System.Windows.Forms.Label();
            this._lblTitle = new System.Windows.Forms.Label();
            this._timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // _pbLogo
            // 
            this._pbLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._pbLogo.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Logo;
            this._pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pbLogo.Location = new System.Drawing.Point(273, 87);
            this._pbLogo.Name = "_pbLogo";
            this._pbLogo.Size = new System.Drawing.Size(160, 160);
            this._pbLogo.TabIndex = 0;
            this._pbLogo.TabStop = false;
            // 
            // _lblDate
            // 
            this._lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._lblDate.AutoSize = true;
            this._lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this._lblDate.ForeColor = System.Drawing.Color.White;
            this._lblDate.Location = new System.Drawing.Point(223, 345);
            this._lblDate.MaximumSize = new System.Drawing.Size(260, 65);
            this._lblDate.MinimumSize = new System.Drawing.Size(260, 65);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(260, 65);
            this._lblDate.TabIndex = 2;
            this._lblDate.Text = "Понедельник\n01 Января 0000 г.";
            this._lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblTime
            // 
            this._lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._lblTime.AutoSize = true;
            this._lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblTime.ForeColor = System.Drawing.Color.White;
            this._lblTime.Location = new System.Drawing.Point(204, 280);
            this._lblTime.MaximumSize = new System.Drawing.Size(300, 65);
            this._lblTime.MinimumSize = new System.Drawing.Size(300, 65);
            this._lblTime.Name = "_lblTime";
            this._lblTime.Size = new System.Drawing.Size(300, 65);
            this._lblTime.TabIndex = 3;
            this._lblTime.Text = "00:00:00";
            this._lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblTitle
            // 
            this._lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.White;
            this._lblTitle.Location = new System.Drawing.Point(223, 250);
            this._lblTitle.MaximumSize = new System.Drawing.Size(260, 30);
            this._lblTitle.MinimumSize = new System.Drawing.Size(260, 30);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(260, 30);
            this._lblTitle.TabIndex = 4;
            this._lblTitle.Text = "Многорукий бандит";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // FormDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(707, 482);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._lblTime);
            this.Controls.Add(this._lblDate);
            this.Controls.Add(this._pbLogo);
            this.Name = "FormDateTime";
            this.Text = "FormDateTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbLogo;
        private System.Windows.Forms.Label _lblDate;
        private System.Windows.Forms.Label _lblTime;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Timer _timer;
    }
}