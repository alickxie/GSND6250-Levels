using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldInHand : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private string itemName;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public string GetItemName()
    {
        Debug.Log(itemName);
        return itemName;
    }

    public void CheckHoldingPosition(GameObject x)
    {
        if (this.transform.parent == x.transform)
        {
            // Move back to original position
            this.transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;

            this.transform.position = x.transform.position;
            this.transform.rotation = x.transform.rotation;
        }
        else
        {
            if (x.transform.childCount > 0)
            {
                // Drop the current first child to the ground
                GameObject child = x.transform.GetChild(0).gameObject;
                child.transform.parent = null;
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().useGravity = true;
            }

            rb.isKinematic = true;
            rb.useGravity = false;
            // Move to holding position
            this.transform.position = x.transform.position;
            this.transform.rotation = x.transform.rotation;

            this.transform.parent = x.transform;
        }
    }
}
