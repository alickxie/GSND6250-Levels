using UnityEngine;

public class GoldSplashing : MonoBehaviour
{
    public GameObject goldCoinPrefab;
    public Transform spawnPoint;
    public float splashForce = 10.0f;
    public int coinCount = 10;

    void Start()
    {
        // Spawn gold coins
        for (int i = 0; i < coinCount; i++)
        {
            GameObject goldCoin = Instantiate(goldCoinPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody coinRigidbody = goldCoin.GetComponent<Rigidbody>();
            
            // Apply a random force to simulate the splash
            coinRigidbody.AddForce(Vector3.up * Random.Range(splashForce, splashForce * 2), ForceMode.Impulse);
        }
    }
}
