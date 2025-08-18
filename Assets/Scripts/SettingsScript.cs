using UnityEngine;

public class SettingScript : MonoBehaviour
{
    public GameObject UI_Canvas_Main_menu;
    public GameObject UI_Canvas_Settings;
    public bool atMainMenu = true;

    public void OnStartButtonClicked()
    {
        if (atMainMenu)
        {
            UI_Canvas_Main_menu.SetActive(false);
            UI_Canvas_Settings.SetActive(true);
            atMainMenu = false;
        }
        else
        {
            UI_Canvas_Main_menu.SetActive(true);
            UI_Canvas_Settings.SetActive(false);
            atMainMenu = true;
        }
        
    }
}
