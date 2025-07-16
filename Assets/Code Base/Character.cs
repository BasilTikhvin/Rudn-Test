using UnityEngine;

namespace RudnTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _rotationSpeed;
        [SerializeField] float _pickupRadius;
        [SerializeField] LayerMask _resourceLayer;
        
        public Bag Bag { get; private set; }

        CharacterInput _characterInput;
        float _rotation;

        private void Awake()
        {
            _characterInput = GetComponentInChildren<CharacterInput>();
            Bag = new Bag();
        }

        private void Update()
        {
            Move();
            Rotate();
            FindResource();
        }

        private void Move()
        {
            transform.Translate(_characterInput.Direction.normalized * _moveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            _rotation += _characterInput.Rotation * _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _rotation, 0f);
        }

        private void FindResource()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _pickupRadius, _resourceLayer);

            foreach (var item in hits)
            {
                if (item.transform.parent.TryGetComponent(out Resource res))
                {
                    Destroy(res.gameObject);
                    Bag.AddResource();
                    Debug.Log(Bag.ResourceAmount);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _pickupRadius);
        }
#endif
    }
}
