using UnityEngine;
using System;
using System.IO;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorLoggers/FileLogger")]
    public class FileLogger : ProfilatorLogger
    {
        [SerializeField]
        private string _filename;
        private string _filepath = string.Empty;
        private bool _initialized = false;

        public string Filepath
        {
            get
            {
                if (_filepath == string.Empty)
                {
                    FormatFilepath();
                }
                return _filepath;
            }
        }

        protected virtual void FormatFilepath()
        {
            _filepath = string.Format("{0}\\[{1}_{2}]{3}", Application.persistentDataPath, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), Application.productName, _filename);
        }

        public override void Log(IProfilatorData data)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(Filepath))
                {
                    string message = data.GetFormattedData();
                    writer.WriteLine(message);
                }
            }
            catch (IOException e)
            {
                UnityEngine.Debug.LogError(e.Message);
            }
        }

        protected virtual void OnDisable()
        {
            _filepath = string.Empty;
        }
    }
}
