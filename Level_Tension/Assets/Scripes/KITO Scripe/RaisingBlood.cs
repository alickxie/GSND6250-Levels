using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingBlood : MonoBehaviour
{
    [SerializeField] private bool hasCheckedTheDoor = false;
    [SerializeField] public float raiseSpeed = 0.0001f;
    private AudioSource audioSource;
    //private bool canPlayAudio = true;
    private float audioPlayInterval = 3f;
    private float audioTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DoorCheck()
    {
        //hasCheckedTheDoor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCheckedTheDoor == true)
        {
            transform.Translate(0f, raiseSpeed, 0f);
            if (!audioSource.isPlaying)
            {
                audioTimer += Time.deltaTime;
                if (audioTimer >= audioPlayInterval)
                {
                    audioSource.Play();
                    audioTimer = 0f;
                    audioSource.Stop();
                }
            }
        }
    }
}
