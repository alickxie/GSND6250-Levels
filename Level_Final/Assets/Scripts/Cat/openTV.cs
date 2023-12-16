using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class openTV : MonoBehaviour
{
    public GameObject tv;
    public AudioSource audioSource;
    bool x = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openTVAction()
    {
        audioSource.Play();
        x = !x;
        tv.SetActive(x);
    }
}
