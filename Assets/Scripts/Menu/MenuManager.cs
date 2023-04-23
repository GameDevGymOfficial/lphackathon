using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject overlay;

    private MenuState previousMenu;
    private MenuState currentMenu;

    [SerializeField] private GameObject uibg;
    [SerializeField] private bool isGameScene = true;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject lvlSelectionMenu;
    [SerializeField] private GameObject settingsUI;

    public MenuState GameMenu { get; private set; }
    public MenuState PauseMenu { get; private set; }

    public MenuState GameWinMenu { get; private set; }
    public MenuState GameOverMenu { get; private set; }

    public MenuState MainMenu { get; private set; }
    public MenuState LVLSelectionMenu { get; private set; }
    public MenuState SettingsMenu { get; private set; }

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        GameMenu = new MenuState(gameUI);
        PauseMenu = new MenuState(pauseUI);
        GameWinMenu = new MenuState(gameWinUI);
        GameOverMenu = new MenuState(gameOverUI);

        GameWinMenu.OnEnter += Pause;
        GameWinMenu.OnExit += Resume;
        GameOverMenu.OnEnter += Pause;
        GameOverMenu.OnExit += Resume;

        MainMenu = new MenuState(mainUI);
        LVLSelectionMenu = new MenuState(lvlSelectionMenu);
        SettingsMenu = new MenuState(settingsUI);

        if (isGameScene)
        {
            uibg.SetActive(false);
            SwitchMenu(GameMenu);
        }
        else
        {
            uibg.SetActive(true);
            SwitchMenu(MainMenu);
        }
    }

    private void Update()
    {
        if (SettingsManager.IsBinding)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == GameMenu)
            {
                gameManager.Pause();
            }
            else if (currentMenu == PauseMenu)
            {
                gameManager.Resume();
            }
            else if (currentMenu == SettingsMenu)
            {
                Back();
            }
        }
    }

    public void EnableOverlay()
    {
        overlay.SetActive(true);
    }
    public void DisableOverlay()
    {
        overlay.SetActive(false);
    }

    public void Back() => SwitchMenu(previousMenu);
    public void Settings() => SwitchMenu(SettingsMenu);
    public void SelectLevel() => SwitchMenu(LVLSelectionMenu);
    
    private void Pause()
    {
        Time.timeScale = 0;
    }
    private void Resume()
    {
        Time.timeScale = 1;
    }

    public void SwitchMenu(MenuState newMenuState)
    {
        if (newMenuState == null)
            return;

        previousMenu = currentMenu;
        currentMenu = newMenuState;

        previousMenu?.Exit();
        currentMenu.Enter();
    }
}