using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorchHold : MonoBehaviour
{
    public Transform torchHoldingPosition;  // The position where the torch will be held
    public DoorMover doorMover;  // Reference to the DoorMover script attached to the door
    private bool okToMove = true;

    public GameObject torch;
    public GameObject brazier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && torch != null)
        {
            // Set the torch's position and parent to the holding position
            torch.transform.position = torchHoldingPosition.position;
            torch.transform.parent = torchHoldingPosition;
            //torch.SetActive(true);
            // Move the door using the DoorMover script
            if (doorMover != null && okToMove)
            {
                //Debug.Log("Step1");
                doorMover.MoveDoor();
                okToMove = false;
            }
        }

    }

    // Function to set the torch the player is holding
    public void SetTorch(GameObject torchObject)
    {
        torch = torchObject;
    }

    // Function to set the reference to the brazier in the other room
    public void SetBrazier(GameObject brazierObject)
    {
        brazier = brazierObject;
    }
}
