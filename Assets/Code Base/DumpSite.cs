using UnityEngine;
using UnityEngine.Events;

namespace RudnTest
{
    public class DumpSite : MonoBehaviour
    {
        public event UnityAction<int> ResourceChange;

        [SerializeField] float _radius;
        [SerializeField] Transform _cylinder;

        public int ResourceAmount { get; private set; }

        private void Start()
        {
            _cylinder.localScale = new Vector3(_radius * 2, _cylinder.localScale.y, _radius * 2);
            ResourceChange?.Invoke(ResourceAmount);
        }

        public void AddResource(Bag bag)
        {
            ResourceAmount += bag.ResourceAmount;
            bag.RemoveResource();
            ResourceChange?.Invoke(ResourceAmount);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
#endif
    }
}