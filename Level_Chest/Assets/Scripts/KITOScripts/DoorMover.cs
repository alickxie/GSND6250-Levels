using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public float moveAmount = 2.0f;  // Amount to move the door (adjust as needed)

    public void MoveDoor()
    {
        // Move the door to the right
        Debug.Log("Open");
        transform.Translate(Vector3.right * moveAmount);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
