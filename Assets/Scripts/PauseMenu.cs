using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public InputActionReference menuButtonpressed;
    public GameObject pauseMenu;

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
        if (!pausedButtonPressed)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            pausedButtonPressed = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            pausedButtonPressed = false;
        }
    }

    public void OnEndRunButtonClicked()
    {
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
