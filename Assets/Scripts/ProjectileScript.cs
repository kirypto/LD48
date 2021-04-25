using System;
using Health;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float initialFiringForce = 1f;
    [SerializeField] private float collisionDelay = 1f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private AudioClip soundSpan;
    [SerializeField] private AudioClip soundDamage;
    [SerializeField] private AudioClip soundWall;
    [SerializeField] private AudioClip soundReflection;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private float _speed = 1f;
    private bool _isDisabled = true;
    private bool _launched;
    private bool _playSpawnSound = true;

    private Vector2 LaunchVector => _transform.right * _speed * initialFiringForce;

    public void Initialize(
            float? speed = null, float? collisionDelaySeconds = null, float? projectileDamage = null, bool playSpawnSound = true)
    {
        if (_launched)
        {
            throw new NotSupportedException($"Cannot invoke {nameof(Initialize)} after projectile has launched.");
        }

        if (speed != null)
        {
            _speed = speed.Value;
        }

        if (collisionDelaySeconds != null)
        {
            collisionDelay = collisionDelaySeconds.Value;
        }

        if (projectileDamage != null)
        {
            damage = projectileDamage.Value;
        }

        _playSpawnSound = playSpawnSound;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    private void Start()
    {
        _launched = true;
        _rigidbody2D.AddForce(LaunchVector);
        DelayCollisions();
        if (_playSpawnSound) { }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string otherColliderTag = other.gameObject.tag;
        if ("Wall" == otherColliderTag)
        {
            Destroy(gameObject);
            return;
        }

        if (_isDisabled)
        {
            return;
        }

        switch (otherColliderTag)
        {
            case "Player":
            case "Enemy":
                IHealthSystem otherHealthSystem = other.GetComponent<IHealthSystem>();
                otherHealthSystem.DealDamage(damage);
                Destroy(gameObject);
                break;
            case "Mirror":
                Transform mirrorTransform = other.transform;
                if (IsProjectileCollidingWithFrontOfMirror(mirrorTransform, _transform.position))
                {
                    Vector2 reflectionVector = Vector2.Reflect(transform.right, mirrorTransform.right);
                    _transform.right = reflectionVector.normalized;
                    _rigidbody2D.velocity = Vector2.zero;
                    _rigidbody2D.AddForce(LaunchVector);
                    DelayCollisions();
                }

                break;
            default:
                Debug.LogWarning($"Projectile interaction triggered with unhandled object, tag was: {otherColliderTag}");
                break;
        }
    }

    private void DelayCollisions()
    {
        _isDisabled = true;
        Invoke(nameof(EnableCollisions), collisionDelay);
    }

    private void EnableCollisions()
    {
        _isDisabled = false;
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
