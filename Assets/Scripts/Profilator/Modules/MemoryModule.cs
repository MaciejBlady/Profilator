using UnityEngine;
using UnityEngine.Profiling;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorModules/MemoryModule")]
    public class MemoryModule : ProfilatorModule
    {
        public override IProfilatorData GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord(this);
            long totalReserved = Profiler.GetTotalReservedMemoryLong();
            long totalReservedUnused = Profiler.GetTotalUnusedReservedMemoryLong();

            data.AddData("TotalReservedMemory[B]", totalReserved.ToString());
            data.AddData("TotalUnusedReservedMemory[B]", totalReservedUnused.ToString());
            data.AddData("ReservedMemoryUsage[B]", (1.0 - ((double)totalReservedUnused / (double)totalReserved)).ToString());
            data.AddData("MonoHeapSize[B]", Profiler.GetMonoHeapSizeLong().ToString());
            data.AddData("MonoUsedSize[B]", Profiler.GetMonoUsedSizeLong().ToString());
            data.AddData("TotalAllocatedMemory[B]", Profiler.GetTotalAllocatedMemoryLong().ToString());

            return data;         
        }
    }
}