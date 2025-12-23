using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MultiArmedBandit
{
    static class FileReader
    {
        public static bool TryOpen(out Player player)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Файлы Json|*.json" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                        var json = File.ReadAllText(dialog.FileName);
                        player = JsonConvert.DeserializeObject<Player>(json, settings);
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                player = null;
                return false;
            }
        }

        public static ReadOnlyDictionary<TKey, TValue> ReadJsonResource<TKey, TValue>(byte[] array)
        {
            try
            {
                var json = Encoding.UTF8.GetString(array);
                return JsonConvert.DeserializeObject<ReadOnlyDictionary<TKey, TValue>>(json);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
