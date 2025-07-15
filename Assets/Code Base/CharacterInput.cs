using UnityEngine;

namespace RudnTest
{
    public class CharacterInput : MonoBehaviour
    {
        public Vector3 Direction {  get; private set; }

        private void Update()
        {
            MoveDirectionInput();
        }

        private void MoveDirectionInput()
        {
            Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }
    }
}
