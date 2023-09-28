using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public Transform camera;
    public float playerActivateDistance = 5f;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(camera.position, camera.forward, out hit, playerActivateDistance);

        if (Input.GetKeyDown(KeyCode.E) && active)
        {
            if (hit.transform.gameObject != null)
            {
                // get the hit object name
                if (hit.transform.gameObject.name == "Switch1")
                {
                    Debug.Log("Switch1!");
                    FindObjectOfType<Turn90forR>().updateTurn();
                }
                else if (hit.transform.gameObject.name == "Switch2")
                {
                    Debug.Log("Switch2!");
                    FindObjectOfType<Turn90forL>().updateTurn();

                }
                else if (hit.transform.gameObject.name == "Switch3")
                {
                    FindObjectOfType<TurnOnLit>().TurnOnLight();
                    GameObject[] raisingBlood = GameObject.FindGameObjectsWithTag("Blood");
                    foreach (GameObject blood in raisingBlood)
                    {
                        blood.GetComponent<RaisingBlood>().Flood();
                        //Flood();
                    }
                }
                else if (hit.transform.gameObject.name == "Switch4")
                {

                }
            }
        }
    }
}
