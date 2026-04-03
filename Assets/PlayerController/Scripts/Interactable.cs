using UnityEngine;

namespace GAD210.P2.Iteration1.Player
{
    public abstract class Interactable : MonoBehaviour
    {
        protected bool CheckIfSelector(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Selector") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Define whatever functionality we want in inheriting classes
        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}