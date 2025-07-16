using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] float _cameraDistance;
        [SerializeField] float _cameraHeight;
        [SerializeField] float _rotationSpeed;

        //Vector3 _cameraOffset;

        Character _playerCharacter;

        [Inject]
        public void Construct(Character playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        private void Start()
        {
            Vector3 desiredPosition = _playerCharacter.transform.position - _playerCharacter.transform.forward * _cameraDistance;
            desiredPosition.y = _playerCharacter.transform.position.y + _cameraHeight;
            transform.position = desiredPosition;

            Vector3 lookPosition = _playerCharacter.transform.position + _playerCharacter.transform.forward * _cameraDistance;
            transform.LookAt(lookPosition);
        }

        private void LateUpdate()
        {
            //SetCameraOffset();
            RotateCamera();
        }

        //private void SetCameraOffset()
        //{
        //    _cameraOffset = -_character.forward * _cameraDistance;
        //    _cameraOffset.y = _cameraHeight;


        //    transform.position = _character.position + _cameraOffset;
        //}

        private void RotateCamera()
        {           
            Vector3 desiredPosition = _playerCharacter.transform.position - _playerCharacter.transform.forward * _cameraDistance;
            desiredPosition.y = _playerCharacter.transform.position.y + _cameraHeight;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, _rotationSpeed * Time.deltaTime);

            Vector3 lookPosition = _playerCharacter.transform.position + _playerCharacter.transform.forward * _cameraDistance;
            transform.LookAt(lookPosition);
        }
    }
}
