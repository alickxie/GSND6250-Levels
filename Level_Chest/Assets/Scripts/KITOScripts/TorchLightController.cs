using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightController : MonoBehaviour
{
    public float delayBeforeLighting;  // Time delay before lighting (adjust as needed)
    public ParticleSystem torchParticleSystem;  // Reference to the Particle System
    public AudioSource FireAudioSource;
    public AudioSource torchAudioSource; // Reference to the Audio Source

    private bool isLit = false;
    void Start()
    {
        // Disable the Particle System initially
        torchParticleSystem.Stop();
        FireAudioSource.Stop();
    }

    public IEnumerator LightTorch()
    {
        if (isLit) yield break;  // If the torch is already lit, do nothing
        yield return new WaitForSeconds(delayBeforeLighting);
        // Start the Particle System to simulate the torch lighting up
        torchParticleSystem.Play();

        // Play the audio when the torch lights up
        torchAudioSource.Play();
        FireAudioSource.Play();

        isLit = true;
    }
}
