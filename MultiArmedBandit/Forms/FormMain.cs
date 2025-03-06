using MultiArmedBandit.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    enum TypeForm { DateTime, Modeling, Chart, AboutStrategy, AboutProgram }

    partial class FormMain : Form
    {
        private readonly FormModeling _formModeling;
        private readonly FormChart _formChart;

        private bool _isDrag = false;
        private bool _isResize = false;
        private Point _startPoint;
        private TypeForm? _typeForm = null;
        private Form _activeForm;

        public FormMain()
        {
            InitializeComponent();

            _formModeling = new FormModeling(BackColor);
            _formChart = new FormChart();

            _formModeling.ResultChanged += (d, i) => _formChart.BuildChart(d, i);
            _formModeling.ClearChart += () => _formChart.ClearChart();

            OnMainToolClick(MainMenuStrip, EventArgs.Empty);
        }

        private void OpenChildForm(Form childForm, TypeForm typeForm)
        {
            if (typeForm != _typeForm)
            {
                if (!(_activeForm is FormModeling || _activeForm is FormChart))
                    _activeForm?.Close();

                _activeForm = childForm;
                _typeForm = typeForm;

                childForm.BackColor = BackColor;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                _pnlDesctopPanel.Controls.Clear();
                _pnlDesctopPanel.Controls.Add(_pnlResize);
                _pnlDesctopPanel.Controls.Add(childForm);

                childForm.Show();
            }
        }

        private void OnMenuStripClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name != _exitToolStripMenuItem.Name)
                _lblTitle.Text = e.ClickedItem.Text;
        }

        private void OnMainToolClick(object sender, EventArgs e) =>
            OpenChildForm(new FormDateTime(), TypeForm.DateTime);

        private void OnCalculateClick(object sender, EventArgs e) =>
            OpenChildForm(_formModeling, TypeForm.Modeling);

        private void OnChartClick(object sender, EventArgs e) =>
            OpenChildForm(_formChart, TypeForm.Chart);

        private void OnAboutStrategyClick(object sender, EventArgs e) =>
            OpenChildForm(new FormInfo(Resources.AboutStrategy, BackColor), TypeForm.AboutStrategy);

        private void OnAboutProgramClick(object sender, EventArgs e) =>
            OpenChildForm(new FormInfo(Resources.AboutProgram, BackColor), TypeForm.AboutProgram);

        private void OnExitClick(object sender, EventArgs e) =>
            Close();

        private void OnButtonResizeClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                _btnResize.BackgroundImage = Resources.Resize_Min;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                _btnResize.BackgroundImage = Resources.Resize_Max;
            }

            _pnlResize.Visible = !_pnlResize.Visible;
        }

        private void OnButtonMinimizeClick(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void OnPanelFrameMouseDown(object sender, MouseEventArgs e)
        {
            _isDrag = true;
            _startPoint = new Point(e.X, e.Y);
        }

        private void OnPanelFrameMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrag)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - _startPoint.X, p.Y - _startPoint.Y);
            }
        }

        private void OnPanelFrameMouseUp(object sender, MouseEventArgs e) =>
            _isDrag = false;

        private void OnPanelResizeMouseDown(object sender, MouseEventArgs e) =>
            _isResize = true;

        private void OnPanelResizeMouseMove(object sender, MouseEventArgs e)
        {
            if (_isResize)
                Size = new Size(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
        }

        private void OnPanelResizeMouseUp(object sender, MouseEventArgs e) =>
            _isResize = false;

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_formModeling.IsSimulationFinished && _formModeling.IsDataSaved)
                return;

            if (!_formModeling.IsSimulationFinished)
            {
                MessageBox.Show($"Процесс не завершён.\nДождитесь завершения процесса или отмените его.", "Закрытие невозможно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            if (DialogResult.No == MessageBox.Show($"Несохранённые данные будут удалены.\nПродолжить?", "Данные не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                e.Cancel = true;
        }
    }
}