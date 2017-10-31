using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorLoggers/BufferedFileLogger")]
    public class BufferedFileLogger : FileLogger
    {
        [SerializeField]
        private int _maxBufferBytes;

        private List<string> _buffer;
        public List<string> Buffer
        {
            get
            {
                if (_buffer == null)
                {
                    _buffer = new List<string>();
                }
                return _buffer;
            }
        }

        public int BufferBytes
        {
            get
            {
                int size = 0;
                foreach (var s in Buffer)
                {
                    size += s.Length * sizeof(char);
                }
                //Debug.LogFormat("Buffer bytes: {0}", size);
                return size;
            }
        }

        public override void Log(IProfilatorData data)
        {
            if (BufferBytes < _maxBufferBytes)
            {              
                Buffer.Add(data.GetFormattedData());
            }
            else
            {
                try
                {
                    Debug.LogFormat("Flushing! {0}", BufferBytes.ToString());
                    using (StreamWriter writer = File.AppendText(Filepath))
                    {
                        foreach (var message in Buffer)
                        {
                            writer.WriteLine(message);
                        }
                        Buffer.Clear();
                    }
                }
                catch (IOException e)
                {
                    Debug.LogError(e.Message);
                }
            }
        }

        protected override void OnDisable()
        {
            if (_buffer != null)
            {
                _buffer.Clear();
                _buffer = null;
            }
            base.OnDisable();
        }
    }
}
