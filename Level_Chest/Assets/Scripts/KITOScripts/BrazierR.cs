using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazierR : MonoBehaviour
{
    public Transform brazierPosition;  // The position where the torch will be placed
    public ParticleSystem torchParticleSystem;  // Reference to the Particle System
    public AudioSource FireAudioSource;
    public AudioSource torchAudioSource; // Reference to the Audio Source

    public StairController stairController; // Reference to the StairController script

    public bool isLit = false;
    // Start is called before the first frame update
    public void Start()
    {
        // Disable the Particle System initially
        torchParticleSystem.Stop();
        FireAudioSource.Stop();
    }

    public void IgniteBrazier()
    {
        // Move the torch to the brazier's position
        MoveTorchToBrazier();

        // Start the torch's particle system
        torchParticleSystem.Play();

        // Play audio for torch ignition
        torchAudioSource.Play();

        // Ignite the brazier
        // You can play the fire particle system and audio for the brazier here
        FireAudioSource.Play();

        // Mark the brazier as lit
        isLit = true;

        // Call the RaiseStairs method from the StairController script
        stairController.RaiseStairs();

    }

    // Move the torch to the brazier's position
    public void MoveTorchToBrazier()
    {
        // Find the torch in the scene
        GameObject torch = GameObject.FindWithTag("Torch");
        if (torch != null)
        {
            // Set the torch's position to the brazier's position
            torch.transform.position = brazierPosition.position;

            // Rotate the torch 180 degrees (around the Y axis)
            torch.transform.rotation = Quaternion.Euler(0f, 160f, 0f);

            // Set the torch as a child of the brazier's position
            torch.transform.parent = brazierPosition;

            // Deactivate the torch's mesh renderer to hide it
            //.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
