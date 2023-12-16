using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTETree : MonoBehaviour
{
    public GameObject filledBar;
    public GameObject chestTop;

    public AudioSource chestOpenSound;
    public AudioSource chestCloseSound;
    public AudioSource fullyOpenedSound;
    public AudioSource qteSound;

    public Animator qteUI;
    public Animator whiteScreenSplash;

    bool isInRange = false;
    bool opened = false;
    bool singlePlay = false;
    bool singleTon = false;

    public GameObject handdecoration;

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
            // qteSound.Play();
            qteUI.SetTrigger("spaming");
            qteUI.SetTrigger("spaming");

            if (!chestOpenSound.isPlaying)
            {
                chestOpenSound.Play();
            }

            // Increase the bar
            filledBar.GetComponent<Slider>().value += 0.055f;
        }

        // if bar is not full, decrease the bar
        if (filledBar.GetComponent<Slider>().value > 0 && !opened)
        {
            filledBar.GetComponent<Slider>().value -= 0.2f * Time.deltaTime;
        }

        if (filledBar.GetComponent<Slider>().value <= 0)
        {
            chestCloseSound.Stop();
            chestOpenSound.Stop();
        }

        // Make the rotation of the chest top corresponding to the bar value, when bar value is 0, chest top is (0,0,0), when bar value is 1, chest top reach (0,0,60)
        if (!opened)
        {
            chestTop.transform.localRotation = Quaternion.Euler(0, 0, filledBar.GetComponent<Slider>().value * 40);
        }

        // if bar is full
        if (filledBar.GetComponent<Slider>().value > 0.99f)
        {
            //SFX
            chestCloseSound.Stop();
            chestOpenSound.Stop();
            if (singlePlay == false)
            {
                fullyOpenedSound.Play();
                singlePlay = true;
            }

            //UI
            opened = true;
            filledBar.SetActive(false);
            whiteScreenSplash.SetTrigger("splash");
            if(singleTon == false)
            {
                Destroy(handdecoration.transform.GetChild(0).gameObject);
                GameManager.instance.KidAvoid();
                singleTon = true;
            }

            // rotate the chest top to 90 degree quickly
            if (chestTop.transform.localRotation != Quaternion.Euler(0, 0, 80))
            {
                // Define the target rotation
                Quaternion targetRotation = Quaternion.Euler(0, 0, 80);

                // Define the rotation speed in degrees per second
                float rotationSpeed = 200f;

                // Calculate the rotation step based on the speed and frame time
                float step = rotationSpeed * Time.deltaTime;

                // Rotate towards the target rotation
                chestTop.transform.localRotation = Quaternion.RotateTowards(chestTop.transform.localRotation, targetRotation, step);
            }
        }
    }

    public void decorateTree()
    {
        isInRange = true;
        filledBar.SetActive(true);
    }
}