using UnityEngine;

namespace Profilator
{
    public class ProfilatorCore : MonoBehaviour
    {
        private static ProfilatorCore _instance;
        public static ProfilatorCore Instance
        {
            get
            {
                return _instance;
            }
        }

        [SerializeField]
        private ProfilatorLogger _logger;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }

        public void Log(IProfilatorData data)
        {
            if (_logger != null)
            {
                _logger.Log(data);
            }
        }
    }
}

