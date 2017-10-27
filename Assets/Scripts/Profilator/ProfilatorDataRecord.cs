﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Profilator
{
    public class ProfilatorDataRecord : IEnumerable<KeyValuePair<string, string>>
    {
        private DateTime _created;
        private Dictionary<string, string> _records = new Dictionary<string, string>();

        public ProfilatorDataRecord()
        {
            _created = DateTime.Now;
        }

        public void WriteToFile(string path)
        {

        }

        public void AddData(string label, string value)
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

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _records.GetEnumerator();
        }
    }
}
