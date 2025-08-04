using UnityEngine;

public class SwordSlicer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
        }
    }
}
