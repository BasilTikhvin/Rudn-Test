using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] Vector2 _cameraOffset;
        [SerializeField] float _cameraDistance;
        [SerializeField] float _cameraHeight;
        [SerializeField] float _rotationSpeed;

        Character _playerCharacter;

        [Inject]
        public void Construct(Character playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        private void Start()
        {
            Vector3 targetPosition = _playerCharacter.transform.position - _playerCharacter.transform.forward * _cameraDistance;
            targetPosition.y = _playerCharacter.transform.position.y + _cameraHeight;
            transform.position = targetPosition;

            RotateCamera();
        }

        private void LateUpdate()
        {
            MoveCamera();
            RotateCamera();
        }

        private void MoveCamera()
        {
            Vector3 targetPosition = _playerCharacter.transform.position - _playerCharacter.transform.forward * _cameraDistance;
            targetPosition.y = _playerCharacter.transform.position.y + _cameraHeight;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _rotationSpeed * Time.deltaTime);
        }

        private void RotateCamera()
        {           
            Vector3 lookPosition = _playerCharacter.transform.position + _playerCharacter.transform.forward * _cameraDistance;
            transform.LookAt(lookPosition);
        }
    }
}
