namespace MultiArmedBandit
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._strategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlDesctopPanel = new System.Windows.Forms.Panel();
            this._pnlResize = new System.Windows.Forms.Panel();
            this._pnlFrame = new System.Windows.Forms.Panel();
            this._btnMinimaze = new System.Windows.Forms.Button();
            this._btnResize = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._lblTitle = new System.Windows.Forms.Label();
            this._menuStrip.SuspendLayout();
            this._pnlDesctopPanel.SuspendLayout();
            this._pnlFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.BackColor = System.Drawing.Color.Indigo;
            this._menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this._menuStrip.Font = new System.Drawing.Font("Segoe UI", 14F);
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mainToolStripMenuItem,
            this._calculateToolStripMenuItem,
            this._graphToolStripMenuItem,
            this._strategyToolStripMenuItem,
            this._aboutProgramToolStripMenuItem,
            this._exitToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(205, 521);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip";
            this._menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnMenuStripClicked);
            // 
            // _mainToolStripMenuItem
            // 
            this._mainToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this._mainToolStripMenuItem.Image = global::MultiArmedBandit.Properties.Resources.Main;
            this._mainToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._mainToolStripMenuItem.Name = "_mainToolStripMenuItem";
            this._mainToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 25, 4, 0);
            this._mainToolStripMenuItem.Size = new System.Drawing.Size(192, 61);
            this._mainToolStripMenuItem.Text = "Главная";
            this._mainToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._mainToolStripMenuItem.Click += new System.EventHandler(this.OnMainToolClick);
            // 
            // _calculateToolStripMenuItem
            // 
            this._calculateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this._calculateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this._calculateToolStripMenuItem.Image = global::MultiArmedBandit.Properties.Resources.Calculate;
            this._calculateToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._calculateToolStripMenuItem.Name = "_calculateToolStripMenuItem";
            this._calculateToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 25, 4, 0);
            this._calculateToolStripMenuItem.Size = new System.Drawing.Size(192, 61);
            this._calculateToolStripMenuItem.Text = "Моделирование";
            this._calculateToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._calculateToolStripMenuItem.Click += new System.EventHandler(this.OnCalculateClick);
            // 
            // _graphToolStripMenuItem
            // 
            this._graphToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this._graphToolStripMenuItem.Image = global::MultiArmedBandit.Properties.Resources.Graph;
            this._graphToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._graphToolStripMenuItem.Name = "_graphToolStripMenuItem";
            this._graphToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 25, 4, 0);
            this._graphToolStripMenuItem.Size = new System.Drawing.Size(192, 61);
            this._graphToolStripMenuItem.Text = "График";
            this._graphToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._graphToolStripMenuItem.Click += new System.EventHandler(this.OnChartClick);
            // 
            // _strategyToolStripMenuItem
            // 
            this._strategyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this._strategyToolStripMenuItem.Image = global::MultiArmedBandit.Properties.Resources.Strategy;
            this._strategyToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._strategyToolStripMenuItem.Name = "_strategyToolStripMenuItem";
            this._strategyToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 25, 4, 0);
            this._strategyToolStripMenuItem.Size = new System.Drawing.Size(192, 61);
            this._strategyToolStripMenuItem.Text = "Стратегия";
            this._strategyToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._strategyToolStripMenuItem.Click += new System.EventHandler(this.OnAboutStrategyClick);
            // 
            // _aboutProgramToolStripMenuItem
            // 
            this._aboutProgramToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this._aboutProgramToolStripMenuItem.Image = global::MultiArmedBandit.Properties.Resources.AboutProgramm;
            this._aboutProgramToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._aboutProgramToolStripMenuItem.Name = "_aboutProgramToolStripMenuItem";
            this._aboutProgramToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 25, 4, 0);
            this._aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(192, 61);
            this._aboutProgramToolStripMenuItem.Text = "О программе";
            this._aboutProgramToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.OnAboutProgramClick);
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this._exitToolStripMenuItem.Image = global::MultiArmedBandit.Properties.Resources.Exit;
            this._exitToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(192, 36);
            this._exitToolStripMenuItem.Text = "Выход";
            this._exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // _pnlDesctopPanel
            // 
            this._pnlDesctopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlDesctopPanel.Controls.Add(this._pnlResize);
            this._pnlDesctopPanel.Location = new System.Drawing.Point(205, 70);
            this._pnlDesctopPanel.Name = "_pnlDesctopPanel";
            this._pnlDesctopPanel.Padding = new System.Windows.Forms.Padding(4, 25, 4, 0);
            this._pnlDesctopPanel.Size = new System.Drawing.Size(583, 451);
            this._pnlDesctopPanel.TabIndex = 1;
            // 
            // _pnlResize
            // 
            this._pnlResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlResize.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Resize;
            this._pnlResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._pnlResize.Location = new System.Drawing.Point(548, 416);
            this._pnlResize.Name = "_pnlResize";
            this._pnlResize.Size = new System.Drawing.Size(35, 35);
            this._pnlResize.TabIndex = 0;
            this._pnlResize.Visible = false;
            this._pnlResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelResizeMouseDown);
            this._pnlResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelResizeMouseMove);
            this._pnlResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelResizeMouseUp);
            // 
            // _pnlFrame
            // 
            this._pnlFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlFrame.BackColor = System.Drawing.Color.MediumSlateBlue;
            this._pnlFrame.Controls.Add(this._btnMinimaze);
            this._pnlFrame.Controls.Add(this._btnResize);
            this._pnlFrame.Controls.Add(this._btnClose);
            this._pnlFrame.Controls.Add(this._lblTitle);
            this._pnlFrame.Location = new System.Drawing.Point(205, 0);
            this._pnlFrame.Name = "_pnlFrame";
            this._pnlFrame.Size = new System.Drawing.Size(583, 70);
            this._pnlFrame.TabIndex = 3;
            this._pnlFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelFrameMouseDown);
            this._pnlFrame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelFrameMouseMove);
            this._pnlFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelFrameMouseUp);
            // 
            // _btnMinimaze
            // 
            this._btnMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMinimaze.BackColor = System.Drawing.Color.MediumSlateBlue;
            this._btnMinimaze.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Minimize;
            this._btnMinimaze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnMinimaze.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this._btnMinimaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMinimaze.Location = new System.Drawing.Point(463, 3);
            this._btnMinimaze.Name = "_btnMinimaze";
            this._btnMinimaze.Size = new System.Drawing.Size(35, 35);
            this._btnMinimaze.TabIndex = 3;
            this._btnMinimaze.UseVisualStyleBackColor = false;
            this._btnMinimaze.Click += new System.EventHandler(this.OnButtonMinimizeClick);
            // 
            // _btnResize
            // 
            this._btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnResize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this._btnResize.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Resize_Min;
            this._btnResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnResize.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this._btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnResize.Location = new System.Drawing.Point(504, 3);
            this._btnResize.Name = "_btnResize";
            this._btnResize.Size = new System.Drawing.Size(35, 35);
            this._btnResize.TabIndex = 2;
            this._btnResize.UseVisualStyleBackColor = false;
            this._btnResize.Click += new System.EventHandler(this.OnButtonResizeClick);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.BackColor = System.Drawing.Color.MediumSlateBlue;
            this._btnClose.BackgroundImage = global::MultiArmedBandit.Properties.Resources.Close;
            this._btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnClose.Location = new System.Drawing.Point(545, 3);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(35, 35);
            this._btnClose.TabIndex = 1;
            this._btnClose.UseVisualStyleBackColor = false;
            this._btnClose.Click += new System.EventHandler(this.OnExitClick);
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this._lblTitle.ForeColor = System.Drawing.Color.White;
            this._lblTitle.Location = new System.Drawing.Point(23, 18);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(118, 31);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Главная";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(788, 521);
            this.Controls.Add(this._pnlFrame);
            this.Controls.Add(this._pnlDesctopPanel);
            this.Controls.Add(this._menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = Properties.Resources.Icon;
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(105, 35);
            this.Name = "FormMain";
            this.Text = "Многорукий бандит";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._pnlDesctopPanel.ResumeLayout(false);
            this._pnlFrame.ResumeLayout(false);
            this._pnlFrame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _calculateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutProgramToolStripMenuItem;
        private System.Windows.Forms.Panel _pnlDesctopPanel;
        private System.Windows.Forms.ToolStripMenuItem _mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _strategyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.Panel _pnlFrame;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Button _btnMinimaze;
        private System.Windows.Forms.Button _btnResize;
        private System.Windows.Forms.Panel _pnlResize;
    }
}