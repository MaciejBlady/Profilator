using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Text;

namespace Profilator
{
    public class CPUModule : ProfilatorModule
    {
        private int _processorCount = 0;
        PerformanceCounter[] _counters;

        protected void Awake()
        {
            _processorCount = SystemInfo.processorCount;
            _counters = new PerformanceCounter[_processorCount];

            for (int i = 0; i < _counters.Length; i++)
            {
                _counters[i] = new PerformanceCounter();
                _counters[i].CategoryName = "Processor";
                _counters[i].CounterName = "% Processor Time";
                _counters[i].InstanceName = "_Total";
            }
        }

        public override ProfilatorDataRecord GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord();           
            for (int i = 0; i < _processorCount; i++)
            {
                data.AddData(string.Format("CPU {0}", i), _counters[i].NextValue());
            }
            return data;
        }
    }
}
