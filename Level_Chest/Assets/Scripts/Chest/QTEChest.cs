using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEChest : MonoBehaviour
{
    public GameObject filledBar;
    
    bool isInRange = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if player press e and is in range of chest
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            filledBar.SetActive(true);
        }
    }
}
