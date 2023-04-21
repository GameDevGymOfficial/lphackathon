using UnityEngine.Events;
using UnityEngine;

public class MenuState
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    
    private GameObject uiPanel;

    public MenuState(GameObject uiPanel)
    {
        this.uiPanel = uiPanel;
    }

    public virtual void Enter()
    {
        uiPanel.SetActive(true);

        OnEnter?.Invoke();
    }

    public virtual void Exit()
    {
        uiPanel.SetActive(false);

        OnExit?.Invoke();
    }
}
