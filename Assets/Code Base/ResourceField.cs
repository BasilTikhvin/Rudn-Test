using UnityEngine;

namespace RudnTest
{
    public class ResourceField : MonoBehaviour
    {
        [SerializeField] float _radius;
        [SerializeField] int _resourceAmount;
        [SerializeField] Resource _resourcePrefab;

        private void Start()
        {
            for (int i = 0; i < _resourceAmount; i++)
            {
                Vector2 randomPos = Random.insideUnitCircle * _radius;
                Vector3 pos = new Vector3(randomPos.x, _resourcePrefab.PositionY, randomPos.y);
                Instantiate(_resourcePrefab, pos, Quaternion.identity, transform);
            }
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
