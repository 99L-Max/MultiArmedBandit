using System;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormDateTime : Form
    {
        public FormDateTime()
        {
            InitializeComponent();
            OnTimerTick(_timer, EventArgs.Empty);

            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            _lblDate.Text = DateTime.Now.ToString("dddd") + Environment.NewLine + DateTime.Now.ToString("D");
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        { 
            _timer.Stop();
        }
    }
}