using TMPro;
using UnityEngine;

public class ScoreHPScript : MonoBehaviour
{
    private HP hp;
    private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI[] Text;

    private int score = 0;
    private const float NOTE_VALUE = 100;
    private float coefficient;
    private int combo = 0;

    public int[] hitCount = new int[5];

    private void Awake()
    {
        hp = FindObjectOfType<HP>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void AddScore(int delta)
    {
        score += delta;

        foreach (var item in Text)
        {
            item.text = score.ToString();
        }
    }
    public void AddScore(TypesOfHits.Hits hits)
    {
        switch (hits)
        {
            case TypesOfHits.Hits.Perfect:
                coefficient = 1;
                hitCount[0]++;
                UpdateCombo();
                break;
            case TypesOfHits.Hits.Great:
                coefficient = 0.8f;
                hitCount[1]++;
                UpdateCombo();
                break;
            case TypesOfHits.Hits.Ok:
                coefficient = 0.6f;
                hitCount[2]++;
                UpdateCombo();
                break;
            case TypesOfHits.Hits.Bad:
                coefficient = 0.4f;
                hitCount[3]++;
                ResetCombo();
                break;
            case TypesOfHits.Hits.Miss:
                coefficient = 0f;
                hitCount[4]++;
                ResetCombo();
                hp.ChangeHealth(-1);
                break;
        }

        AddScore((int)(NOTE_VALUE * coefficient));

        if (combo % 10 == 0)
        {
            hp.ChangeHealth(1);
        }
    }
    public void UpdateCombo()
    {
        combo++;
    }
    public void ResetCombo()
    {
        combo = 0;
    }
}