using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingBlood : MonoBehaviour
{
    [SerializeField] private bool startToFlood = false;
    [SerializeField] public float raiseSpeed = 0.0001f;
    [SerializeField] private bool canPlayAudio = true;
    [SerializeField] private float startDeley = 3.0f;
    [SerializeField] private float dripRate = 3.0f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("AudioDelay", startDeley, dripRate);    //To cancel InvokeRepeating use MonoBehaviour.CancelInvoke.
    }

    public void DoorCheck()
    {
        //startToFlood = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startToFlood == true)
        {
            transform.Translate(0f, raiseSpeed, 0f);
        }
    }

    private void AudioDelay()
    {
        if (startToFlood == true)
        {
            if (!audioSource.isPlaying && canPlayAudio)
            {
                audioSource.loop = !audioSource.loop;
                audioSource.Play();
                audioSource.loop = !audioSource.loop;
            }
            else if (audioSource.isPlaying && !canPlayAudio)
            {
                audioSource.Stop();
            }
            else if (!canPlayAudio)
            {
                audioSource.Stop();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            Debug.Log("Dead");
            startToFlood = false;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Head"))
        {
        }
    }
}
