using UnityEngine;
using UnityEngine.Profiling;

namespace Profilator
{
    [CreateAssetMenu(menuName = "ProfilatorModules/CPUModule")]
    public class CPUModule : ProfilatorModule
    {
        Recorder _behaviourDataRecorder;

        private void OnEnable()
        {
            _behaviourDataRecorder = GetRecorder("BehaviourUpdate");
        }

        public override IProfilatorData GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord(this);
            data.AddData("BehaviourUpdateElapsedTime", _behaviourDataRecorder.elapsedNanoseconds.ToString());
            return data;
        }

        private Recorder GetRecorder(string name)
        {          
            Recorder recorder = Recorder.Get(name);
            recorder.enabled = true;
            return recorder;
        }
    }
}
