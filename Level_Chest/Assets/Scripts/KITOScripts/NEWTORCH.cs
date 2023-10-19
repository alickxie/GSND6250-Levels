using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWTORCH : MonoBehaviour
{
    public Transform torchHoldingPosition;  // The position where the torch will be held
    public DoorMover doorMover;  // Reference to the DoorMover script attached to the door
    public GameObject brazier;  // Reference to the brazier in the other room

    public BrazierR brazierScript; // Reference to the BrazierR script
    public AudioSource trapAudioSource;  // Reference to the Audio Source for impact sound

    private bool isHeld = false;
    private bool trapSoundPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (!isHeld && Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, torchHoldingPosition.position) < 2f)
            {
                HoldTorch();
            }
        }
        if (isHeld && Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, brazier.transform.position) < 2f)
            {
                brazierScript.IgniteBrazier();
            }
        }
 
    }

    // Function to pick up the torch
    private void HoldTorch()
    {
        // Set the torch's position and parent to the holding position
        transform.position = torchHoldingPosition.position;
        transform.parent = torchHoldingPosition;

        // Move the door using the DoorMover script
        if (doorMover != null)
        {
            doorMover.MoveDoor();
        }

        isHeld = true;

        // Play the impact sound
        if (!trapAudioSource.isPlaying && !trapSoundPlayed)
        {
            trapAudioSource.Play();
            trapSoundPlayed = true;
        }
    }

}