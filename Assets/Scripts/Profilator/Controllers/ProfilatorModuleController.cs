using UnityEngine;

namespace Profilator
{
    public abstract class ProfilatorModuleController : MonoBehaviour
    {
        private int _frameCounter = 0;

        [Header("Scriptable objects")]
        [SerializeField]
        private ProfilatorModule _module;
        [SerializeField]
        private ProfilatorLogger _logger;

        [Header("Controlls")]
        [SerializeField]
        private int _dataSampleFrameInterval = 1;
        [SerializeField]
        private bool _logSampledData = false;
        
        public ProfilatorModule Module
        {
            get
            {
                return _module;
            }
        }

        public ProfilatorLogger Logger
        {
            get
            {
                return _logger;
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
                return _logSampledData;
            }

            set
            {
                _logSampledData = value;
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

        protected virtual void SampleModule()
        {
            IProfilatorData data = Module.GetData();
            ProcessData(data);
            if (LogSampledData)
            {
                Logger.Log(data);
            }
        }

        public abstract void ProcessData(IProfilatorData data);
    } 
}
