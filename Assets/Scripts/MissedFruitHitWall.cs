using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MissedFruitHitWall : MonoBehaviour
{
    public Slider HealthBar;
    public GameObject mainMenu;
    public GameObject gameOverPanel;
    public TMP_Text scoreText;

    public SwordSlicer swordSlicerLeft;
    public SwordSlicer swordSlicerRight;

    public AudioSource fruitSquishAudioSource;
    public AudioClip fruitSquishClip;
    public AudioSource gameOverAudioSource;
    public AudioClip gameOverClip;

    public FruitSpawner fruitSpawner;
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 10;

    private void Start()
    {
        currentHealth = maxHealth;
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            TakeDamage(damageAmount);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.value = currentHealth;

        fruitSquishAudioSource.PlayOneShot(fruitSquishClip);

        if (currentHealth <= 0)
        {
            gameOverAudioSource.PlayOneShot(gameOverClip);
            Die();
        }
    }

    void Die()
    {
        GameObject[] fruit = GameObject.FindGameObjectsWithTag("Fruit");
        
        fruitSpawner.gameRunning = false;
        int combinedScore = 0;
        int leftSwordScore = swordSlicerLeft.GetFinalScore();
        int rightSwordScore = swordSlicerRight.GetFinalScore();
        combinedScore = leftSwordScore + rightSwordScore;
        scoreText.text = "Fruit Destroyed: " + combinedScore;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        foreach (GameObject f in fruit)
        {
            Destroy(f);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
