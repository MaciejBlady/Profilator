using UnityEngine;
using UnityEngine.Profiling;
using System.Collections.Generic;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorModules/UnityProfilerModule")]
    public class UnityProfilerModule : ProfilatorModule
    {
        [SerializeField]
        private string[] _profilerRecorderNames;
        private Dictionary<string, Recorder> _recorders = new Dictionary<string, Recorder>();

        private void OnEnable()
        {
            foreach (var _recorderName in _profilerRecorderNames)
            {
                AddRecorder(_recorderName);
            }
        }

        private void AddRecorder(string name)
        {
            Recorder recorder = Recorder.Get(name);
            recorder.enabled = true;
            _recorders.Add(name, recorder);
        }

        public override IProfilatorData GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord(this);

            foreach (var recorder in _recorders)
            {
                data.AddData(recorder.Key, recorder.Value.elapsedNanoseconds.ToString());
            }
            
            return data;
        }
    }
}
