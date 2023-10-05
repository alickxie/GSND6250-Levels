using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEncounter : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource Laught;
    public AudioSource Scream;
    public bool readyToPlay;

    [Header("Related")]
    public Transform targetObject;
    // Time in seconds for the target object to complete the movement
    public float moveDuration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        readyToPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveTargetObject());
            if (readyToPlay)
            {
                Laught.Play();
                Scream.PlayDelayed(1);
            }
            readyToPlay = false;
        }

    }

    private IEnumerator MoveTargetObject()
    {
        if (targetObject != null)
        {
            Vector3 initialPosition = targetObject.position;
            Vector3 targetPosition = initialPosition + new Vector3(0f, 0f, -100f);  // Move in the X-axis

            float elapsedTime = 0f;

            while (elapsedTime < moveDuration)
            {
                targetObject.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            targetObject.position = targetPosition;
        }
    }
}
