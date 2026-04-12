using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.DialogueSystem
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _textElements;

        [SerializeField] private GameObject _inputFieldElements;

        [SerializeField] private TMP_InputField _inputField;

        [SerializeField] private GameObject _buttonPromptElements;

        [SerializeField] private Button _buttonPromptButton;

        #endregion

        #region Methods

        public void ToggleTextElements(bool value)
        {
            _textElements.SetActive(value);
        }

        public void ToggleInputField(bool value)
        {
            _inputFieldElements.SetActive(value);

            if (value == true)
            {
                _inputField.ActivateInputField();
            }
        }

        public void ToggleButtonPrompt(bool value)
        {
            _buttonPromptElements.SetActive(value);

            if (value == true)
            {
                _buttonPromptButton.Select();
            }
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleInputField(false);

            ToggleButtonPrompt(false);

            ToggleTextElements(true);
        }

        #endregion
    }
}