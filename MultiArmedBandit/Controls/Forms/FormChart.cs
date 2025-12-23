using MultiArmedBandit.Structs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiArmedBandit
{
    partial class FormChart : Form
    {
        private readonly Size _aspectRatioChart = new Size(16, 9);
        private readonly ColorsFactory _colorsFactory = new ColorsFactory();

        private int _indexMainSeries;

        public FormChart()
        {
            InitializeComponent();
            OnDecimalPlacesChanged(_numDecimalPlaces, EventArgs.Empty);
            OnFontAxisChanged(_numFontSize, EventArgs.Empty);
        }

        public void BuildChart(IEnumerable<Regret[]> regrets)
        {
            _chart.Series.Clear();
            
            for (int i = 0; i < regrets.Count(); i++)
            {
                Series series = new Series
                {
                    BorderWidth = 3,
                    ChartType = SeriesChartType.Spline,
                    Color = _colorsFactory.GetColor(i)
                };

                foreach (var regret in regrets.ElementAt(i))
                    series.Points.AddXY(regret.Deviation, regret.Value);

                _chart.Series.Add(series);
            }

            _indexMainSeries = CollectionHandler.GetIndexMinMax(regrets);

            CollectionHandler.FindMinMax(regrets, out double minDeviation, out double maxDeviation, out double minRegret, out double maxRegret);

            var decimalPlaces = (int)_numDecimalPlaces.Value;

            var xMin = (decimal)Math.Round(minDeviation, decimalPlaces);
            var xMax = (decimal)Math.Round(maxDeviation, decimalPlaces);
            var yMin = (decimal)Math.Floor(minRegret);
            var yMax = (decimal)Math.Ceiling(maxRegret);

            SetNumericsBounds(xMin, xMax, yMin, yMax);
            OnRadioButtonChanged(_rbOneGraph, EventArgs.Empty);
            Enabled = true;
        }

        public void ClearChart()
        {
            Enabled = false;

            _chart.Series.Clear();

            _numXMin.ValueChanged -= OnXMinChanged;
            _numXMax.ValueChanged -= OnXMaxChanged;

            _numYMin.ValueChanged -= OnYMinChanged;
            _numYMax.ValueChanged -= OnYMaxChanged;

            _numXInterval.ValueChanged -= OnXIntervalChanged;
            _numYInterval.ValueChanged -= OnYIntervalChanged;
        }

        private void SetNumericsBounds(decimal xMin, decimal xMax, decimal yMin, decimal yMax)
        {
            (_numXMin.Minimum, _numXMax.Maximum) = (decimal.MinValue, decimal.MaxValue);
            (_numYMin.Minimum, _numYMax.Maximum) = (decimal.MinValue, decimal.MaxValue);

            (_numXMin.Maximum, _numXMax.Minimum) = (xMax, xMin);
            (_numYMin.Maximum, _numYMax.Minimum) = (yMax, yMin);

            _numXMin.ValueChanged += OnXMinChanged;
            _numXMax.ValueChanged += OnXMaxChanged;

            _numYMin.ValueChanged += OnYMinChanged;
            _numYMax.ValueChanged += OnYMaxChanged;

            _numXInterval.ValueChanged += OnXIntervalChanged;
            _numYInterval.ValueChanged += OnYIntervalChanged;

            (_numXMin.Value, _numXMax.Value) = (xMin, xMax);
            (_numYMin.Value, _numYMax.Value) = (yMin, yMax);

            _numXInterval.Maximum = _numXMax.Value - _numXMin.Value;
            _numYInterval.Maximum = _numYMax.Value - _numYMin.Value;
            _numXInterval.Value = _numXInterval.Maximum / 5m;
            _numYInterval.Value = _numYInterval.Maximum / 5m;
        }

        private void OnRadioButtonChanged(object sender, EventArgs e)
        {
            if (_rbOneGraph.Checked)
                for (int i = 0; i < _chart.Series.Count; i++)
                    _chart.Series[i].Enabled = i == _indexMainSeries;
            else
                foreach (var series in _chart.Series)
                    series.Enabled = true;
        }

        private void OnLineSettingsClick(object sender, EventArgs e)
        { 
            new FormLineSettings(_chart.Series).ShowDialog();
        }

        private void OnSaveGraphClick(object sender, EventArgs e)
        { 
            FileWriter.Save(_chart);
        }

        private void OnDecimalPlacesChanged(object sender, EventArgs e)
        {
            var decimalPlaces = (int)_numDecimalPlaces.Value;
            var increment = (decimal)Math.Pow(10, -(int)_numDecimalPlaces.Value);
            var numericUpDowns = new NumericUpDown[] { _numXMin, _numYMin, _numXMax, _numYMax, _numXInterval, _numYInterval };

            foreach (var numeric in numericUpDowns)
            {
                numeric.DecimalPlaces = decimalPlaces;
                numeric.Increment = increment;
            }
        }

        private void OnXMinChanged(object sender, EventArgs e)
        {
            _numXMax.Minimum = _numXMin.Value;
            _chart.ChartAreas[0].AxisX.Minimum = (double)_numXMin.Value;
        }

        private void OnXMaxChanged(object sender, EventArgs e)
        {
            _numXMin.Maximum = _numXMax.Value;
            _chart.ChartAreas[0].AxisX.Maximum = (double)_numXMax.Value;
        }

        private void OnYMinChanged(object sender, EventArgs e)
        {
            _numYMax.Minimum = _numYMin.Value;
            _chart.ChartAreas[0].AxisY.Minimum = (double)_numYMin.Value;
        }

        private void OnYMaxChanged(object sender, EventArgs e)
        {
            _numYMin.Maximum = _numYMax.Value;
            _chart.ChartAreas[0].AxisY.Maximum = (double)_numYMax.Value;
        }

        private void OnXIntervalChanged(object sender, EventArgs e)
        { 
            _chart.ChartAreas[0].AxisX.Interval = (double)_numXInterval.Value;
        }

        private void OnYIntervalChanged(object sender, EventArgs e)
        { 
            _chart.ChartAreas[0].AxisY.Interval = (double)_numYInterval.Value;
        }

        private void OnAxisXTextChanged(object sender, EventArgs e)
        { 
            _chart.ChartAreas[0].AxisX.Title = _txtNameX.Text;
        }

        private void OnAxisYTextChanged(object sender, EventArgs e)
        { 
            _chart.ChartAreas[0].AxisY.Title = _txtNameY.Text;
        }

        private void OnChartSizeChanged(object sender, EventArgs e)
        { 
            _chart.Height = _chart.Width * _aspectRatioChart.Height / _aspectRatioChart.Width;
        }

        private void OnFontAxisChanged(object sender, EventArgs e)
        {
            var labelFont = new Font("", (int)_numFontSize.Value);
            var axisFont = new Font("", (int)_numFontSize.Value, _chkItalics.Checked ? FontStyle.Italic : FontStyle.Regular);

            _chart.ChartAreas[0].AxisX.LabelStyle.Font = labelFont;
            _chart.ChartAreas[0].AxisY.LabelStyle.Font = labelFont;

            _chart.ChartAreas[0].AxisX.TitleFont = axisFont;
            _chart.ChartAreas[0].AxisY.TitleFont = axisFont;
        }

        private void OnButtonEnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button button)
                button.BackColor = button.Enabled ? Color.White : Color.Gray;
        }
    }
}
