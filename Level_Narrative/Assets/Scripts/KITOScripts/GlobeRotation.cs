using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeRotation : MonoBehaviour
{
    private bool isRotating = false;
    [SerializeField] private float rotationDuration; // Duration of rotation in seconds
    [SerializeField] private float rotationAmount; // Rotation amount in degrees
    private float rotationSpeed; // Rotation speed in degrees per second
    private Quaternion initialRotation; // Initial rotation before starting the rotation
    private Quaternion targetRotation; // Target rotation after rotating by the specified amount
    private bool isRotated = false;
    public AudioSource rotationSound; // Sound to play while rotating

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.localRotation; // Use localRotation for the child object
        targetRotation = initialRotation * Quaternion.Euler(0, 0, -rotationAmount); // Rotate by the specified amount around Z-axis (opposite direction)
        rotationSpeed = rotationAmount / rotationDuration; // Calculate rotation speed
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            // Rotate the child object
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (transform.localRotation == targetRotation)
            {
                isRotating = false;

                // Stop the audio when the rotation is complete
                rotationSound.Stop();
            }
        }
    }

    public void RotateUpperHolder()
    {
        if (!isRotating&&!isRotated)
        {
            // Set the initial rotation to the current local rotation
            initialRotation = transform.localRotation;

            // Calculate the target local rotation (specified rotation amount around Z-axis, opposite direction)
            targetRotation = initialRotation * Quaternion.Euler(0, 0, -rotationAmount);

            // Calculate the rotation speed based on the specified rotation amount and duration
            rotationSpeed = rotationAmount / rotationDuration;

            // Start rotating
            isRotating = true;

            // Play the audio when rotation starts
            if (rotationSound != null && rotationSound != null)
            {
                rotationSound.Play();
            }
        }
        isRotated = true;
    }
}
