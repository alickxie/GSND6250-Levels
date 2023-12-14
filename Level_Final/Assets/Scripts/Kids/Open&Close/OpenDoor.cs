using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool doorOpened;
    private bool coroutineAllowed;
    public AudioClip dooropenclip;

    void Start()
    {
        doorOpened = false;
        coroutineAllowed = true;
    }

    public void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            RunCoroutine();
        }
    }

    private void RunCoroutine()
    {
        StartCoroutine(OpenThatDoor());
    }

    private IEnumerator OpenThatDoor()
    {
        coroutineAllowed = false;
        float totalTime = 0.981f; // Total time for opening/closing
        float degreesPerStep = 1f; // Decrease for smoother animation
        int totalSteps = (int)(45 / degreesPerStep);
        float stepTime = totalTime / totalSteps; // Time per step

        if (!doorOpened)
        {
            AudioManager.Instance.PlaySound(dooropenclip);
            for (int step = 0; step <= totalSteps; step++)
            {
                float angle = -degreesPerStep * step;
                transform.localRotation = Quaternion.Euler(0f, angle, 0f);
                yield return new WaitForSeconds(stepTime);
            }
            doorOpened = true;
        }
        else
        {
            AudioManager.Instance.PlaySound(dooropenclip);
            for (int step = totalSteps; step >= 0; step--)
            {
                float angle = -degreesPerStep * step;
                transform.localRotation = Quaternion.Euler(0f, angle, 0f);
                yield return new WaitForSeconds(stepTime);
            }
            doorOpened = false;
        }
        coroutineAllowed = true;
    }
}
