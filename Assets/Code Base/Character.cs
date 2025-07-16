using UnityEngine;

namespace RudnTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _rotationSpeed;
        [SerializeField] float _pickupRadius;

        public CharacterInput CharacterInput { get; private set; }
        public Bag Bag { get; private set; }

        float _rotation;

        private void Awake()
        {
            CharacterInput = GetComponentInChildren<CharacterInput>();
            Bag = new Bag();
        }

        private void Update()
        {
            Move();
            Rotate();
            OverlapCollision();
        }

        private void Move()
        {
            transform.Translate(CharacterInput.Direction.normalized * _moveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            _rotation += CharacterInput.Rotation * _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _rotation, 0f);
        }

        private void OverlapCollision()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _pickupRadius);

            foreach (var item in hits)
            {
                if (item.transform.parent.TryGetComponent(out Resource res))
                {
                    Destroy(res.gameObject);
                    Bag.AddResource();
                }

                if (item.transform.root.TryGetComponent(out DumpSite dumpSite))
                    dumpSite.AddResource(Bag);
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
