using UnityEngine;

namespace Profilator
{
    public abstract class ProfilatorModule : MonoBehaviour
    {
        public abstract ProfilatorDataRecord GetData();
    }
}
