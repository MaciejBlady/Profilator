using UnityEngine;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorModules/SysInfoModule")]
    public class SysInfoModule : ProfilatorModule
    {
        public override IProfilatorData GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord(this);
            data.AddData("System", SystemInfo.operatingSystem);
            data.AddData("ProcessorCount",SystemInfo.processorCount.ToString());
            data.AddData("GraphicsMemory[MB]", SystemInfo.graphicsMemorySize.ToString());
            data.AddData("SystemMemory[MB]", SystemInfo.systemMemorySize.ToString());
            return data;
        }
    }
}