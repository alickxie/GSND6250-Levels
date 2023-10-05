using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{

    private Rigidbody rb;
    private bool targetHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter (Collision collision)
    {
        //make sure only to stick to the first target you hit
        if (targetHit)
            return;
        else
            targetHit = true;

        //make sure projecttile stick to surface
        rb.isKinematic = true;

        //make sure projectile moves with target
        transform.SetParent(collision.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
