using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 1.5f;

    public float minSpeed = 5f;
    public float maxSpeed = 15f;

    public float minAmplitude = 0.5f;
    public float maxAmplitude = 2.5f;

    public float minFrequency = 0.5f;
    public float maxFrequency = 2f;

    public float maxTorqueForce = 100f;

    void Start()
    {
        InvokeRepeating("SpawnFruit", 1f, spawnInterval);
    }

    void SpawnFruit()
    {
        GameObject selectedFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject spawned = Instantiate(selectedFruit, spawnPoint.position, spawnPoint.rotation);

        float speed = Random.Range(minSpeed, maxSpeed);
        float amplitude = Random.Range(minAmplitude, maxAmplitude);
        float frequency = Random.Range(minFrequency, maxFrequency);

        Vector3 randomTorque = new Vector3(
            Random.Range(-maxTorqueForce, maxTorqueForce),
            Random.Range(-maxTorqueForce, maxTorqueForce),
            Random.Range(-maxTorqueForce, maxTorqueForce)
        );

        if (Random.value > 0.5f)
        {
            var moveScript = spawned.AddComponent<FlyingFruitPositive>();
            moveScript.SetMovement(speed, amplitude, frequency, randomTorque);
        }
        else
        {
            var moveScript = spawned.AddComponent<FlyingFruitNegative>();
            moveScript.SetMovement(speed, amplitude, frequency, randomTorque);
        }
    }
}
