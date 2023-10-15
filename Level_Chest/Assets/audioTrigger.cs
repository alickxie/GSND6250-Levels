using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public bool trigger = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            trigger = true;
            audioSource.Play();
        }
    }
}
