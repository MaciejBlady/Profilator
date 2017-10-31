using UnityEngine.UI;

namespace Profilator
{
    public class ProfilatorTextController : ProfilatorModuleController
    {
        public Text _displayedText;

        private void Start()
        {
            if (_displayedText == null)
            {
                _displayedText = GetComponent<Text>();
            }
        }

        public override void SampleModule()
        {
            IProfilatorData data = Module.GetData();

            if (LogSampledData)
            {
                ProfilatorCore.Instance.Log(data);
            }

            _displayedText.text = data.GetFormattedData();
        }
    } 
}