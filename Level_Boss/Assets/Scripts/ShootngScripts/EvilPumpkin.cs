using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPumpkin : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    public int health;

    [Header("Audio")]
    public AudioSource hitPumpkin;
    public AudioSource gateOpen;

    [Header("Related")]
    public Transform targetObject;
    // Time in seconds for the target object to complete the movement
    public float moveDuration = 1.0f;

    // Color in RGB corresponding to FF2590
    private Color lightColorOnHit = new Color(255f / 255f, 136f / 255f, 37f / 255f);

    private Light pointLight;  // Reference to the point light component

    // Start is called before the first frame update
    void Start()
    {
        // Get the point light component from the child objects
        pointLight = GetComponentInChildren<Light>();
        Debug.Log(pointLight);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        hitPumpkin.Play();
        if (health <= 0)
        {
            ChangeLightColor();
            StartCoroutine(MoveTargetObject());
            gateOpen.Play();
        }

    }

    private void ChangeLightColor()
    {
        if (pointLight != null)
        {
            pointLight.color = lightColorOnHit;
        }
    }
    private IEnumerator MoveTargetObject()
    {
        if (targetObject != null)
        {
            Vector3 initialPosition = targetObject.position;
            Vector3 targetPosition = initialPosition + new Vector3(0f, 0f, 2.3f);  // Move in the X-axis

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
