using UnityEngine;

public class TeleportationTrigger : MonoBehaviour
{
    public GameObject bossCopyOn;
    public GameObject[] bossCopyOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered teleportation trigger");
            bossCopyOn.SetActive(true);
            foreach (GameObject bossCopy in bossCopyOff)
            {
                bossCopy.SetActive(false);
            }
        }
    }
}
