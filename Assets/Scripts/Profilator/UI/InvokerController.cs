using UnityEngine;
using UnityEngine.UI;

namespace Profilator
{
    public class InvokerController : MonoBehaviour
    {
        [System.Serializable]
        private class InvokerAction
        {
            public Button.ButtonClickedEvent OnButtonClick;
            public string ButtonLabel = "Button";
        }

        [SerializeField]
        private GameObject _invokerButtonPrefab;
        [SerializeField]
        private GameObject _buttonParent;
        [SerializeField]
        private InvokerAction[] _buttonActions;

        private void Awake()
        {
            foreach (var buttonAction in _buttonActions)
            {
                AddButton(buttonAction);
            }
        }

        private void AddButton(InvokerAction buttonEvent)
        {
            GameObject newButton = Instantiate<GameObject>(_invokerButtonPrefab);
            if (newButton != null)
            {
                newButton.transform.parent = _buttonParent.transform;
                InvokerButton invokerButton = newButton.GetComponent<InvokerButton>();
                if (invokerButton != null)
                {
                    invokerButton.OnClick = buttonEvent.OnButtonClick;
                    invokerButton.Label = buttonEvent.ButtonLabel;
                }   
            }
        }
    } 
}
