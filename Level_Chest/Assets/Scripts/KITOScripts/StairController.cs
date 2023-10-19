using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    public GameObject[] stairCubes;
    public float raiseSpeed = 1.0f; // Adjust the speed as needed
    private float[] targetHeights;
    private bool stairsRaised = false;

    public void Start()
    {
        targetHeights = new float[stairCubes.Length];
        for (int i = 0; i < stairCubes.Length; i++)
        {
            targetHeights[i] = stairCubes[i].transform.position.y + i; // Adjust the raise offset
        }
    }

    public void Update()
    {
        if (!stairsRaised)
        {
            RaiseStairs();
        }
    }

    public void RaiseStairs()
    {
        for (int i = 0; i < stairCubes.Length; i++)
        {
            float step = raiseSpeed * Time.deltaTime;
            stairCubes[i].transform.position = Vector3.MoveTowards(stairCubes[i].transform.position, new Vector3(stairCubes[i].transform.position.x, targetHeights[i], stairCubes[i].transform.position.z), step);

            if (stairCubes[i].transform.position.y >= targetHeights[i])
            {
                stairsRaised = true;
            }
            Debug.Log($"Stair {i} Position: {stairCubes[i].transform.position.y} Target Height: {targetHeights[i]}");
        }
    }
}

