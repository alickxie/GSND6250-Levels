using UnityEngine;

public class TeleportationTrigger : MonoBehaviour
{
    // public Transform[] teleportationPoints;
    // public Transform[] uniquePatrolPoints;
    public GameObject bossCopyOn;
    public GameObject bossCopyOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered teleportation trigger");
            bossCopyOn.SetActive(true);
            bossCopyOff.SetActive(false);
        }
    }
}
