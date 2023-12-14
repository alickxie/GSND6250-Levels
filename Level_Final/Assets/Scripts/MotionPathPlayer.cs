using UnityEngine;
using System.Collections;

public class MotionPathPlayer : MonoBehaviour
{
    public MotionPathData motionPathData;
    public float speedMultiplier = 1.0f;
    private int currentPointIndex = 0;
    private bool isMotionActive = false; // Added flag to control motion
    private bool hasBeenTriggered = false; // Flag to ensure single trigger


    void Update()
    {
        if (isMotionActive && motionPathData != null && motionPathData.points.Count > 0)
        {
            MoveAndRotateAlongPath();
        }
    }

    private void MoveAndRotateAlongPath()
    {
        if (currentPointIndex >= motionPathData.points.Count)
        {
            return; // 到达最后一个点时停止移动
        }

        MotionPathPoint currentPoint = motionPathData.points[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, currentPoint.speed * speedMultiplier * Time.deltaTime);

        // 计算每帧旋转多少度
        float rotationStep = currentPoint.rotationSpeed * speedMultiplier * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, currentPoint.rotation, rotationStep);

        // 检查是否足够接近下一个点，以避免浮点精度问题
        if (Vector3.Distance(transform.position, currentPoint.position) < 0.01f && Quaternion.Angle(transform.rotation, currentPoint.rotation) < 1.0f)
        {
            currentPointIndex++;
        }
    }

    public void StartMotion()
    {
        if (!hasBeenTriggered) // Check if it has not been triggered before
        {
            currentPointIndex = 0;
            isMotionActive = true;
            hasBeenTriggered = true; // Set the flag to prevent future triggers

            // Destroy the child object named "BoxBody" after 5 seconds
            Transform boxBody = transform.Find("boxbody");
            if (boxBody != null && boxBody.gameObject != null)
            {
                StartCoroutine(DeactivateAfterDelay(boxBody.gameObject, 5f));
            }
        }
    }
    private IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }
}



