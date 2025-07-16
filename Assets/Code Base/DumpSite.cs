using UnityEngine;
using UnityEngine.Events;

namespace RudnTest
{
    public class DumpSite : MonoBehaviour
    {
        public event UnityAction<int> OnResourceAmountChange;

        [SerializeField] float _radius;
        [SerializeField] Transform _view;

        public int ResourceAmount { get; private set; }

        private void Start()
        {
            _view.localScale = Vector3.one * (_radius * 2f);
            OnResourceAmountChange?.Invoke(ResourceAmount);
        }

        public void AddResource(Bag bag)
        {
            ResourceAmount += bag.ResourceAmount;
            bag.RemoveAllResources();
            OnResourceAmountChange?.Invoke(ResourceAmount);
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