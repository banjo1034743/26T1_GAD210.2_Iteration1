using GAD210.P2.Iteration1.Microgame;
using GAD210.P2.Iteration1.Player;
using System.Collections.Generic;
using UnityEngine;

namespace GAD210.P2.Iteration1.Environment
{
    public class InteractableCarCrash : Interactable
    {
        #region Variables

        [TextArea]
        [SerializeField] private List<string> _affirmativeInteractText = new List<string>();

        [TextArea]
        [SerializeField] private List<string> _deniedInteractText = new List<string>();

        private int _affirmativeInteractTextIndex = 0;

        private int _deniedInteractTextIndex = 0;

        [SerializeField] private GameObject _jawsOfLifeMicrogame;

        #endregion

        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckIfSelector(other) == true)
            {
                if (PlayerItemManager.instance.HasJawsOfLife == true)
                {
                    if (_affirmativeInteractTextIndex < _affirmativeInteractText.Count - 1)
                    {
                        //Debug.Log("Display sign text!");
                        _textBoxDisplayer.Parse(_affirmativeInteractText[_affirmativeInteractTextIndex]);
                        _affirmativeInteractTextIndex++;
                    }
                    else
                    {
                        _jawsOfLifeMicrogame.SetActive(true);

                        _textBoxDisplayer.HideTextbox();
                        _affirmativeInteractTextIndex = 0;
                    }
                }
                else
                {
                    if (_deniedInteractTextIndex < _deniedInteractText.Count - 1)
                    {
                        _textBoxDisplayer.Parse(_deniedInteractText[_deniedInteractTextIndex]);
                        _deniedInteractTextIndex++;
                    }
                    else
                    {
                        _textBoxDisplayer.HideTextbox();
                        _deniedInteractTextIndex = 0;
                    }
                }
            }
        }

        private void Start()
        {
            _jawsOfLifeMicrogame.SetActive(false);
        }

        #endregion
    }
}