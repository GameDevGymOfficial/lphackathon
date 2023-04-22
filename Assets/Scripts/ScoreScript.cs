using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;

    private int Score = 0;
    private int health = 6;
    private const float NOTE_VALUE= 100;
    private float coefficient;
    private int combo=0;

    public int[] hitCount = new int[5];
    private const string SCORE_TEXT = "Score: ";

    void Start()
    {
        Text.text = SCORE_TEXT + Score;
    }

    public void AddScore(TypesOfHits.Hits hits)
    {
        switch (hits)
        {
            case TypesOfHits.Hits.Perfect:
                coefficient = 1;
                hitCount[0]++;
                combo++;
                break;
            case TypesOfHits.Hits.Great:
                coefficient = 0.8f;
                hitCount[1]++;
                combo++;
                break;
            case TypesOfHits.Hits.Ok:
                coefficient = 0.6f;
                hitCount[2]++;
                combo++;
                break;
            case TypesOfHits.Hits.Bad:
                coefficient = 0.4f;
                hitCount[3]++;
                combo=0;
                break;
            case TypesOfHits.Hits.Miss:
                coefficient = 0f;
                hitCount[4]++;
                combo = 0;
                ChangeHealth(-1);
                break;
        }
        Score += (int)(NOTE_VALUE * coefficient);
        Text.text = SCORE_TEXT + Score;
        if(combo%10==0)
        {
            ChangeHealth(1);
        }
        if(health==0)
        {
            Debug.Log("Game Over");
        }
    }
    public void ChangeHealth(int change)
    {
        health += change;
    }
}