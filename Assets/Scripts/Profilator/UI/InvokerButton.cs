using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace Profilator
{
    [RequireComponent(typeof(Button))]
    public class InvokerButton : MonoBehaviour
    {
        private Text _label;
        private Button _properButton;

        public Button ProperButton
        {
            get
            {
                if (_properButton == null)
                {
                    _properButton = GetComponent<Button>();
                }
                return _properButton;
            }
        }

        public Button.ButtonClickedEvent OnClick
        {
            get
            {
                return ProperButton.onClick;
            }

            set
            {
                ProperButton.onClick = value;
            }
        }

        public string Label
        {
            get
            {
                return _label != null ? _label.text : string.Empty;
            }

            set
            {
                if (_label != null)
                {
                    _label.text = value;
                }            
            }
        }

        private void Awake()
        {
            _label = GetComponentInChildren<Text>();
        }
    } 
}
