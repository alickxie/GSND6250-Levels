using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRaiser : MonoBehaviour
{
    public float raiseHeight;  // Height to raise the platform (adjust as needed)
    public float raiseSpeed;   // Speed at which the platform raises (adjust as needed)

    private bool isRaising = false;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRaising)
        {
            float step = raiseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + Vector3.up * raiseHeight, step);
        }
    }

    public void StartRaising()
    {
        isRaising = true;
    }
}
