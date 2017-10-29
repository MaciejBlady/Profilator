using UnityEngine;

namespace Profilator
{
    [RequireComponent(typeof(ProfilatorModule))]
    public abstract class ProfilatorModuleController : MonoBehaviour
    {
        private int _frameCounter = 0;

        [SerializeField]
        private int _dataSampleFrameInterval = 1;
        [SerializeField]
        private bool _saveSampledData = false;

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

        public int DataSampleFrameInterval
        {
            get
            {
                return _dataSampleFrameInterval;
            }

            set
            {
                _dataSampleFrameInterval = value;
            }
        }

        public bool SaveSampledData
        {
            get
            {
                return _saveSampledData;
            }

            set
            {
                _saveSampledData = value;
            }
        }

        protected void Update()
        {
            if (_frameCounter >= DataSampleFrameInterval)
            {
                SampleModule();
                _frameCounter = 0;
            }
            else
            {
                _frameCounter++;
            }
        }

        public abstract void SampleModule();
    } 
}
