using System;
using UnityEditor;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Player":
                Debug.LogError("Projectile interaction with Player is not yet implemented");
                break;
            case "Enemy":
                Debug.LogError("Projectile interaction with Enemy is not yet implemented");
                break;
            case "Mirror":
                Transform mirrorTransform = other.transform;
                if (IsProjectileCollidingWithFrontOfMirror(mirrorTransform, _transform.position))
                {
                    print("Hit Front of mirror");
                }
                else
                {
                    print("Hit Back of mirror");
                }
                break;
            default:
                Debug.LogWarning($"Projectile interaction triggered with unhandled object, tag was: {other.gameObject.tag}");
                break;
        }
    }

    private static bool IsProjectileCollidingWithFrontOfMirror(Transform mirrorTransform, Vector3 projectilePosition)
    {
        Vector3 mirrorPos = mirrorTransform.position;
        Vector3 mirrorForward = mirrorTransform.right;
        Vector3 pointInfrontOfMirror = mirrorForward + mirrorPos;
        Vector3 pointBehindOfMirror = mirrorForward * -1f + mirrorPos;

        float distanceFromPointInfrontOfMirror = (pointInfrontOfMirror - projectilePosition).magnitude;
        float distanceFromPointBehindOfMirror = (pointBehindOfMirror - projectilePosition).magnitude;
        return distanceFromPointInfrontOfMirror < distanceFromPointBehindOfMirror;
    }
}
