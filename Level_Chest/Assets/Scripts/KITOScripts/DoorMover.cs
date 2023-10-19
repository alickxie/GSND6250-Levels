using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public float moveAmount;  // Amount to move the door (adjust as needed)
    public float moveDuration;
    public AudioSource doorAudioSource; // Reference to the Audio Source for the door moving sound

    private bool isMoving = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float moveStartTime;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position when the game starts
        initialPosition = transform.position;
    }

    public void MoveDoor()
    {
        if (isMoving) return; // If the door is already moving, do nothing

        // Calculate the target position based on the moveAmount along the Z-axis
        targetPosition = initialPosition + transform.forward * moveAmount;

        // Store the start time
        moveStartTime = Time.time;

        // Play the door moving sound
        doorAudioSource.Play();

        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Calculate the lerp factor
            float t = (Time.time - moveStartTime) / moveDuration;

            // Interpolate between the initial and target positions
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            // Check if the door has reached the target position
            if (t >= 1.0f)
            {
                isMoving = false; // Stop moving
            }
        }
    }
}
