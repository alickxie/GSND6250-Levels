using UnityEngine;

public class PlayerBoxPush : MonoBehaviour
{
    public static PlayerBoxPush Instance { get; private set; }

    public float pushForce = 10f;
    public float dragForce = 5f;
    public float maxRaycastDistance = 2f; // Maximum distance for raycasting.

    private GameObject attachedBox;
    public bool isAttached = false;

    private Vector3 initialOffsetFromBox;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isAttached)
            {
                TryAttachToBox();
            }
            else
            {
                DetachFromBox();
            }
        }

        if (isAttached)
        {
            // Calculate the force based on whether the player is dragging.
            float force = Input.GetKey(KeyCode.S) ? -dragForce : 0;

            // Check if the box is currently attached and if it collides with a wall.
            if (attachedBox != null && IsBoxCollidingWithWall(attachedBox))
            {
                force = 0; // Stop applying pushing force when colliding with a wall.
            }
            else if (Input.GetKey(KeyCode.W))
            {
                force = pushForce; // Apply pushing force only when the "W" key is pressed.
            }

            // Calculate the movement direction based on the box's transformation.
            Vector3 moveDirection = attachedBox.transform.forward;

            // Apply the force directly to the box.
            attachedBox.transform.position += moveDirection * force * Time.deltaTime;

            // Update the player's position based on the box's transformation and initial offset.
            transform.position = attachedBox.transform.position - initialOffsetFromBox;
        }
    }

    void TryAttachToBox()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRaycastDistance))
        {
            if (hit.collider.CompareTag("Box"))
            {
                isAttached = true;
                attachedBox = hit.collider.gameObject;

                // Calculate the initial offset between the player and the box.
                initialOffsetFromBox = attachedBox.transform.position - transform.position;
            }
        }
    }

    void DetachFromBox()
    {
        isAttached = false;
        attachedBox = null;
    }

    bool IsBoxCollidingWithWall(GameObject box)
    {
        // Cast a ray in the forward direction of the box to check for collisions with walls.
        RaycastHit hit;
        Vector3 raycastDirection = box.transform.forward;
        float raycastDistance = 0.5f;

        if (Physics.Raycast(box.transform.position, raycastDirection, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Wall") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                return true; // The box is colliding with a wall.
            }
        }

        return false; // No collision with a wall detected.
    }
}
