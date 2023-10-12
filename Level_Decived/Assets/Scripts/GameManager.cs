using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TriggerTeleport triggerTeleport;
    public LampColorChnage lampColorChnage;
    public LampColorChnage1 lampColorChnage1;
    bool singleUse = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lampColorChnage.GetColor() == Color.red && lampColorChnage1.GetColor() == Color.yellow && singleUse)
        {
            LightPuzzle();
            singleUse = false;
        }
    }


    public void LightPuzzle()
    {
        triggerTeleport.SetTrigger();
    }
}
