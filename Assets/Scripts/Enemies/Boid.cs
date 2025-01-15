using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Boid : MonoBehaviour
    {
        private Transform _transform;
        public ChaseBehavior chaseBehavior = ChaseBehavior.ChaseIfInRange; // Default behavior
        public Transform target; // Target to chase
        public float chaseSpeedMultiplier = 1.5f; // Multiplier for speed while chasing
        public Vector2 velocity;

        private float baseSpeed = 5f; // Normal speed
        private float currentSpeed; // Current speed, adjusted for chasing

        // Other fields like separation, alignment, etc.

        public float separationRadius = 1.5f;
        public float neighborRadius = 3f;

        public int WeightGroup { get; private set; }
        public bool IsSeparated { get; private set; }

        private Camera mainCamera;
        private float speedChangeInterval;
        private float speedChangeTimer;
        private float separationTimer;
        private float separationDuration;
        private float minSpeed;
        private float maxSpeed;

        [SerializeField] private float chaseRange = 10f; // Distance at which the boid starts chasing the target.


        private void Start()
        {
            TryGetComponent(out _transform);
        }

        public void SetCamera(Camera camera)
        {
            mainCamera = camera;
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public void InitializeBoid(Transform target, int weightGroup, float baseSpeed, float speedChangeInterval,
            float minSpeed, float maxSpeed)
        {
            this.target = target;
            this.WeightGroup = weightGroup;
            this.baseSpeed = baseSpeed;
            this.speedChangeInterval = speedChangeInterval;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;

            speedChangeTimer = Random.Range(0, speedChangeInterval);
            separationTimer = Random.Range(5f, 15f); // Random initial separation timer
        }

        public void UpdateBoid(Vector2 separation, Vector2 alignment, Vector2 cohesion)
        {
            Vector2 targetForce = Vector2.zero;
            bool isChasing = false;

            // Check behavior type and apply chase logic
            if (target != null)
            {
                switch (chaseBehavior)
                {
                    case ChaseBehavior.AlwaysChase:
                        targetForce = ((Vector2)target.position - (Vector2)_transform.position).normalized;
                        isChasing = true;
                        break;

                    case ChaseBehavior.ChaseIfInRange:
                        if (Vector2.Distance((Vector2)_transform.position, (Vector2)target.position) <= chaseRange)
                        {
                            targetForce = ((Vector2)target.position - (Vector2)_transform.position).normalized;
                            isChasing = true;
                        }

                        break;

                    case ChaseBehavior.NoChase:
                        // Don't chase, so no target force
                        break;
                }
            }

            // Adjust speed if chasing
            currentSpeed = isChasing ? baseSpeed * chaseSpeedMultiplier : baseSpeed;

            // Apply movement forces: separation, alignment, cohesion + target force
            velocity += (separation + alignment + cohesion + targetForce).normalized * currentSpeed * Time.deltaTime;
            velocity = Vector2.ClampMagnitude(velocity, currentSpeed);
            _transform.position += (Vector3)velocity * Time.deltaTime;

            KeepInBounds();
        }

        public void HandleRandomSeparation()
        {
            separationTimer -= Time.deltaTime;
            if (separationTimer <= 0 && !IsSeparated)
            {
                IsSeparated = Random.value < 0.3f; // 30% chance to separate
                separationDuration = Random.Range(3f, 8f); // Random separation time
                separationTimer = Random.Range(10f, 20f); // Reset separation timer
            }

            if (IsSeparated)
            {
                separationDuration -= Time.deltaTime;
                if (separationDuration <= 0)
                {
                    IsSeparated = false; // Rejoin the flock
                }
            }
        }

        public void HandleSpeedChange()
        {
            speedChangeTimer -= Time.deltaTime;
            if (speedChangeTimer <= 0)
            {
                baseSpeed = Random.Range(minSpeed, maxSpeed); // Adjust speed within range
                speedChangeTimer = speedChangeInterval; // Reset timer
            }
        }

        private void KeepInBounds()
        {
            Vector3 pos = _transform.position;
            Vector3 viewportPos = mainCamera.WorldToViewportPoint(pos);

            if (viewportPos.x < 0) pos.x = mainCamera.ViewportToWorldPoint(Vector3.right).x;
            if (viewportPos.x > 1) pos.x = mainCamera.ViewportToWorldPoint(Vector3.zero).x;
            if (viewportPos.y < 0) pos.y = mainCamera.ViewportToWorldPoint(Vector3.up).y;
            if (viewportPos.y > 1) pos.y = mainCamera.ViewportToWorldPoint(Vector3.zero).y;

            _transform.position = pos;
        }
    }
}