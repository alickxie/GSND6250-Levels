using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    private bool boxOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;
    public AudioClip drawerclip;

    // Start is called before the first frame update
    void Start()
    {
        boxOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;
    }

    public void OnMouseDown()
    {
        Invoke("RunCoroutine", 0f);
    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenThatDoor");
    }

    private IEnumerator OpenThatDoor()
    {
        coroutineAllowed = false;
        if (!boxOpened)
        {
            AudioManager.Instance.PlaySound(drawerclip);
            for (float i = 0f; i <= 10f; i += 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 0.0001f,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            boxOpened = true;
        }
        else
        {
            AudioManager.Instance.PlaySound(drawerclip);
            for (float i = 10f; i >= 0f; i -= 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - 0.0001f,
                    transform.localPosition.y,
                    transform.localPosition.z);
                yield return new WaitForSeconds(0f);
            }
            transform.position = initialPosition;
            boxOpened = false;
        }
        coroutineAllowed = true;
    }
}
