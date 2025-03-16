using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormCollectionSettings : Form
    {
        private readonly int _decimalPlaces;

        public readonly string CollectionName;

        public bool IsCollectionChanged { get; private set; } = false;

        public FormCollectionSettings(string collectionName, string title, double start, double step, int count, double minStart, double maxStart, int decimalPlaces = 2, bool isFixedCount = true)
        {
            InitializeComponent();
            CollectionName = collectionName;

            _lblTitle.Text = title;
            _numCount.Enabled = !isFixedCount;

            _numStart.DecimalPlaces = _numStep.DecimalPlaces = _decimalPlaces = decimalPlaces;
            _numStart.Increment = _numStep.Increment = (decimal)Math.Pow(10d, -decimalPlaces);

            _numStart.Minimum = (decimal)minStart;
            _numStart.Maximum = (decimal)maxStart;

            _numStart.Value = (decimal)start;
            _numStep.Value = (decimal)step;
            _numCount.Value = count;
        }

        private void OnNumericUpDownValueChanged(object sender, EventArgs e) =>
            _txtEndValue.Text = (_numStart.Value + _numStep.Value * (_numCount.Value - 1)).ToString($"F{_decimalPlaces}");

        private void OnApplyClick(object sender, EventArgs e)
        {
            IsCollectionChanged = true;
            Close();
        }

        public IEnumerable<double> GetCollection()
        {
            var start = (double)_numStart.Value;
            var step = (double)_numStep.Value;
            var count = (int)_numCount.Value;
            return CollectionHandler.CreateCollection(start, step, count, _decimalPlaces);
        }
    }
}