using UnityEngine;
using Zenject;

namespace RudnTest
{
    public interface IEntityFactory
    {
        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent);
    }

    public class ResourceField : MonoBehaviour, IEntityFactory
    {
        [SerializeField] float _radius;
        [SerializeField] int _resourceAmount;
        [SerializeField] Resource _resourcePrefab;

        DiContainer _container;

        [Inject]
        public void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            for (int i = 0; i < _resourceAmount; i++)
            {
                Vector2 randomPosition = Random.insideUnitCircle * _radius;
                Vector3 spawnPosition = new Vector3(randomPosition.x, _resourcePrefab.PositionY, randomPosition.y);
                Spawn(_resourcePrefab.gameObject, spawnPosition, Quaternion.identity, transform);
            }
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            return _container.InstantiatePrefab(prefab, position, rotation, parent);
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
