using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLit : MonoBehaviour
{
    public Light pointLight;
    // Start is called before the first frame update
    void Start()
    {
        if (pointLight == null)
        {
            Debug.LogError("Point Light is not assigned to the script.");
            return;
        }

        pointLight.enabled = false;
    }

    public void TurnOnLight()
    {
        pointLight.enabled = true;
    }

    // Method to turn off the light
    public void TurnOffLight()
    {
        pointLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
