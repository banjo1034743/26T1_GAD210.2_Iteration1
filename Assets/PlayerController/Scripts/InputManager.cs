using UnityEngine;
using UnityEngine.InputSystem;

namespace FDAY2025.Player
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        public Vector2 direction;

        protected float buttonFloat;
        protected bool buttonBool;

        protected float escapeFloat;
        protected bool escapeBool;

        #endregion

        #region Methods

        public virtual void Movement(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<Vector2>();
            Debug.Log(direction);
        }

        public virtual void Interact(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                buttonBool = true;
            }
            else if (context.canceled)
            {
                buttonBool = false;
            }
        }

        public virtual void Escape(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("player");
                escapeBool = true;
            }
            else if (context.canceled)
            {
                escapeBool = false;
            }
        }

        public Vector2 GetDirectionValue()
        {
            return direction;
        }

        public bool GetEscapeBoolValue()
        {
            return escapeBool;
        }

        #endregion
    }
}