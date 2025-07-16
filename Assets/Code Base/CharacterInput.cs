using System;
using UnityEngine;
using Zenject;

namespace RudnTest
{
    [Serializable]
    public class CharacterInput : MonoBehaviour
    {
        public Vector3 MoveDirection { get; private set; }
        public float Rotation { get; private set; }

        LevelController _levelController;

        [Inject]
        public void Construct(LevelController levelController)
        {
            _levelController = levelController;
        }

        private void OnEnable()
        {
            _levelController.OnLevelPassed += OnLevelPassed;
        }

        public void Update()
        {
            MoveDirectionInput();
            LookRotation();
        }

        private void OnDestroy()
        {
            _levelController.OnLevelPassed -= OnLevelPassed;
        }

        private void MoveDirectionInput()
        {
            MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }

        private void LookRotation()
        {
            Rotation = Input.GetAxis("Mouse X");
        }

        private void OnLevelPassed()
        {
            enabled = false;

            MoveDirection = Vector3.zero;
            Rotation = 0f;
        }
    }
}
