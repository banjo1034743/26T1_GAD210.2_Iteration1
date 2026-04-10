using UnityEngine;
using GAD210.P2.Iteration1.Player;

namespace GAD210.P2.Iteration1.Environment
{
    public class InteractableCarCrash : Interactable
    {
        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckIfSelector(other) == true)
            {
                // Call text prompt for using ability here
            }
        }

        #endregion
    }
}