using UnityEngine;

public class FlyingFruitPositive : MonoBehaviour
{
    private float moveSpeed;
    private float floatAmplitude;
    private float floatFrequency;
    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        if (rb != null && initialTorque != Vector3.zero)
        {
            rb.AddTorque(initialTorque);
        }
    }

    private Vector3 initialTorque = Vector3.zero;

    public void SetMovement(float speed, float amplitude, float frequency, Vector3 torque)
    {
        moveSpeed = speed;
        floatAmplitude = amplitude;
        floatFrequency = frequency;
        initialTorque = torque;
    }

    void Update()
    {
        float z = transform.position.z - moveSpeed * Time.deltaTime;
        float y = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        transform.position = new Vector3(startPosition.x, y, z);
    }
}
