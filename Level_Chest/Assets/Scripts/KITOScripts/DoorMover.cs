using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public float moveAmount;  // Amount to move the door (adjust as needed)
    public float moveDuration;

    private float moveStartTime;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    public AudioSource doorAudioSource; // Reference to the Audio Source for the door moving sound

    public void MoveDoor()
    {
        // Store the initial position and calculate the target position
        initialPosition = transform.position;
        targetPosition = transform.position + new Vector3(0, 0, moveAmount);

        // Store the start time
        moveStartTime = Time.time;

        // Play the door moving sound
        doorAudioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                // Check if it's time to move the door
        if (Time.time - moveStartTime < moveDuration)
        {
            // Calculate the lerp factor
            float t = (Time.time - moveStartTime) / moveDuration;

            // Interpolate between the initial and target positions
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
    }
}
