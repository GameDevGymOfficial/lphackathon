using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public bool GameOver = false;
    public bool SuccsesHit = false;
    public const int ScoreHit = 1;
    public const string ScoreText = "Score: ";
    public int Score = 0;
    private int[] QualityHit = { 1, 2, 3 }; // {0,1,2}
    private int Hit = 1;



    [SerializeField] TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = ScoreText + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SuccsesHit = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameOver = true;
        }

        if (GameOver == true)
        {
            Score = 0;
            Text.text = ScoreText + Score;
            GameOver = false;
        }
        if (SuccsesHit == true)
        {
            Score += QualityHit[Hit];
            Text.text = ScoreText + Score;
            SuccsesHit = false;
        }
    }
}