using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event pauseEvent;
    [SerializeField] private AK.Wwise.Event resumeEvent;
    [SerializeField] private AK.Wwise.Event MusicEvent;

    private MenuManager menuManager;

    private const float winDelay = 3f;
    private bool started = false;

    private void Awake()
    {
        Time.timeScale = 1;
        menuManager = FindObjectOfType<MenuManager>();
    }
    private void Update()
    {
        if (Input.anyKeyDown & !started)
        {
            started = true;
            MusicEvent?.Post(gameObject);
        }
    }

    public void Win()
    {
        IEnumerator WinCoroutine()
        {
            yield return new WaitForSeconds(winDelay);
            menuManager.SwitchMenu(menuManager.GameWinMenu);
        }

        StartCoroutine(WinCoroutine());
    }
    public void Lose()
    {
        AkSoundEngine.PostEvent("StopAll",gameObject);
        menuManager.SwitchMenu(menuManager.GameOverMenu);
    }

    public void Pause()
    {
        pauseEvent.Post(gameObject);
        Time.timeScale = 0;

        menuManager.SwitchMenu(menuManager.PauseMenu);
    }
    public void Resume()
    {
        resumeEvent.Post(gameObject);
        Time.timeScale = 1;

        menuManager.SwitchMenu(menuManager.GameMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
