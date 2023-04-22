using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public UnityEvent OnMainMenuLoad;
    public UnityEvent OnNextLevelLoad;

    private const int maxLevelindex = 3;
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        OnMainMenuLoad?.Invoke();
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
