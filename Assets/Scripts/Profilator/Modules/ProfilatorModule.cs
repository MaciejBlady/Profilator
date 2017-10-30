using UnityEngine;

namespace Profilator
{
    public abstract class ProfilatorModule : ScriptableObject
    {
        public abstract ProfilatorDataRecord GetData();
    }
}
