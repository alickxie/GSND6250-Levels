using UnityEngine;

public class GearMove : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Adjust the speed as needed
    public bool isClockwise = true; // Set this to false if you want counter-clockwise rotation

    void Update()
    {
        // Determine the rotation direction
        int direction = isClockwise ? 1 : -1;

        // Rotate the gear based on the speed and direction
        transform.Rotate(Vector3.forward, rotationSpeed * direction * Time.deltaTime);
    }
}
