using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private MenuState previousMenu;
    private MenuState currentMenu;

    [SerializeField] private bool isGameScene = true;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject settingsUI;

    public MenuState GameMenu { get; private set; }
    public MenuState PauseMenu { get; private set; }

    public MenuState GameWinMenu { get; private set; }
    public MenuState GameOverMenu { get; private set; }

    public MenuState MainMenu { get; private set; }
    public MenuState SettingsMenu { get; private set; }

    private void Awake()
    {
        GameMenu = new MenuState(gameUI);
        PauseMenu = new MenuState(pauseUI);
        GameWinMenu = new MenuState(gameWinUI);
        GameOverMenu = new MenuState(gameOverUI);

        MainMenu = new MenuState(mainUI);
        SettingsMenu = new MenuState(settingsUI);

        if (isGameScene)
        {
            SwitchMenu(GameMenu);
        }
        else
        {
            SwitchMenu(MainMenu);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == GameMenu)
            {
                SwitchMenu(PauseMenu);
            }
            else if (currentMenu == PauseMenu)
            {
                SwitchMenu(GameMenu);
            }
            else if (currentMenu == SettingsMenu)
            {
                Back();
            }
        }
    }

    public void Back() => SwitchMenu(previousMenu);
    public void Settings() => SwitchMenu(SettingsMenu);

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