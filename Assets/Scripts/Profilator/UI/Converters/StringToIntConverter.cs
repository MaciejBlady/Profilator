using UnityEngine;
using UnityEngine.Events;

namespace Profilator
{
    public class StringToIntConverter : MonoBehaviour
    {
        [System.Serializable]
        private class SetIntEvent : UnityEvent<int> { };
        [SerializeField]
        private SetIntEvent _setInt;
        [SerializeField]
        private bool _allowNegative = false;

        public string ToConvert
        {
            set
            {
                int converted = 0;
                bool canUse = int.TryParse(value, out converted) && (converted > 0 || _allowNegative);
                _setInt.Invoke(canUse ? converted : 1);
            }
        }
    } 
}
