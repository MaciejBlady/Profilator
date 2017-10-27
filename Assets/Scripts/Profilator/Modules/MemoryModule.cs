using System;
using UnityEngine;
using System.Diagnostics;

namespace Profilator
{
    public class MemoryModule : ProfilatorModule
    {
        public override ProfilatorDataRecord GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord();
            data.AddData("AllocatedKBytes", (GC.GetTotalMemory(true) / (1024)).ToString());
            return data;         
        }
    }
}