using System;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private ScoreHPScript score;
    [SerializeField]private KeyCode rowKeyCode;
    private bool canBePressed;
    private float buttonPosition;
    private float notePosition;

    private void Awake()
    {
        rowKeyCode = GetComponentInParent<RowHolder>().RowCode;

        score = FindObjectOfType<ScoreHPScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(rowKeyCode))
        {
            if (canBePressed)
            {
                HitLogic();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            canBePressed = true;
            buttonPosition = collision.transform.position.y;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            canBePressed = false;
        }
    }

    private void HitLogic()
    {
        notePosition = gameObject.transform.position.y;
        float judgment = notePosition - buttonPosition;
        if (Math.Abs(judgment) > ((int)TypesOfHits.Hits.Bad / 100f))
        {
            //Debug.Log("Miss");
            score.AddScore(TypesOfHits.Hits.Miss);
            return;
        }
        if (Math.Abs(judgment) > ((int)TypesOfHits.Hits.Ok / 100f))
        {
            //Debug.Log("Bad");
            AkSoundEngine.PostEvent("Hit_Event", gameObject);
            Destroy(gameObject);
            score.AddScore(TypesOfHits.Hits.Bad);
            return;
        }
        if (Math.Abs(judgment) > ((int)TypesOfHits.Hits.Great / 100f))
        {
            //Debug.Log("Ok");
            AkSoundEngine.PostEvent("Hit_Event", gameObject);
            Destroy(gameObject);
            score.AddScore(TypesOfHits.Hits.Ok);
            return;
        }
        if (Math.Abs(judgment) > ((int)TypesOfHits.Hits.Perfect / 100f))
        {
            //Debug.Log("Great");
            AkSoundEngine.PostEvent("Hit_Event", gameObject);
            Destroy(gameObject);
            score.AddScore(TypesOfHits.Hits.Great);
            return;
        }
        AkSoundEngine.PostEvent("Hit_Event", gameObject);
        Destroy(gameObject);
        score.AddScore(TypesOfHits.Hits.Perfect);
    }
}
