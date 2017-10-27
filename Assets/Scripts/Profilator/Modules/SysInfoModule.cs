using UnityEngine;

namespace Profilator
{
    public class SysInfoModule : ProfilatorModule
    {
        public override ProfilatorDataRecord GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord();
            data.AddData("System", SystemInfo.operatingSystem);
            data.AddData("ProcessorCount",SystemInfo.processorCount.ToString());
            data.AddData("GraphicsMemory", SystemInfo.graphicsMemorySize.ToString());
            data.AddData("SystemMemory", SystemInfo.systemMemorySize.ToString());
            return data;
        }
    }
}