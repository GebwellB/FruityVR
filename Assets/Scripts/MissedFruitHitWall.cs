using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissedFruitHitWall : MonoBehaviour
{
    public static MissedFruitHitWall Instance;

    public Slider HealthBar;
    public GameObject mainMenu;
    public GameObject gameOverPanel;
    public TMP_Text scoreText;

    public SwordSlicer swordSlicerLeft;
    public SwordSlicer swordSlicerRight;

    private AudioSource fruitSquishAudioSource;
    public AudioClip fruitSquishClip;
    private AudioSource gameOverAudioSource;
    public AudioClip gameOverClip;

    public FruitSpawner fruitSpawner;
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 10;
    public int combinedScore;

    private void Start()
    {
        currentHealth = maxHealth;
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currentHealth;
        fruitSquishAudioSource = PersistentMusic.audioSingleton.GetComponent<PersistentMusic>().fruitSplatAudioSource;
        gameOverAudioSource = PersistentMusic.audioSingleton.GetComponent<PersistentMusic>().gameOverAudioSource;
    }

    private void Awake()
    {
        Instance = this;
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

        fruitSquishAudioSource.Play();

        if (currentHealth <= 0)
        {
            gameOverAudioSource.Play();
            Die();
        }
    }

    public void Die()
    {
        GameObject[] fruit = GameObject.FindGameObjectsWithTag("Fruit");
        
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
        currentHealth = maxHealth;
        combinedScore = 0;
        fruitSpawner.gameRunning = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
