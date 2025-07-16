using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _positionY;

    public float PositionY => _positionY;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }

    private void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }
}
