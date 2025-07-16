using UnityEngine;
using Zenject;

namespace RudnTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _rotationSpeed;
        [SerializeField] float _pickupRadius;
        [SerializeField] float _pickupOffsetY;

        public CharacterInput CharacterInput { get; private set; }
        public Bag Bag { get; private set; }

        [Inject]
        public void Construct(CharacterInput characterInput, Bag bag)
        {
            CharacterInput = characterInput;
            Bag = bag;
        }

        float _rotation;

        private void FixedUpdate()
        {
            OverlapCollision();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            transform.Translate(CharacterInput.MoveDirection.normalized * _moveSpeed * Time.deltaTime);
        }

        private void Rotate()
        {
            _rotation += CharacterInput.Rotation * _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _rotation, 0f);
        }

        private void OverlapCollision()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position + (Vector3.up * _pickupOffsetY), _pickupRadius);

            foreach (var item in hits)
            {
                if (item.transform.parent.TryGetComponent(out Resource resource))
                {
                    Bag.AddResource();
                    resource.DestroyResource();
                }

                if (item.transform.root.TryGetComponent(out DumpSite dumpSite))
                    dumpSite.AddResource(Bag);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + (Vector3.up * _pickupOffsetY), _pickupRadius);
        }
#endif
    }
}
