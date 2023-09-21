using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    private AudioSource audioSource;
    public float activationRange = 18.0f;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("Distance to player: " + distance);
            // Play the audio if the player is in range and the audio is not already playing
            if (distance <= activationRange && !audioSource.isPlaying && hasPlayed == false)
            {
                Debug.Log("Audio should start playing.");
                audioSource.Play();
                hasPlayed = true;
                Debug.Log("Audio started playing.");
            }
            // Stop the audio if the player is in range and spacebar is pressed
            else if (distance <= activationRange && Input.GetKeyDown(KeyCode.Space) && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

}
