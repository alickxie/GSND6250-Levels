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
        // if (!stairsRaised && Input.GetKeyDown(KeyCode.E))
        // {
        //     RaiseStairs();
        // }
    }

    public void RaiseStairs()
    {
        GameManager.instance.StairRaising();

        for (int i = 0; i < stairCubes.Length; i++)
        {
            float initialHeight = stairCubes[i].transform.position.y;
            float targetHeight = targetHeights[i];

            // Calculate the distance to move and the time needed
            float distanceToMove = targetHeight - initialHeight;
            float moveDuration = distanceToMove / raiseSpeed;

            // Move the stair to its target height
            StartCoroutine(MoveStair(stairCubes[i], targetHeight, moveDuration));
        }
        stairsRaised = true;
    }

    private IEnumerator MoveStair(GameObject stair, float targetHeight, float moveDuration)
    {
        float elapsedTime = 0f;
        float initialHeight = stair.transform.position.y;

        while (elapsedTime < moveDuration)
        {
            float height = Mathf.Lerp(initialHeight, targetHeight, elapsedTime / moveDuration);
            stair.transform.position = new Vector3(stair.transform.position.x, height, stair.transform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure the stair is exactly at the target height
        stair.transform.position = new Vector3(stair.transform.position.x, targetHeight, stair.transform.position.z);
    }
}