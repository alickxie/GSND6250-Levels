using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenOut : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    public AudioClip throwclip;
    public AudioClip groundHitClip; // Audio clip to play when hitting the ground

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetOut()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        // rb.AddForce(new Vector3(-10, 0, 0), ForceMode.Impulse);
        // Add force toward the camera direction with random of left and right
        rb.AddForce(Camera.main.transform.forward * -10 + Camera.main.transform.right * Random.Range(-5, 5), ForceMode.Impulse);
        // rb.AddForce(Camera.main.transform.forward * -10, ForceMode.Impulse);
        AudioManager.Instance.PlaySound(throwclip);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Play the ground hit sound
            AudioManager.Instance.PlaySound(groundHitClip);
        }
    }
}
