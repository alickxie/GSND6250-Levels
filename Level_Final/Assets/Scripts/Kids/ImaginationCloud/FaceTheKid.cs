using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheKid : MonoBehaviour
{
    public Transform kid;
    public float range;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object to face the kid direction by changing the y rotation
        transform.LookAt(new Vector3(kid.position.x, transform.position.y, kid.position.z));

        // check if kid is in range play animation
        if (Vector3.Distance(transform.position, kid.position) < range)
        {
            animator.SetTrigger("enter");
            animator.SetBool("leave", false);
        }
        else
        {
            animator.SetBool("leave", true);
        }

    }

    // Draw the range of the object
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
