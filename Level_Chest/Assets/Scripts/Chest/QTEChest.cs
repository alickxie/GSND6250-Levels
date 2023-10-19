using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEChest : MonoBehaviour
{
    public GameObject filledBar;
    public GameObject chestTop;

    bool isInRange = false;
    bool opened = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if player press e and is in range of chest
        if (Input.GetKeyDown(KeyCode.E) && isInRange && !opened)
        {
            // Increase the bar
            filledBar.GetComponent<Slider>().value += 0.055f;
        }

        // if bar is not full, decrease the bar
        if (filledBar.GetComponent<Slider>().value > 0 && !opened)
        {
            filledBar.GetComponent<Slider>().value -= 0.2f * Time.deltaTime;
        }

        // Make the rotation of the chest top corresponding to the bar value, when bar value is 0, chest top is (0,0,0), when bar value is 1, chest top reach (0,0,60)
        if (!opened)
        {
            chestTop.transform.localRotation = Quaternion.Euler(0, 0, filledBar.GetComponent<Slider>().value * 40);
        }


        // if bar is full
        if (filledBar.GetComponent<Slider>().value > 0.99f)
        {
            // Open the chest
            Debug.Log("Chest Opened");
            opened = true;
            filledBar.SetActive(false);
            // rotate the chest top to 90 degree quickly
            if (chestTop.transform.localRotation != Quaternion.Euler(0, 0, 150))
            {
                Debug.Log("Chest Top Rotating");

                // Define the target rotation
                Quaternion targetRotation = Quaternion.Euler(0, 0, 150);

                // Define the rotation speed in degrees per second
                float rotationSpeed = 800f;

                // Calculate the rotation step based on the speed and frame time
                float step = rotationSpeed * Time.deltaTime;

                // Rotate towards the target rotation
                chestTop.transform.localRotation = Quaternion.RotateTowards(chestTop.transform.localRotation, targetRotation, step);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            filledBar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            filledBar.SetActive(false);
        }
    }
}
