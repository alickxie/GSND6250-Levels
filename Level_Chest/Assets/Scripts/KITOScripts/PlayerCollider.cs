using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public TorchLightController[] torches;  // Reference to all torches in the room
    public PlatformRaiser platform;         // Reference to the platform

    private bool isActivated = false;
    private int currentTorchIndex = 0;     // Index to track the currently activated torch

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            //Debug.Log("Enter");
            StartTorchLightingSequence();
            platform.StartRaising();
        }
    }

    private void StartTorchLightingSequence()
    {
        StartCoroutine(LightTorchesInPairs());
    }


    IEnumerator LightTorchesInPairs()
    {
        while (currentTorchIndex < torches.Length)
        {
            torches[currentTorchIndex].StartCoroutine(torches[currentTorchIndex].LightTorch());

            currentTorchIndex++;
            if (currentTorchIndex < torches.Length)
            {
                torches[currentTorchIndex].StartCoroutine(torches[currentTorchIndex].LightTorch());
                currentTorchIndex++;
            }

            yield return new WaitForSeconds(torches[0].delayBeforeLighting);  // Use the delay from the first torch
        }
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
