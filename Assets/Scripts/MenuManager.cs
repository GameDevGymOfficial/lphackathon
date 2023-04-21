using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    public UnityEvent OnPause;
    public UnityEvent OnResume;

    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;

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
    
    public void Play()
    {
        menuUI.SetActive(false);
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
