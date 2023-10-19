using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torchHolder;  // The object representing the torch holder

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is close and presses the "E" key
        if (Vector3.Distance(transform.position, torchHolder.transform.position) < 2f && Input.GetKeyDown(KeyCode.E))
        {
            // Disable the torch and notify the player that they are now holding the torch
            gameObject.SetActive(false);
            torchHolder.GetComponent<PlayerTorchHold>().SetTorch(gameObject);
        }
    }
}
