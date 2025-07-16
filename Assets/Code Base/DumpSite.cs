using UnityEngine;
using UnityEngine.Events;

namespace RudnTest
{
    public class DumpSite : MonoBehaviour
    {
        public event UnityAction<int> ResourceChange;

        [SerializeField] float _radius;
        [SerializeField] Transform _cylinder;

        int _resourceAmount;

        private void Start()
        {
            _cylinder.localScale = new Vector3(_radius * 2, _cylinder.localScale.y, _radius * 2);
            ResourceChange?.Invoke(_resourceAmount);
        }

        public void AddResource(Bag bag)
        {
            _resourceAmount += bag.ResourceAmount;
            bag.RemoveResource();
            ResourceChange?.Invoke(_resourceAmount);
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