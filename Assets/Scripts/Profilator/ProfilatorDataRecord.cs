using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Profilator
{
    //generyczny? - typ danych 
    public class ProfilatorDataRecord : IEnumerable<KeyValuePair<string, double>>
    {
        private DateTime _created;
        private Dictionary<string, double> _records = new Dictionary<string, double>();

        public ProfilatorDataRecord()
        {

        }

        public void WriteToFile(string path)
        {

        }

        public void AddData(string label, double value)
        {
            _records.Add(label, value);
        }

        public override string ToString()
        {
            StringBuilder recordString = new StringBuilder();
            foreach (var record in this)
            {
                recordString.Append(string.Format("{0}: {1}\n", record.Key, record.Value.ToString()));
            }
            return recordString.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator()
        {
            return _records.GetEnumerator();
        }
    }
}
