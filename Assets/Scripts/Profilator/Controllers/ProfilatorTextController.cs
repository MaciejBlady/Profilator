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
            ProfilatorDataRecord data = Module.GetData();

            if (SaveSampledData)
            {
                data.WriteToFile("dunno");
            }

            _displayedText.text = data.ToString();
        }
    } 
}