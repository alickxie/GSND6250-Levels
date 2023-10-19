using UnityEngine;
using System.Collections;

public class StairController : MonoBehaviour
{
    public GameObject[] stairCubes;
    public float raiseAmount = 1.0f; // The amount each stair should raise
    public float raiseSpeed = 1.0f; // The speed at which the stairs raise
    public float[] targetHeights; // The target heights for each stair
    private bool stairsRaised = false;

    private void Update()
    {
        if (!stairsRaised && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RaiseStairsOneByOne());
        }
    }

    public IEnumerator RaiseStairsOneByOne()
    {
        for (int i = 0; i < stairCubes.Length; i++)
        {
            float step = raiseSpeed * Time.deltaTime;
            float initialHeight = stairCubes[i].transform.position.y;
            float targetHeight = targetHeights[i];

            while (stairCubes[i].transform.position.y < targetHeight)
            {
                stairCubes[i].transform.Translate(Vector3.up * step);
                yield return null;
            }

            yield return new WaitForSeconds(1.0f); // Adjust the delay between stairs if needed
        }

        stairsRaised = true;
    }
}