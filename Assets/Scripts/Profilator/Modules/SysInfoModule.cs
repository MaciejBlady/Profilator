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
            data.AddData("GraphicsMemory", SystemInfo.graphicsMemorySize.ToString());
            data.AddData("SystemMemory", SystemInfo.systemMemorySize.ToString());
            return data;
        }
    }
}