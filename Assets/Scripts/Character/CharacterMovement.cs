using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")] [SerializeField]
    private float speed = 5f;

    [SerializeField] private float turnSpeed = 360f;
    [SerializeField] private float smoothTime = 15f;
    [SerializeField] private float minDistance = 1f;

    [Header("Cartoonish Effects")] [SerializeField]
    private float bounceAmplitude = 0.1f;

    [SerializeField] private float bounceFrequency = 1f;
    [SerializeField] private float wobbleAngle = 15f;
    [SerializeField] private float wobbleSpeed = 5f;

    private float _angle;
    private Vector2 _mousePosition;
    private Vector2 _direction;
    private Vector2 _targetVelocity;
    private Rigidbody2D _rb;
    private float _time;

    private void Awake()
    {
        TryGetComponent(out _rb);
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = _mousePosition - (Vector2)transform.position;
        _angle = Vector2.SignedAngle(Vector2.right, _direction);

        _mousePosition += ((Vector2)transform.position - _mousePosition).normalized * minDistance;

        // Cartoonish bounce to position
        Vector2 bounceOffset = new Vector2(0, Mathf.Sin(_time * bounceFrequency) * bounceAmplitude);
        Vector2 target = _mousePosition + bounceOffset;

        // Rotate with a wobble effect
        float wobble = Mathf.Sin(_time * wobbleSpeed) * wobbleAngle;
        Quaternion targetRotation = Quaternion.Euler(0, 0, _angle + wobble);
        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));

        _targetVelocity = (target - (Vector2)transform.position) / (smoothTime * Time.fixedDeltaTime);
        _rb.linearVelocity = Vector2.ClampMagnitude(_targetVelocity, speed);
    }
}