using System;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private GameManager gameManager;
    private ScoreHPScript score;

    [SerializeField] private bool isEnd;

    private KeyCode rowKeyCode;

    private bool canBePressed;
    private float buttonPositionY;

    private void Awake()
    {
        if (isEnd)
            gameManager = FindObjectOfType<GameManager>();

        score = FindObjectOfType<ScoreHPScript>();
    }

    private void Start()
    {
        rowKeyCode = GetComponentInParent<RowHolder>().RowCode;
    }

    private void Update()
    {
        if (Input.GetKeyDown(rowKeyCode))
        {
            if (canBePressed)
            {
                TryHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            canBePressed = true;
            buttonPositionY = collision.transform.position.y;
            Debug.Log("Enter");
            if (isEnd)
            {
                gameManager.Win();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            canBePressed = false;

            Debug.Log("Absolute miss");
            FindObjectOfType<HP>().ChangeHealth(-1);
            score.ResetCombo();
        }
    }

    private void TryHit()
    {
        float notePositionY = gameObject.transform.position.y;
        float judgment = Math.Abs(notePositionY - buttonPositionY) * 100;
        
        if (judgment < (int)TypesOfHits.Hits.Perfect)
        {
            Hit(TypesOfHits.Hits.Perfect);
        }
        else if (judgment < (int)TypesOfHits.Hits.Great)
        {
            Hit(TypesOfHits.Hits.Great);
        }
        else if (judgment < (int)TypesOfHits.Hits.Ok)
        {
            Hit(TypesOfHits.Hits.Ok);
        }
        else if (judgment < (int)TypesOfHits.Hits.Bad)
        {
            Hit(TypesOfHits.Hits.Bad);
        }
        else
        {
            score.AddScore(TypesOfHits.Hits.Miss);
        }
    }

    private void Hit(TypesOfHits.Hits hitType)
    {
        //Debug.Log(hitType.ToString());
        AkSoundEngine.PostEvent("Hit_Event", gameObject);
        score.AddScore(hitType);
        Destroy(gameObject);
    }
}
