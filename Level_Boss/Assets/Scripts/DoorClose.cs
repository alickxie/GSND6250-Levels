using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public AudioSource bosslaugh;
    public GameObject door;
    bool single = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && single)
        {
            single = false;
            Debug.Log("Player entered door trigger");
            bosslaugh.Play();
            door.SetActive(true);
        }
    }
}
