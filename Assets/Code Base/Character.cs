using UnityEngine;

namespace RudnTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        
        CharacterInput _characterInput;

        private void Awake()
        {
            _characterInput = GetComponentInChildren<CharacterInput>();
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.Translate(_characterInput.Direction.normalized * _moveSpeed * Time.deltaTime);
        }
    }
}
