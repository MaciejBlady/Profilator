using UnityEngine;

namespace Profilator
{
    [RequireComponent(typeof(ProfilatorModule))]
    public class ProfilatorModuleController : MonoBehaviour
    {
        private ProfilatorModule _module;
        public ProfilatorModule Module
        {
            get
            {
                if (!_module)
                {
                    _module = GetComponent<ProfilatorModule>();
                }
                return _module;
            }
        }
    } 
}
