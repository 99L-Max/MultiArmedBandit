using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    public partial class Notification : Form
    {
        private readonly int _lifeTime;
        private readonly double _hoveredOpacity;
        private readonly double _regularOpacity;

        private NotificationAction _action;
        private int _positionX, _positionY;

        public Notification(int lifeTime = 3000, double hoveredOpacity = 1d, double regularOpacity = 0.6)
        {
            InitializeComponent();

            _lifeTime = lifeTime < 0 ? 0 : lifeTime;

            _hoveredOpacity = hoveredOpacity;
            _regularOpacity = regularOpacity;
        }

        public void ShowNotification(string message)
        {
            var formName = string.Empty;
            var deltaArea = 5;
            var usedHeight = 0;

            for (int i = 1; i < 99; i++)
            {
                formName = "NotificationForm_" + i;
                var frm = (Notification)Application.OpenForms[formName];

                if (frm == null)
                {
                    Name = formName;

                    _positionX = Screen.PrimaryScreen.WorkingArea.Width - Width - deltaArea;
                    _positionY = Screen.PrimaryScreen.WorkingArea.Height - usedHeight - Height - deltaArea;

                    if (_positionY < 0) return;

                    Location = new Point(_positionX, _positionY);
                    break;
                }

                usedHeight += frm.Height + deltaArea;
            }

            _lblMessage.Text = message;

            Show();

            _action = NotificationAction.Started;

            _backgroundWorker.RunWorkerAsync();
        }

        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_action == NotificationAction.Closed && _lifeTime > 0)
                Close();
        }

        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (_action == NotificationAction.Started)
            {
                foreach (Control ctrl in Controls)
                {
                    ctrl.MouseEnter += OnNotificationMouseEnter;
                    ctrl.MouseLeave += OnNotificationMouseLeave;
                }

                while (Opacity < _regularOpacity)
                {
                    Invoke(new Action(() => { Opacity += 0.03; }));
                    Thread.Sleep(10);
                }

                _action = NotificationAction.Active;
            }

            if (_action == NotificationAction.Active)
            {
                Thread.Sleep(_lifeTime);
                _action = NotificationAction.Closed;
            }

            if (_action == NotificationAction.Closed && _lifeTime > 0)
            {
                while (Opacity > 0d)
                {
                    Invoke(new Action(() =>
                    {
                        Opacity -= 0.03;
                        Left -= 3;
                    }));
                    Thread.Sleep(10);
                }
            }
        }

        private void OnNotificationMouseLeave(object sender, EventArgs e)
        {
            try { Opacity = _regularOpacity; }
            catch (Exception) { }
        }

        private void OnNotificationMouseEnter(object sender, EventArgs e) =>
            Opacity = _hoveredOpacity;

        private void OnCloseButtonClick(object sender, EventArgs e) =>
            Close();
    }
}
