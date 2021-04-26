using System.Collections;
using Health;
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

    private void Awake() {
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

    private void LookAtMouse() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint((Vector2) Input.mousePosition);

        Vector2 vectorToMouse = ((Vector2) (mousePosition - transform.position)).normalized;
        transform.right = vectorToMouse;
    }

    private void HandleDirectionalInput() {
        if (UpHeld()) {
            _rigidbody.AddForce(Vector2.up * _movementForce);
        }

        if (LeftHeld()) {
            _rigidbody.AddForce(Vector2.left * _movementForce);
        }

        if (DownHeld()) {
            _rigidbody.AddForce(Vector2.down * _movementForce);
        }

        if (RightHeld()) {
            _rigidbody.AddForce(Vector2.right * _movementForce);
        }
    }

    private static bool UpHeld() {
        return Input.GetKey(KeyCode.W);
    }

    private static bool LeftHeld() {
        return Input.GetKey(KeyCode.A);
    }

    private static bool DownHeld() {
        return Input.GetKey(KeyCode.S);
    }

    private static bool RightHeld() {
        return Input.GetKey(KeyCode.D);
    }
}
