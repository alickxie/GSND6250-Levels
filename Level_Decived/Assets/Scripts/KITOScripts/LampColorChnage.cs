using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampColorChnage : MonoBehaviour
{
    public Material glassMaterial;  // Reference to the glass material
    private Color originalColor;   // Store the original color of the material

    // Start is called before the first frame update
    void Start()
    {
        // Store the original color of the material 
        //E7021E
        originalColor = glassMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");

            // Change the tint color to a random color
            Color newColor = new Color(Random.value, Random.value, Random.value);
            glassMaterial.color = newColor;
        }
    }
/*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger.");

            // Restore the original color of the material
            glassMaterial.color = originalColor;
        }
    }
*/
}
