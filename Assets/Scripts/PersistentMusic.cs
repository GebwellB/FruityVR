using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    public static GameObject audioSingleton;
    public AudioSource fruitSplatAudioSource;
    public AudioSource gameOverAudioSource;
    public AudioSource swordSliceAudioSource;

    void Awake()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("Music");
        if(audioSingleton == null)
        {
            audioSingleton = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if(audioSingleton != null
            && audioSingleton != this.gameObject
            && musicObjs.Length > 1)
        {
            Destroy(gameObject);
        }
        //if (musicObjs.Length > 1)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
            
        //}
    }
}
