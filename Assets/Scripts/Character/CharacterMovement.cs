using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float avoidanceRadius = 0.2f;

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            MoveCharacter();
            RotateCharacter();
        }
    }

    private void OnDrawGizmos()
    {
        // Draw the avoidance radius in the scene view.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, avoidanceRadius);
    }

    private void MoveCharacter()
    {
        Vector2 direction = targetPosition - rb.position;

        // Check for obstacles within the avoidanceRadius using OverlapCircle.
        Collider2D[] hits = Physics2D.OverlapCircleAll(rb.position, avoidanceRadius);

        bool shouldMove = true;

        foreach (var hit in hits)
        {
            if (hit.gameObject != gameObject)
            {
                // An obstacle is detected, stop moving.
                shouldMove = false;
                break;
            }
        }

        if (shouldMove)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
        else
        {
            isMoving = false;
        }
    }

    private void RotateCharacter()
    {
        Vector2 direction = targetPosition - rb.position;
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}