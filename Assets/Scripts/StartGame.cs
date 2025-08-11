using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject UI_Canvas_Main_menu;
    public FruitSpawner fruitSpawner;

    public void OnStartButtonClicked()
    {
        fruitSpawner.gameRunning = true;
        UI_Canvas_Main_menu.SetActive(false);
    }
}
