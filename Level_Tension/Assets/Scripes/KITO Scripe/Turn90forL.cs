using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn90forL : MonoBehaviour
{
    [SerializeField] private bool okToTurn = false;
    private int degreeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (okToTurn)
        {
            transform.Rotate(0f, 1f, 0f);
            degreeCount++;
            if (degreeCount >= 90)
            {
                okToTurn = false;
                degreeCount = 0;
            }
        }
    }

    public void updateTurn()
    {
        okToTurn = true;
    }
}
