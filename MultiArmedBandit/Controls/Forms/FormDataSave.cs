using System;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormDataSave : Form
    {
        public FormDataSave()
        {
            InitializeComponent();
        }

        public event Action<Form, SavingData> SaveDataSelected;

        private void OnSaveAllClick(object sender, EventArgs e)
        {
            SaveDataSelected?.Invoke(this, SavingData.All);
        }

        private void OnSaveStringTableClick(object sender, EventArgs e)
        {
            SaveDataSelected?.Invoke(this, SavingData.RegretTable);
        }
    }
}
