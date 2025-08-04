using UnityEngine;

public class MissedFruitHitWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
        }
    }
}
