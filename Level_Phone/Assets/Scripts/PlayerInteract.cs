using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform camera;
    public float playerActivateDistance = 5f;
    bool active = false;
    public GameObject phone1UI;
    public GameObject phone2UI;
    public GameObject phone3UI;
    public AudioSource phone1Ring;
    public AudioSource phone2Ring;
    public AudioSource phone3Ring;
    public AudioSource phone1Dialogue;
    public AudioSource phone2Dialogue;


    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(camera.position, camera.forward, out hit, playerActivateDistance);

        if (Input.GetKeyDown(KeyCode.E) && active)
        {
            if (hit.transform.gameObject != null)
            {
                // get the hit object name
                if (hit.transform.gameObject.name == "phone1")
                {
                    phone1UI.SetActive(true);
                    phone1Dialogue.Play();
                    phone1Ring.Stop();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else if (hit.transform.gameObject.name == "phone2")
                {
                    phone2UI.SetActive(true);
                    phone2Dialogue.Play();
                    phone2Ring.Stop();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else if (hit.transform.gameObject.name == "phone3")
                {
                    phone3UI.SetActive(true);
                    phone3Ring.Stop();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}
