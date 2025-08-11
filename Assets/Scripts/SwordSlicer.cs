using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwordSlicer : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public int scorePerFruit = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            AddScore(scorePerFruit);
        }
    }
    void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Fruit Destroyed: " + score.ToString();
    }
    // This gets called from the wall that destroys all the fruit, to get the total score
    public int GetFinalScore()
    {
        return score;
    }
}
