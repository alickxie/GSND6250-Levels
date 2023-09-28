using UnityEngine;

public class PlayerBoxPush : MonoBehaviour
{
    public static PlayerBoxPush Instance { get; private set; }

    public float pushForce = 10f;
    public float dragForce = 5f;

    private GameObject attachedBox;
    private BoxController attachedBoxController; // Reference to the box's script.
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
            // Calculate the force based on whether the player is pushing or dragging.
            float force = Input.GetKey(KeyCode.W) ? pushForce : Input.GetKey(KeyCode.S) ? -dragForce : 0;

            // Calculate the movement direction based on the box's transformation.
            Vector3 moveDirection = attachedBox.transform.forward;

            // Apply force to the box.
            attachedBox.transform.position += moveDirection * force * Time.deltaTime;

            // Update the player's position based on the box's transformation and initial offset.
            transform.position = attachedBox.transform.position - initialOffsetFromBox;
        }
    }

    void TryAttachToBox()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Box"))
            {
                isAttached = true;
                attachedBox = hit.collider.gameObject;
                
                // Get a reference to the box's script.
                attachedBoxController = attachedBox.GetComponent<BoxController>();
                
                // Calculate the initial offset between the player and the box.
                initialOffsetFromBox = attachedBox.transform.position - transform.position;
                
                // Inform the box that the player is attached.
                attachedBoxController.AttachPlayer(this.gameObject);
            }
        }
    }

    void DetachFromBox()
    {
        isAttached = false;
        attachedBox = null;
    }
}
