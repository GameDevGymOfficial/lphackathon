using UnityEngine;
using System;

public class MenuState
{
    public Action OnEnter;
    public Action OnExit;
    
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
