using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampColorChnage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            // Change the material color to the new material's color.
            //renderer.material = newMaterial;
            Debug.Log("Enter");
        }
    }
}
