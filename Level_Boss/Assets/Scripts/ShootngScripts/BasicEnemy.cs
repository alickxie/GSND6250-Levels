using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    public int health;

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
        if (health <= 0)
            ChangeLightColor();
    }

    private void ChangeLightColor()
    {
        if (pointLight != null)
        {
            pointLight.color = lightColorOnHit;
        }
    }
}
