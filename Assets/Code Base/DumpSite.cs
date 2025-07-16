using UnityEngine;

namespace RudnTest
{
    public class DumpSite : MonoBehaviour
    {
        [SerializeField] float _radius;
        [SerializeField] Transform _cylinder;

        private void Start()
        {
            _cylinder.localScale = new Vector3(_radius * 2, _cylinder.localScale.y, _radius * 2);
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