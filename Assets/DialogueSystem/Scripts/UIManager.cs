using TMPro;
using UnityEngine;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _textElements;

        [SerializeField] private GameObject _inputFieldElements;

        #endregion

        #region Methods

        public void ToggleTextElements(bool value)
        {
            _textElements.SetActive(value);
        }

        public void ToggleInputField(bool value)
        {
            _inputFieldElements.SetActive(value);
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleInputField(false);

            ToggleTextElements(true);
        }

        #endregion
    }
}