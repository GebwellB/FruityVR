using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject UI_Canvas_Main_menu;
    public FruitSpawner fruitSpawner;
    public GameObject healthBar;

    public void OnStartButtonClicked()
    {
        fruitSpawner.gameRunning = true;
        healthBar.SetActive(true);
        UI_Canvas_Main_menu.SetActive(false);
    }
}
