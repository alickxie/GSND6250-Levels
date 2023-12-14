using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class catMove : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;

    public Transform[] jumpPoints;
    private int currentJumpPointIndex = 0;

    private bool isGrounded;
    public bool jumpEnabled;

    private Vector3 velocity;

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move.normalized * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && jumpEnabled)
        {
            JumpToPoint();
        }

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void JumpToPoint()
    {
        if (currentJumpPointIndex < jumpPoints.Length - 1)
        {
            currentJumpPointIndex++;
            Vector3 targetPosition = jumpPoints[currentJumpPointIndex].position;
            float jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            velocity.y = jumpVelocity;

            // Set the player's horizontal position to the target jump point
            transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        }
        else
        {
            Debug.LogWarning("No more jump points available.");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform jumpPoint in jumpPoints)
        {
            Gizmos.DrawSphere(jumpPoint.position, 0.2f);
        }
    }

    public void Moveable(bool x)
    {
        speed = x ? 12f : 0f;
    }
}
