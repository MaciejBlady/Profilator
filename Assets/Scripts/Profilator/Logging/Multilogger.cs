using System;
using UnityEngine;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorLoggers/Multilogger")]
    public class Multilogger : ProfilatorLogger
    {
        [SerializeField]
        private ProfilatorLogger[] _loggers;

        public override void Log(IProfilatorData data)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(data);
            }
        }
    } 
}
