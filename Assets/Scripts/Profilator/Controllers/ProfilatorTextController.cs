using UnityEngine;
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

        private void Update()
        {
            _displayedText.text = Module.GetData().ToString();
        }
    } 
}