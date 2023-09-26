using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource phone1;
    public AudioSource phone2;
    public AudioSource phone3;
    public AudioSource correct;
    public AudioSource wrong;

    void Start()
    {
        phone1.Play();
    }

    public void SwtichPhone(int phoneNum)
    {
        if (phoneNum == 1)
        {
            phone2.Play();
        }
        else if (phoneNum == 2)
        {
            phone3.Play();
        }
        else if (phoneNum == 3)
        {
            phone3.Stop();
        }
    }

    public void PlayCorrectSound()
    {
        correct.Play();
    }

    public void PlayWrongSound()
    {
        wrong.Play();
    }
}
