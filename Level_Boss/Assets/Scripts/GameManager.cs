using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bosshealth = 100;

    public void BossTakeDamage(int damage)
    {
        bosshealth -= damage;

        if (bosshealth <= 0)
        {
            Debug.Log("Boss is dead");
        }
    }
}
