using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerAct : MonoBehaviour
{
    bool drawerOpen = false;
    public GameObject drawer;

    public void DrawerAction()
    {
        // if drawer have not be opened, open it(slowly move game object z axis to z+2)
        if (!drawerOpen)
        {
            drawer.GetComponent<Animator>().SetBool("Open", true);
            drawerOpen = true;
        }
        // if drawer have been opened, close it(slowly move game object z axis to z-2)
        else
        {
            drawer.GetComponent<Animator>().SetBool("Open", false);
            drawerOpen = false;
        }

    }
}
