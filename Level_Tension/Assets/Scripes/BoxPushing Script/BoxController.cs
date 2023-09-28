using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float pushForce = 10f;
    public float dragForce = 5f;

    private GameObject attachedPlayer;
    private Vector3 initialPlayerOffset;

    void Update()
    {
        // Check if a player is attached.
        if (attachedPlayer != null)
        {
            // Calculate the movement direction based on the attachment side.
            Vector3 moveDirection = transform.forward;
            
            // Apply force to the box based on player input.
            float force = Input.GetKey(KeyCode.W) ? pushForce : Input.GetKey(KeyCode.S) ? -dragForce : 0;
            transform.position += moveDirection * force * Time.deltaTime;

            // Move the player with the box.
            attachedPlayer.transform.position = transform.position - initialPlayerOffset;
        }
    }

    // Method to attach the player to the box.
    public void AttachPlayer(GameObject player)
    {
        attachedPlayer = player;
        initialPlayerOffset = player.transform.position - transform.position;
    }
}
