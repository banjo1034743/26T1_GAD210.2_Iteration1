using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    public class InteractableSign : Interactable
    {
        #region Unity Methods

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (CheckIfSelector(collision) == true)
            {
                Debug.Log("Display sign text!");
            }
        }

        #endregion
    }
}