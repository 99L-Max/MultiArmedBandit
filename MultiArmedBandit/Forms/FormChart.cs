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

        private int _indexMainSeries;

        private static readonly ReadOnlyCollection<Color> s_colorsDefault;

        static FormChart()
        {
            List<Color> list = new List<Color>()
            {
                Color.Red, Color.Green, Color.Blue,
                Color.Orange, Color.Purple, Color.Black,
                Color.Maroon, Color.DarkGreen, Color.Cyan,
                Color.Gold, Color.Indigo, Color.DimGray
            };

            s_colorsDefault = new ReadOnlyCollection<Color>(list);
        }

        public FormChart()
        {
            InitializeComponent();
            OnDecimalPlacesChanged(_numDecimalPlaces, EventArgs.Empty);
            OnFontAxisChanged(_numFontSize, EventArgs.Empty);
        }

        public void BuildChart(IDictionary<double, double[]> points, int indexMainSeries)
        {
            _chart.Series.Clear();

            var count = points.First().Value.Length;

            for (int i = 0; i < count; i++)
            {
                var series = new Series
                {
                    BorderWidth = 3,
                    ChartType = SeriesChartType.Spline,
                    Color = s_colorsDefault[i % s_colorsDefault.Count]
                };

                foreach (var p in points)
                    series.Points.AddXY(p.Key, p.Value[i]);

                _chart.Series.Add(series);
            }

            _indexMainSeries = indexMainSeries;

            var decimalPlaces = (int)_numDecimalPlaces.Value;
            var xMin = (decimal)Math.Round(points.Keys.Min(), decimalPlaces);
            var xMax = (decimal)Math.Round(points.Keys.Max(), decimalPlaces);
            var yMin = (decimal)Math.Floor(points.Select(x => x.Value.Min()).Min());
            var yMax = (decimal)Math.Ceiling(points.Select(x => x.Value.Max()).Max());

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
                foreach (var ser in _chart.Series)
                    ser.Enabled = true;
        }

        private void OnLineSettingsClick(object sender, EventArgs e) =>
            new FormLineSettings(_chart.Series).ShowDialog();

        private void OnSaveGraphClick(object sender, EventArgs e) =>
            FileHandler.Save(_chart);

        private void OnDecimalPlacesChanged(object sender, EventArgs e)
        {
            var decimalPlaces = (int)_numDecimalPlaces.Value;
            var increment = (decimal)Math.Pow(10, -(int)_numDecimalPlaces.Value);
            var numericUpDowns = new NumericUpDown[] { _numXMin, _numYMin, _numXMax, _numYMax, _numXInterval, _numYInterval };

            foreach (var ctrl in numericUpDowns)
            {
                ctrl.DecimalPlaces = decimalPlaces;
                ctrl.Increment = increment;
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

        private void OnXIntervalChanged(object sender, EventArgs e) =>
            _chart.ChartAreas[0].AxisX.Interval = (double)_numXInterval.Value;

        private void OnYIntervalChanged(object sender, EventArgs e) =>
            _chart.ChartAreas[0].AxisY.Interval = (double)_numYInterval.Value;

        private void OnAxisXTextChanged(object sender, EventArgs e) =>
            _chart.ChartAreas[0].AxisX.Title = _txtNameX.Text;

        private void OnAxisYTextChanged(object sender, EventArgs e) =>
            _chart.ChartAreas[0].AxisY.Title = _txtNameY.Text;

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
            if (sender is Button btn)
                btn.BackColor = btn.Enabled ? Color.White : Color.Gray;
        }

        private void OnChartSizeChanged(object sender, EventArgs e) =>
            _chart.Height = _chart.Width * _aspectRatioChart.Height / _aspectRatioChart.Width;
    }
}
