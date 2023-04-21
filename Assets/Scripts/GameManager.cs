using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MenuManager menuManager;

    private void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    public void Win()
    {
        menuManager.SwitchMenu(menuManager.GameWinMenu);
    }
    public void Lose()
    {
        menuManager.SwitchMenu(menuManager.GameOverMenu);
    }

    public void Pause()
    {
        Time.timeScale = 0;

        menuManager.SwitchMenu(menuManager.PauseMenu);
    }
    public void Resume()
    {
        Time.timeScale = 1;

        menuManager.SwitchMenu(menuManager.GameMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
