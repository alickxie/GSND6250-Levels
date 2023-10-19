using UnityEngine;

public class StairController : MonoBehaviour
{
    public GameObject[] stairCubes;
    private bool stairsRaised = false;
    private int currentCubeIndex = 0;

    public void RaiseStairs()
    {
        if (currentCubeIndex < stairCubes.Length)
        {
            // Move the current cube up (you can use Translate or other methods)
            float raiseAmount = 1.0f; // Adjust this value as needed
            stairCubes[currentCubeIndex].transform.Translate(Vector3.up * raiseAmount);

            currentCubeIndex++;

            if (currentCubeIndex == stairCubes.Length)
            {
                stairsRaised = true;
            }
        }
    }
}