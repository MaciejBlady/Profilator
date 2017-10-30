using System.Diagnostics;
using UnityEngine;
using UnityEngine.Profiling;
using System.Collections.Generic;

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

        //protected void Awake()
        //{
        //    List<string> names = new List<string>();
        //    Sampler.GetNames(names);
        //    foreach (var item in names)
        //    {
        //        UnityEngine.Debug.Log(item);
        //    }

        //    _behaviourDataRecorder = GetRecorder("BehaviourUpdate");
        //}

        public override ProfilatorDataRecord GetData()
        {
            ProfilatorDataRecord data = new ProfilatorDataRecord();
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
