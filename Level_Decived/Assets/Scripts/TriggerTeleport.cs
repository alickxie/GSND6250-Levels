using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    public CharacterController characterController; // Assign the Character Controller in the Inspector
    public Transform destination; // Assign the destination trigger zone in the Inspector

    private bool isTeleporting = false;
    public bool teleportable;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player (or another tagged object) entered the trigger zone
        if (other.CompareTag("Player") && !isTeleporting && teleportable)
        {
            isTeleporting = true;
            TeleportPlayer(other.transform);
        }
    }

    public void SetTrigger(bool x)
    {
        teleportable = x;
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        // Move the player to the destination using the Character Controller
        characterController.enabled = false;
        characterController.transform.position = new Vector3(characterController.transform.position.x, destination.position.y, characterController.transform.position.z);
        characterController.enabled = true;

        // Allow teleportation again
        isTeleporting = false;
    }
}
