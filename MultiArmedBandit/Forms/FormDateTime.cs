using System;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormDateTime : Form
    {
        public FormDateTime()
        {
            InitializeComponent();
            OnTimerTick(null, null);

            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            _lblDate.Text = DateTime.Now.ToString("dddd") + Environment.NewLine + DateTime.Now.ToString("D");
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) =>
            _timer.Stop();
    }
}