using UnityEngine;
using UnityEngine.UI;

namespace Profilator
{
    public class ProfilatorTextController : ProfilatorModuleController
    {
        [SerializeField]
        private Text _displayedText;

        private void Start()
        {
            if (_displayedText == null)
            {
                _displayedText = GetComponent<Text>();
            }
        }

        public override void ProcessData(IProfilatorData data)
        {
            if (_displayedText != null)
            {
                _displayedText.text = data.GetFormattedData();
            }        
        }
    } 
}