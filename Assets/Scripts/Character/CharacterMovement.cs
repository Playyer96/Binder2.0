using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float offsetDistance = 1.0f; // Desired distance in front of the character.

    private Rigidbody2D rb;
    private Vector3 targetPosition;
    private bool isMoving;
    private Vector3 offset; // Declare the offset variable at the class level.

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
        targetPosition.z = transform.position.z;
        isMoving = true;

        // Calculate the offset based on the character's local forward direction and desired distance.
        offset = transform.TransformDirection(Vector3.right) * offsetDistance;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        Vector3 direction = (targetPosition - (transform.position + offset));
        if (direction.magnitude > 0.1f)
        {
            Vector2 newPosition = Vector2.Lerp(transform.position, targetPosition - offset, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
        else
        {
            isMoving = false;
        }
        RotateCharacter();
    }

    private void RotateCharacter()
    {
        Vector2 direction = (targetPosition - (transform.position + offset)).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
    }
}