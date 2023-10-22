using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    // make this script instance 
    public static LightMove instance;

    // Start is called before the first frame update
    void Start()
    {
        // set the instance to this script
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLight()
    {
        // Move the transform z of the gameobject from 0 to -2.5f, slowly
        StartCoroutine(MoveLight(transform, transform.position, new Vector3(transform.position.x, transform.position.y, -2.5f), 3.0f));
    }

    IEnumerator MoveLight(Transform transform, Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }
}
