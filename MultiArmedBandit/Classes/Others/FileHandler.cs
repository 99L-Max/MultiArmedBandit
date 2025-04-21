using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace MultiArmedBandit
{
    static class FileHandler
    {
        public static GameData Open()
        {
            using (var ofDialog = new OpenFileDialog())
            {
                ofDialog.Filter = "Файлы Json|*.json";

                if (ofDialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        var json = File.ReadAllText(ofDialog.FileName);
                        return JsonConvert.DeserializeObject<GameData>(json);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString(), "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                return null;
            }
        }

        public static void Save(GameData gameData, out bool isSaved)
        {
            using (var sfDialog = new SaveFileDialog())
            {
                isSaved = false;
                sfDialog.Filter = "Файлы Json|*.json";

                if (sfDialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        var json = JsonConvert.SerializeObject(gameData, Formatting.Indented);
                        File.WriteAllText(sfDialog.FileName, json);
                        isSaved = true;
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString(), "Ошибка записи файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        public static void Save(string data)
        {
            using (var sfDialog = new SaveFileDialog())
            {
                sfDialog.Filter = "Текстовые файлы|*.txt";

                if (sfDialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        using (var writer = new StreamWriter(sfDialog.FileName))
                            writer.Write(data);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString(), "Ошибка записи файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        public static void Save(Chart chart)
        {
            using (var sfDialog = new SaveFileDialog())
            {
                sfDialog.Filter = "Изображения|*.png";

                if (sfDialog.ShowDialog() == DialogResult.OK)
                    chart.SaveImage(sfDialog.FileName, ImageFormat.Png);
            }
        }

        public static ReadOnlyDictionary<TKey, TValue> ReadJsonResource<TKey, TValue>(byte[] array)
        {
            var jString = Encoding.UTF8.GetString(array);
            return JsonConvert.DeserializeObject<ReadOnlyDictionary<TKey, TValue>>(jString);
        }
    }
}
