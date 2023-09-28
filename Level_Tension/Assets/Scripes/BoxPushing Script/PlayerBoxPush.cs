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
    
    public Vector3 pushDirection;
    public Transform camera;

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
            // Calculate the force based on whether the player is pushing or dragging.
            float force = Input.GetKey(KeyCode.W) ? pushForce : Input.GetKey(KeyCode.S) ? -dragForce : 0;

            // Calculate the movement direction based on the box's transformation.
            Vector3 moveDirection = pushDirection;

            // Apply force to the box.
            attachedBox.transform.position += moveDirection * force * Time.deltaTime;

            // Update the player's position based on the box's transformation and initial offset.
            transform.position = attachedBox.transform.position - initialOffsetFromBox;
        }
    }

    void TryAttachToBox()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxRaycastDistance))
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(camera.position, camera.forward * maxRaycastDistance);
    }
}