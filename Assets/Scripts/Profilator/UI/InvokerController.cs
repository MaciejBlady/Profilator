using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

namespace Profilator
{
    public class InvokerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _invokerButtonPrefab;
        [SerializeField]
        private GameObject _buttonParent;
        [SerializeField]
        private Button.ButtonClickedEvent[] _buttonEvents;

        private void Awake()
        {
            foreach (var buttonEvent in _buttonEvents)
            {
                AddButton(buttonEvent);
            }
        }

        public void AddButton(Button.ButtonClickedEvent buttonEvent)
        {
            GameObject newButton = Instantiate<GameObject>(_invokerButtonPrefab);
            if (newButton != null)
            {
                newButton.transform.parent = _buttonParent.transform;
                InvokerButton invokerButton = newButton.GetComponent<InvokerButton>();
                if (invokerButton != null)
                {
                    invokerButton.OnClick = buttonEvent;
                    invokerButton.Label = buttonEvent.GetPersistentTarget(0).ToString();
                }   
            }
        }
    } 
}
