using UnityEngine;

/// <summary>
/// This is the class for the FruitSpawner
/// </summary>
public class FruitSpawner : MonoBehaviour
{
    public bool gameRunning = false;
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 1.5f;

    // Minimum and maximum speed of the fruit flying towards the player
    public float minSpeed = 5f;
    public float maxSpeed = 15f;

    // Minimum and maximum of how much the fruit will osicalte up and down towards the player
    public float minAmplitude = 0.5f;
    public float maxAmplitude = 2.5f;

    // Minimum and maximum frequence at which the fruit is spawned
    public float minFrequency = 0.5f;
    public float maxFrequency = 2f;

    // Minimum and maximum of how much torque is applied to the fruit to make it spin
    public float minTorqueForce = -100f;
    public float maxTorqueForce = 100f;

    void Start()
    {
        InvokeRepeating("SpawnFruit", 1f, spawnInterval);
    }

    /// <summary>
    /// This function spawns fruit in the game world, so long as the player has started the game (<c>gameRunning> = True</c>)
    /// </summary>
    void SpawnFruit()
    {
        if (gameRunning)
        {
            // Unpauses the game, if paused
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }

            // This picks a random fruit to spawn and a random spawn point
            GameObject selectedFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // This spawns the randomly selected fruit
            GameObject spawned = Instantiate(selectedFruit, spawnPoint.position, spawnPoint.rotation);

            // From the min / max values set at run time, this packs it up nicely, ready to pass onto the actual spawner
            float speed = Random.Range(minSpeed, maxSpeed);
            float amplitude = Random.Range(minAmplitude, maxAmplitude);
            float frequency = Random.Range(minFrequency, maxFrequency);

            // This should make the fruit spin, based on the min max values of the torque settings
            Vector3 randomTorque = new Vector3(
                Random.Range(minTorqueForce, maxTorqueForce),
                Random.Range(minTorqueForce, maxTorqueForce),
                Random.Range(minTorqueForce, maxTorqueForce)
            );

            // This picks to spawn the fruit at either a positive or negative Y value. This adds randomness too how the fruit flies towards the player
            // Otherwise they'll all come flying at the same rate and direction
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
}
