using System.Threading;
using UnityEngine;

namespace RudnTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _rotationSpeed;
        
        CharacterInput _characterInput;
        float _mouseX;

        private void Awake()
        {
            _characterInput = GetComponentInChildren<CharacterInput>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            transform.Translate(_characterInput.Direction.normalized * _moveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            _mouseX += _characterInput.Rotation * _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _mouseX, 0f);
        }
    }
}
