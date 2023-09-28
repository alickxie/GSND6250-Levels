using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDirection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBoxPush.Instance.pushDirection = transform.forward;
        }
    }
}
