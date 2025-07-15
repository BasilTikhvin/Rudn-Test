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

        private void MoveDirectionInput()
        {
            Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }

        private void LookRotation()
        {
            if (Input.GetKey(KeyCode.Mouse1))
                Rotation = Input.GetAxis("Mouse X");
            else
                Rotation = 0f;
        }
    }
}
