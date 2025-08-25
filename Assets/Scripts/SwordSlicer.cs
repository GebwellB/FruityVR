using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwordSlicer : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public int scorePerFruit = 1;

    private AudioSource swordSliceAudioSource;
    public AudioClip swordSliceClip;
    private void Start()
    {
        swordSliceAudioSource = PersistentMusic.audioSingleton.GetComponent<PersistentMusic>().swordSliceAudioSource;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            swordSliceAudioSource.Play();
            AddScore(scorePerFruit);
        }
    }
    void AddScore(int amount)
    {
        score += amount;
    }
    // This gets called from the wall that destroys all the fruit, to get the total score
    public int GetFinalScore()
    {
        return score;
    }
}
