using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Profilator
{
    public class ProfilatorDataRecord : IEnumerable<KeyValuePair<string, string>>, IProfilatorData
    {
        private DateTime _created;
        private Dictionary<string, string> _records = new Dictionary<string, string>();

        public DateTime Created
        {
            get
            {
                return _created;
            }
        }

        public ProfilatorModule Source
        {
            get;
            private set;
        }


        public ProfilatorDataRecord(ProfilatorModule source)
        {
            Source = source;
            _created = DateTime.Now;
        }

        public void AddData(string label, string value)
        {
            _records.Add(label, value);
        }

        public string GetFormattedData()
        {
            StringBuilder recordString = new StringBuilder();
            recordString.AppendLine(string.Format("Module: {0}", Source.name));
            recordString.AppendLine(string.Format("Created: {0}", Created));
            foreach (var record in this)
            {
                recordString.AppendLine(string.Format("{0}: {1}", record.Key, record.Value.ToString()));
            }
            return recordString.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _records.GetEnumerator();
        }
    }
}
