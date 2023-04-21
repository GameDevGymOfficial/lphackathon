using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    public UnityEvent OnPause;
    public UnityEvent OnResume;

    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private GameObject settingsUI;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    
    public void Pause()
    {
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0;

        OnPause?.Invoke();
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1;

        OnResume?.Invoke();
    }

    public void GameOver()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
    public void WinGame()
    {
        gameUI.SetActive(false);
        gameWinUI.SetActive(true);
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
    }

    public void Play()
    {
        menuUI.SetActive(false);
        gameUI.SetActive(true);
    }
    public void PlayAgain()
    {
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        gameUI.SetActive(true);
    }
    public void MainMenu()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        menuUI.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
