using System;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace Super_Text_Editor
{
    [Serializable]
    internal class Settings
    {
        public static Settings Default
        {
            get
            {
                Settings s = new Settings();
                s.ColorMode = "LIGHT";
                s.Font = new Font("Lucida Console", 12F, FontStyle.Regular);
                s.StatusBar = true;
                return s;
            }
        }

        public string ColorMode { get; set; }

        public Font Font { get; set; }

        public bool StatusBar { get; set; }
        
        public void Save()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\EditorSettings";

                if (File.Exists(path))
                    File.Delete(path);

                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this);
                fs.Dispose();
                fs.Close();
            }
            catch { }
        }

        public void Load()
        {
            try
            {

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\EditorSettings";

                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                object x = bf.Deserialize(fs);
                Settings s = (Settings)x;
                this.Font = s.Font;
                this.StatusBar = s.StatusBar;
                this.ColorMode = s.ColorMode;
                fs.Dispose();
                fs.Close();
            }
            catch
            {
                this.Font = Default.Font;
                this.ColorMode = Default.ColorMode;
                this.StatusBar = Default.StatusBar;
            }
        }
    }
}
