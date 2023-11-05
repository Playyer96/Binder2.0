using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _turnSpeed = 90;
    [SerializeField] private float _smoothTime = 3f;

    [SerializeField] private float _minDistance = 1f;

    float _angle;
    private Vector2 _mousePosition;
    private Vector2 _direction;
    private Vector2 _targetVelocity;
    private Rigidbody2D _rb;

    private void Awake()
    {
        TryGetComponent(out _rb);
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void FixedUpdate()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = _mousePosition - (Vector2)transform.position;
        _angle = Vector2.SignedAngle(Vector2.right, _direction);
        _mousePosition += ((Vector2)transform.position - _mousePosition).normalized * _minDistance;
        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, _angle), _turnSpeed * Time.fixedDeltaTime));


        _targetVelocity = (_mousePosition - (Vector2)transform.position) / (_smoothTime * Time.fixedDeltaTime);
        _rb.velocity = Vector2.ClampMagnitude(_targetVelocity, _speed);
    }
}