using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiArmedBandit
{
    partial class FormLineSettings : Form
    {
        private readonly SeriesCollection _series;

        private int _selectedIndex = 0;
        private bool _isUserChangeValue = true;

        public FormLineSettings(SeriesCollection series)
        {
            InitializeComponent();


            _series = series;
            _numNumberLine.Maximum = _series.Count;

            var seriesStyles = EnumFactory.GetEnumString<ChartDashStyle>().ToArray();
            _cmbBorderDashStyle.Items.AddRange(seriesStyles);
            _cmbBorderDashStyle.SelectedIndex = (int)series.First().BorderDashStyle;

            OnLineChanged(_numNumberLine, EventArgs.Empty);
        }

        private void SetColorLineOnForm()
        {
            _lblCurrentColor.BackColor = _series[_selectedIndex].Color;

            _isUserChangeValue = false;

            _numRed.Value = _lblCurrentColor.BackColor.R;
            _numGreen.Value = _lblCurrentColor.BackColor.G;
            _numBlue.Value = _lblCurrentColor.BackColor.B;

            _isUserChangeValue = true;
        }

        private void OnLineChanged(object sender, EventArgs e)
        {
            _selectedIndex = (int)_numNumberLine.Value - 1;
            _numBorderWidth.Value = _series[_selectedIndex].BorderWidth;
            _cmbBorderDashStyle.SelectedIndex = Convert.ToInt32(_series[_selectedIndex].BorderDashStyle != ChartDashStyle.Solid);

            SetColorLineOnForm();
        }

        private void OnBorderDashStyleChanged(object sender, EventArgs e)
        {
            _series[_selectedIndex].BorderDashStyle = (ChartDashStyle)_cmbBorderDashStyle.SelectedIndex;
        }

        private void OnBorderWidthChanged(object sender, EventArgs e)
        {
            _series[_selectedIndex].BorderWidth = (int)_numBorderWidth.Value;
        }

        private void OnColorClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                _series[_selectedIndex].Color = label.BackColor;
                SetColorLineOnForm();
            }
        }

        private void OnRGBChanged(object sender, EventArgs e)
        {
            if (_isUserChangeValue)
            {
                _lblCurrentColor.BackColor = Color.FromArgb((int)_numRed.Value, (int)_numGreen.Value, (int)_numBlue.Value);
                _series[_selectedIndex].Color = _lblCurrentColor.BackColor;
            }
        }
    }
}
