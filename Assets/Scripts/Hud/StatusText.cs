using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

namespace Assets.Scripts.Hud
{
    internal class StatusText : MonoBehaviour
    {
        [SerializeField]
        private Text _labelText;
        [SerializeField]
        private Text _amountText;

        private int _amount;
        private string _format;

        public void SetFormat(string format)
        {
            _format = format;
        }

        public void Increase(int amount = 1)
        {
            _amount += amount;
            if (string.IsNullOrWhiteSpace(_format))
            {
                _amountText.text = _amount.ToString();
            }
            else
            {
                _amountText.text = string.Format(_format, _amount);
            }
        }
    }
}
