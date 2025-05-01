using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormInfo : Form
    {
        public FormInfo(string rtfText, Color backColor)
        {
            InitializeComponent();

            _richTextBox.BackColor = backColor;
            _richTextBox.SelectedRtf = rtfText;

            _richTextBox.SelectionColor = _richTextBox.ForeColor;
            _richTextBox.SelectAll();
            _richTextBox.SelectionColor = _richTextBox.ForeColor;
            _richTextBox.DeselectAll();
        }

        private void OnRichTextBoxLinkClicked(object sender, LinkClickedEventArgs e) =>
            Process.Start(e.LinkText);
    }
}