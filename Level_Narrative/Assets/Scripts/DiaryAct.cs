using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryAct : MonoBehaviour
{
    bool drawerOpen = false;
    public GameObject diary;
    public GameObject bg;
    public MouseLook mouseLook;

    public void DiaryAction()
    {
        // if drawer have not be opened, open it(slowly move game object z axis to z+2)
        if (!drawerOpen)
        {
            diary.SetActive(true);
            bg.SetActive(true);
            // Lock the cursor
            mouseLook.mouseSensitivity = 0;
            drawerOpen = true;
        }
        // if drawer have been opened, close it(slowly move game object z axis to z-2)
        else
        {
            diary.SetActive(false);
            bg.SetActive(false);
            // Lock the cursor
            mouseLook.mouseSensitivity = 300;
            mouseLook.enabled = true;
            drawerOpen = false;
        }
    }
}
