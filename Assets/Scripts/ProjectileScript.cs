using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float initialFiringForce = 1f;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private float _speed = 1f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    private void Start()
    {
        _rigidbody2D.AddForce(_transform.right * _speed * initialFiringForce);
    }

    public void Initialize(float speed = 1f)
    {
        _speed = speed;
    }
}
