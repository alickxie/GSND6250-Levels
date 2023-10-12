using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TriggerTeleport triggerTeleport;
    public LampColorChnage lampColorChnage;
    public LampColorChnage1 lampColorChnage1;
    bool singleUse = true;
    public AudioSource correctSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lampColorChnage.GetColor() == Color.red && lampColorChnage1.GetColor() == Color.yellow)
        {
            LightPuzzle(true);
            PlayCorrectSound();
        }

        if (lampColorChnage.GetColor() != Color.red || lampColorChnage1.GetColor() != Color.yellow)
        {
            LightPuzzle(false);
            singleUse = true;
        }
    }


    public void PlayCorrectSound()
    {
        if (singleUse)
        {
            correctSound.Play();
            singleUse = false;
        }
    }

    public void LightPuzzle(bool x)
    {
        triggerTeleport.SetTrigger(x);
    }
}
