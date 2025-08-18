using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("Music");

        if (musicObjs.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
