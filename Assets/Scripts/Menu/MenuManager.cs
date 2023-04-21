using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private MenuState currentMenu;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gameOverUI;

    public MenuState GameMenu { get; private set; }
    public MenuState PauseMenu { get; private set; }

    public MenuState GameWinMenu { get; private set; }
    public MenuState GameOverMenu { get; private set; }

    private void Awake()
    {
        GameMenu = new MenuState(gameUI);
        PauseMenu = new MenuState(pauseUI);
        GameWinMenu = new MenuState(gameWinUI);
        GameOverMenu = new MenuState(gameOverUI);

        currentMenu = GameMenu;
        GameMenu.Enter();
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
        }
    }

    public void SwitchMenu(MenuState newMenuState)
    {
        if (newMenuState == null)
            return;

        currentMenu?.Exit();
        currentMenu = newMenuState;
        currentMenu.Enter();
    }
}