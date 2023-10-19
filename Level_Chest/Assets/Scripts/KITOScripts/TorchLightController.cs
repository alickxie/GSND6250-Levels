using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightController : MonoBehaviour
{
    public float delayBeforeLighting = 2.0f;  // Time delay before lighting (adjust as needed)
    public ParticleSystem torchParticleSystem;  // Reference to the Particle System

    void Start()
    {
        // Disable the Particle System initially
        torchParticleSystem.Stop();
    }

    public IEnumerator LightTorch()
    {
        yield return new WaitForSeconds(delayBeforeLighting);
        // Start the Particle System to simulate the torch lighting up
        torchParticleSystem.Play();
    }
}
