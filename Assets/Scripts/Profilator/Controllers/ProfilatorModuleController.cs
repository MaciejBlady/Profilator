using UnityEngine;

namespace Profilator
{
    public abstract class ProfilatorModuleController : MonoBehaviour
    {
        private int _frameCounter = 0;

        [SerializeField]
        private ProfilatorModule _module;

        [Header("Controlls")]
        [SerializeField]
        private int _dataSampleFrameInterval = 1;
        [SerializeField]
        private bool _saveSampledData = false;
        

        public ProfilatorModule Module
        {
            get
            {
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

        public bool LogSampledData
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
