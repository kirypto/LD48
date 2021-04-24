using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float _movementForce = 1f;

    private Rigidbody2D _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        LookAtMouse();
    }

    private void FixedUpdate() {
        HandleDirectionalInput();       
    }

    private void LookAtMouse() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector2(Input.mousePosition.x, Input.mousePosition.y));

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