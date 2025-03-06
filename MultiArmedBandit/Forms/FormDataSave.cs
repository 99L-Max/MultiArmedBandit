using System;
using System.Linq;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    partial class FormDataSave: Form
    {
        private readonly GameData _gameData;

        public bool IsAllDataSaved { get; private set; }

        public FormDataSave(GameData gameData, bool isAllDataSaved)
        {
            InitializeComponent();
            _gameData = gameData;
            IsAllDataSaved = isAllDataSaved;
        }

        private void OnSaveAllClick(object sender, EventArgs e)
        {
            FileHandler.Save(_gameData, out bool isSaved);
            IsAllDataSaved = isSaved;
            Close();
        }

        private void OnSaveStringTableClick(object sender, EventArgs e)
        {
            var str = _gameData.Strategy == Strategy.UCB ? $"d\\a {string.Join(" ", _gameData.ParameterUCB)}\n" : "";
            str += string.Join("\n", _gameData.Regrets.Select(x => $"{x.Key} {string.Join(" ", x.Value)}"));

            FileHandler.Save(str);
            Close();
        }
    }
}
