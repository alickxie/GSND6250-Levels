using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class LampColorChnage : MonoBehaviour
{
    public Material glassMaterial;  // Reference to the glass material
    private Color[] colors;        // Array to hold the colors
    private int currentColorIndex;  // Index to keep track of the current color
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original color of the material
        colors = new Color[] {
            Color.gray,
            Color.red,
            Color.blue,
            Color.yellow
        };

        // Initialize the current color index to 0 (first color in the array)
        currentColorIndex = 0;

        glassMaterial.color = colors[currentColorIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            Debug.Log("Player entered the trigger.");

            // Cycle to the next color
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            glassMaterial.color = colors[currentColorIndex];
        }
    }

    public Color GetColor()
    {
        return glassMaterial.color;
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
