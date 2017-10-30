using System;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.Profiling;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorModules/MemoryModule")]
    public class MemoryModule : ProfilatorModule
    {
        public override ProfilatorDataRecord GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord();
            data.AddData("MonoHeapSize", Profiler.GetMonoHeapSizeLong().ToString());
            data.AddData("MonoUsedSize", Profiler.GetMonoUsedSizeLong().ToString());
            data.AddData("TotalAllocatedMemory", Profiler.GetTotalAllocatedMemoryLong().ToString());

            long totalReserved = Profiler.GetTotalReservedMemoryLong();
            long totalReservedUnused = Profiler.GetTotalUnusedReservedMemoryLong();
            data.AddData("TotalReservedMemory", totalReserved.ToString());
            data.AddData("TotalUnusedReservedMemory", totalReservedUnused.ToString());
            data.AddData("ReservedMemoryUsage", (1.0 - ((double)totalReservedUnused / (double)totalReserved)).ToString());

            return data;         
        }
    }
}