using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private bool ignoreDamage;

    private int health = 6;
    private const int MAX_HEALTH = 6;

    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Sprite emptySprite;

    [SerializeField] private Image[] hpImages;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        health = MAX_HEALTH;
    }

    public void ChangeHealth(int change)
    {
        if (ignoreDamage)
            return;

        health = Mathf.Clamp(health + change, 0, MAX_HEALTH);

        for (int i = 1; i <= MAX_HEALTH; i++)
        {
            if (health >= i)
                hpImages[i - 1].sprite = fullSprite;
            else
                hpImages[i - 1].sprite = emptySprite;
        }

        if (health == 0)
        {
            gameManager.Lose();
        }
    }
}
