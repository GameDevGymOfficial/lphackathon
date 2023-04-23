using TMPro;
using UnityEngine;

public class ScoreHPScript : MonoBehaviour
{
    private HP hp;

    [SerializeField] private TextMeshProUGUI[] Text;

    private int score = 0;
    private float Accuracy = 0;
    private float comboCoeff = 1;
    private const float NOTE_VALUE = 100;
    private float coefficient;
    private int combo = 0;
    public string AccuracyText;
    public int[] hitCount = new int[5];

    private void Awake()
    {
        hp = FindObjectOfType<HP>();
    }
    private void Start()
    {
        AddScore(0);
    }

    private void AddScore(int delta)
    {
        score += delta;

        foreach (var item in Text)
        {
            item.text = score.ToString();
        }
    }
    public void AddScore(HitType hits)
    {
        switch (hits)
        {
            case HitType.Perfect:
                coefficient = 1;
                hitCount[0]++;
                UpdateCombo();
                break;
            case HitType.Great:
                coefficient = 0.8f;
                hitCount[1]++;
                UpdateCombo();
                break;
            case HitType.Ok:
                coefficient = 0.6f;
                hitCount[2]++;
                UpdateCombo();
                break;
            case HitType.Bad:
                coefficient = 0.4f;
                hitCount[3]++;
                ResetCombo();
                break;
            case HitType.Miss:
                coefficient = 0f;
                hitCount[4]++;
                ResetCombo();
                hp.ChangeHealth(-1);
                break;
        }

        CalculateAccuracy();
        if (combo % 10 == 0)
        {
            hp.ChangeHealth(1);
        }
        if (combo % 20 == 0)
        {
            comboCoeff += 0.2f;
        }
        AddScore((int)(NOTE_VALUE * coefficient * comboCoeff));
    }
    public void UpdateCombo()
    {
        combo++;
    }
    public void ResetCombo()
    {
        combo = 0;
        comboCoeff = 1;
    }
    private void CalculateAccuracy()
    {
        Accuracy = (float)100*(100 * hitCount[0] + 80 * hitCount[1] + 60 * hitCount[2] + 40 * hitCount[3]) / (100 * (hitCount[0] + hitCount[1] + hitCount[2] + hitCount[3] + hitCount[4]));
        AccuracyText = Accuracy.ToString("F2")+"%";
        ShowAccuracy();
    }
    public void ShowAccuracy()
    {
        Debug.Log(AccuracyText);
    }
}