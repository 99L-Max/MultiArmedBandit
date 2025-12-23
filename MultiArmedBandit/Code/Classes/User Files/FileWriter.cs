using Newtonsoft.Json;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiArmedBandit
{
    static class FileWriter
    {
        public static void Save(Player player, out bool isSaved)
        {
            using (SaveFileDialog dialog = new SaveFileDialog { Filter = "Файлы Json|*.json" })
            {
                isSaved = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                        var json = JsonConvert.SerializeObject(player, settings);
                        File.WriteAllText(dialog.FileName, json);

                        isSaved = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка записи файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static void Save(string data)
        {
            using (SaveFileDialog dialog = new SaveFileDialog { Filter = "Текстовые файлы|*.txt" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(dialog.FileName))
                            writer.Write(data);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка записи файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static void Save(Chart chart)
        {
            using (SaveFileDialog dialog = new SaveFileDialog { Filter = "Изображения|*.png" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    chart.SaveImage(dialog.FileName, ImageFormat.Png);
        }
    }
}
