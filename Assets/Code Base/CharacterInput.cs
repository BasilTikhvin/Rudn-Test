using UnityEngine;

namespace RudnTest
{
    public class CharacterInput : MonoBehaviour
    {
        public Vector3 Direction { get; private set; }
        public float Rotation { get; private set; }

        private void Update()
        {
            MoveDirectionInput();
            LookRotation();
        }

        public void DisableInput()
        {
            ResetInput();
            enabled = false;
        }

        private void MoveDirectionInput()
        {
            Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }

        private void LookRotation()
        {
            Rotation = Input.GetAxis("Mouse X");
        }

        private void ResetInput()
        {
            Direction = Vector3.zero;
            Rotation = 0f;
        }
    }
}
