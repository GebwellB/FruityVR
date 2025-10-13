using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public InputActionReference menuButtonpressed;
    public FruitSpawner fruitSpawner;
    public MissedFruitHitWall missedFruitHitWall;
    public GameObject pauseMenu;

    public List<GameObject> fruitList = new List<GameObject>();

    private bool pausedButtonPressed = false;

    private void OnEnable()
    {
        menuButtonpressed.action.performed += OnPrimaryButtonPressed;
        menuButtonpressed.action.Enable();
    }

    private void OnDisable()
    {
        menuButtonpressed.action.performed -= OnPrimaryButtonPressed;
        menuButtonpressed.action.Disable();
    }

    private void OnPrimaryButtonPressed(InputAction.CallbackContext context)
    {
        GameObject[] fruit = GameObject.FindGameObjectsWithTag("Fruit");

        foreach (GameObject f in fruit)
        {
            fruitList.Add(f);
        }

        if (!pausedButtonPressed)
        {
            if (fruitSpawner.gameRunning && !missedFruitHitWall.gameFinished)
            {
                pauseMenu.SetActive(true);
                foreach (GameObject f in fruitList)
                {
                    f.SetActive(false);
                }
                Time.timeScale = 0f;
                pausedButtonPressed = true;
            }
        }
        else
        {
            if (fruitSpawner.gameRunning && !missedFruitHitWall.gameFinished)
            {
                pauseMenu.SetActive(false);
                foreach (GameObject f in fruitList)
                {
                    f.SetActive(true);
                }
                Time.timeScale = 1.0f;
                pausedButtonPressed = false;
                fruitList.Clear();
            }
            
        }
    }

    public void OnEndRunButtonClicked()
    {
        pauseMenu.SetActive(false);
        MissedFruitHitWall.Instance.Die();
    }

    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pausedButtonPressed = false;
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
