using UnityEngine;

namespace RudnTest
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] float _cameraDistance;
        [SerializeField] float _cameraHeight;
        [SerializeField] float _rotationSpeed;
        [SerializeField] Transform _character;

        Vector3 _cameraOffset;

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
            Vector3 desiredPosition = _character.position - _character.forward * _cameraDistance;
            desiredPosition.y = _character.position.y + _cameraHeight;

            transform.position = Vector3.Lerp(transform.position,desiredPosition,_rotationSpeed * Time.deltaTime);

            transform.LookAt(_character);
        }
    }
}
