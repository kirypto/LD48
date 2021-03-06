using System;
using System.Collections;
using Health;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IHealthSystem))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float _movementForce = 1f;

    // TODO: Move this out of movement script
    [SerializeField] private AudioClip deathClip;

    private Rigidbody2D _rigidbody;
    private IHealthSystem _playerHealth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<IHealthSystem>();
        _playerHealth.OnWaveDeath += playerHealth =>
        {
            AudioClipPlayer.PlayAudioAtLocation(deathClip, transform.position);
            if (playerHealth.IsPermaDead)
            {
                StartCoroutine(nameof(SlowAndDeath));
            }
        };
    }

    private IEnumerator SlowAndDeath()
    {
        Time.timeScale = 0.75f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0.35f;
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.35f);
        Time.timeScale = 0f;
        for (float alpha = 0; alpha <= 1; alpha += 0.02f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            MainUIScript.SetBlackoutAlpha(alpha);
        }
        StopCoroutine(nameof(SlowAndDeath));
        SceneManager.LoadScene("GameOver");
    }

    private void Update() {
        LookAtMouse();
        if (Input.GetKey(KeyCode.Backslash))
        {
            float lostHealth = _playerHealth.HealthMax - _playerHealth.Health;
            if (lostHealth > 0f)
            {
                _playerHealth.DealDamage(-lostHealth);
            }
        }
    }

    private void FixedUpdate() {
        HandleDirectionalInput();       
    }

    private Vector3 _lastMouseScreenPos;
    private bool _lookModeIsJoystick = false;

    private void LookAtMouse() {
        float xCameraLookJoystick = Input.GetAxis("Roll");
        float yCameraLookJoystick = Input.GetAxis("Pitch");

        Vector2 cameraLookFromJoystick = new Vector2(xCameraLookJoystick, yCameraLookJoystick);
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector2 cameraLookFromMouse = ((Vector2) (_camera.ScreenToWorldPoint(mouseScreenPosition) - transform.position)).normalized;
        if (cameraLookFromJoystick.magnitude > 0f)
        {
            _lookModeIsJoystick = true;
        }
        else if (_lastMouseScreenPos != mouseScreenPosition)
        {
            _lookModeIsJoystick = false;
        }
        _lastMouseScreenPos = mouseScreenPosition;


        Vector2 lookDirection = _lookModeIsJoystick ? cameraLookFromJoystick : cameraLookFromMouse;
        if (lookDirection.magnitude > 0f)
        {
            Vector2 lookDirectionNorm = lookDirection.normalized;
            float angle = Mathf.Atan2(lookDirectionNorm.y,lookDirectionNorm.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void HandleDirectionalInput()
    {
        float xMovement = Input.GetAxis("Horizontal") + Input.GetAxis("Horizontal2");
        float yMovement = Input.GetAxis("Vertical") + Input.GetAxis("Vertical2");

        Vector2 movementVector = new Vector2(xMovement, yMovement);
        if (movementVector.magnitude > 0f)
        {
            Vector2 movementClamped = movementVector.magnitude > 1f ? movementVector.normalized : movementVector;
            _rigidbody.AddForce(movementClamped * _movementForce);
        }
    }
}
