using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource audioSource;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep it across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void StartPlayingSound1()
    {
        StartCoroutine(PlaySoundWithDelay(sound1, 5f, 0.33f));
    }

    public void StartPlayingSound2()
    {
        StartCoroutine(PlaySoundWithDelay(sound2, 3.3f, 0.10f));
    }

    public void StartPlayingSound3()
    {
        StartCoroutine(PlaySoundWithDelay(sound3, 7.4f, 0.50f));
    }

    IEnumerator PlaySoundWithDelay(AudioClip clip, float delay, float chance)
    {
        while (true) // Infinite loop to keep checking
        {
            yield return new WaitForSeconds(delay);

            if (Random.value < chance)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
    void Start()
    {
        StartPlayingSound1();
        StartPlayingSound2();
        StartPlayingSound3();
    }

}
