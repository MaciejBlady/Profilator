using UnityEngine;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorLoggers/ConsoleLogger")]
    public class ConsoleLogger : ProfilatorLogger
    {
        public override void Log(IProfilatorData data)
        {
            Debug.Log(data.GetFormattedData());
        }
    } 
}
