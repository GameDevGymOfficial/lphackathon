using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public UnityEvent OnMainMenuLoad;
    public UnityEvent OnNextLevelLoad;

    private static int currentLevelIndex = 0;
    private const int maxLevelindex = 3;
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        OnMainMenuLoad?.Invoke();
    }

    public void LoadFirstLevel()
    {
        currentLevelIndex = 1;

        SceneManager.LoadScene(currentLevelIndex);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(currentLevelIndex);
        OnNextLevelLoad?.Invoke();
    }
    public void LoadNextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex > maxLevelindex)
        {
            currentLevelIndex = 0;
            LoadMainMenu();
        }

        SceneManager.LoadScene(currentLevelIndex);
        OnNextLevelLoad?.Invoke();
    }
}
