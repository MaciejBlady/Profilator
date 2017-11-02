using UnityEngine;
using UnityEngine.UI;

namespace Profilator
{
    [RequireComponent(typeof(ProfilatorTextController))]
    public class ProfilatorTextControllerUIBinding : MonoBehaviour
    {
        private ProfilatorTextController _controller;
        public ProfilatorTextController Controller
        {
            get
            {
                if (_controller == null)
                {
                    _controller = GetComponent<ProfilatorTextController>();
                }
                return _controller;
            }
        }

        [SerializeField]
        private InputField _inputField;
        [SerializeField]
        private Toggle _toggle;

        private void Awake()
        {
            if (_inputField != null)
            {
                _inputField.text = Controller.DataSampleFrameInterval.ToString();
                _inputField.onEndEdit.AddListener(SetConvertedInput);
            }

            if (_toggle != null)
            {
                _toggle.isOn = Controller.LogSampledData;
                _toggle.onValueChanged.AddListener(SetToggle);
            }
        }

        private void SetConvertedInput(string input)
        {
            int converted = 0;
            if(int.TryParse(input, out converted) && converted > -1)
            {
                Controller.DataSampleFrameInterval = converted;
            }
        }

        private void SetToggle(bool isOn)
        {
            Controller.LogSampledData = isOn;
        }
    } 
}
