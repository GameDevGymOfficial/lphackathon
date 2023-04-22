using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    TypesOfHits.Hits hits;
    public bool gameOver = false;
    public bool SuccsesHit = false;
    public const string ScoreText = "Score: ";
    public int Score = 0;



    [SerializeField] TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = ScoreText + Score;
        //int HitsInScore = GetScore(TypesOfHits.Hits.Perfect); 
        //Text.text = ScoreText + HitsInScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SuccsesHit = true;
            SuccsesHits();
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameOver = true;
            GameOver();
        }
    }
    static int GetScore(TypesOfHits.Hits _hits)
    {
        int HitScore = (int)_hits; // Score of Enum(TypesOfHits)

        return HitScore;
    } 
    
    public void GameOver ()
    {
        if (gameOver == true)
        {
            Score = 0;
            Text.text = ScoreText + Score;
            gameOver = false;
        }
    }
    public void SuccsesHits()
    {
        if (SuccsesHit == true)
        {
            _AddScore();
            SuccsesHit = false;
        }
    }
    public void _AddScore()
    {
        int NewScore = GetScore(TypesOfHits.Hits.Perfect);///
        Score = AddScore(Score, NewScore);
        Text.text = ScoreText + Score;
    }
    public int AddScore(int OldScore, int AddValue)
    {
        int res = OldScore + AddValue;
        return res;
    }
}