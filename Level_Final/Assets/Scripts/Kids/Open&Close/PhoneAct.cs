using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAct : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayTheVoiceMessage()
    {
        StartCoroutine(PlayTheVoiceMessageCoroutine());
    }

    IEnumerator PlayTheVoiceMessageCoroutine()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        GameManager.instance.StopKidMoveing(false);
    }
}
