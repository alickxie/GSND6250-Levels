using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRaiser : MonoBehaviour
{
    public float raiseHeight;  // Height to raise the platform (adjust as needed)
    public float raiseSpeed;   // Speed at which the platform raises (adjust as needed)
    public AudioSource raisingAudioSource; // Reference to the Audio Source for raising sound
    public AudioSource impactAudioSource; // Reference to the Audio Source for impact sound
    public AudioSource additionalAudioSource; // Reference to the Audio Source for the additional sound

    public float impactTriggerHeight; // Height to trigger the impact sound (adjust as needed)
    public float additionalSoundTriggerHeight; // Height to trigger the additional sound (adjust as needed)

    private bool isRaising = false;
    private bool impactSoundPlayed = false;
    private bool additionalPlayed = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        raisingAudioSource.Stop(); // Make sure the raising audio source starts in a stopped state
        impactAudioSource.Stop(); // Make sure the impact audio source starts in a stopped state
        additionalAudioSource.Stop(); // Make sure the additional audio source starts in a stopped state
    }

    void Update()
    {
        if (isRaising)
        {
            float step = raiseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + Vector3.up * raiseHeight, step);

            if (transform.position.y >= initialPosition.y + impactTriggerHeight)
            {
                // Play the impact sound when the platform reaches the impact trigger height
                if (!impactAudioSource.isPlaying&&!impactSoundPlayed)
                {
                    impactAudioSource.Play();
                    impactSoundPlayed = true;
                }
            }
            if (transform.position.y >= initialPosition.y + additionalSoundTriggerHeight)
            {
                if (!additionalAudioSource.isPlaying && !additionalPlayed)
                {
                    // Play the additional sound when the platform reaches the additional sound trigger height
                    additionalAudioSource.Play();
                    additionalPlayed = true;
                }
            }
        }
    }

    public void StartRaising()
    {
        isRaising = true;
        raisingAudioSource.Play(); // Play the raising sound when the platform starts raising
    }
}
