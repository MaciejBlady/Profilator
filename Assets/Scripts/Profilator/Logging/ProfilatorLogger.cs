using UnityEngine;

namespace Profilator
{
    public abstract class ProfilatorLogger : ScriptableObject
    {
        public abstract void Log(IProfilatorData data);
    } 
}