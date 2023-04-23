using System;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public Action OnMiss;
    public Action<NoteObject, RowIndex> OnHit;

    private RowHolder rowHolder;
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

        rowHolder = GetComponentInParent<RowHolder>();
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

            if (isEnd)
            {
                gameManager.Win();
            }
        }
    }
    public void OnMissDeletion()
    {
        Miss();
        Debug.Log("Absolute miss");
        FindObjectOfType<HP>().ChangeHealth(-1);
    }

    private void TryHit()
    {
        float notePositionY = gameObject.transform.position.y;
        float judgment = Math.Abs(notePositionY - buttonPositionY) * 100;
        
        if (judgment < (int)HitType.Perfect)
        {
            Hit(HitType.Perfect);
        }
        else if (judgment < (int)HitType.Great)
        {
            Hit(HitType.Great);
        }
        else if (judgment < (int)HitType.Ok)
        {
            Hit(HitType.Ok);
        }
        else if (judgment < (int)HitType.Bad)
        {
            Hit(HitType.Bad);
        }
        else
        {
            score.AddScore(HitType.Miss);
            Miss();
        }
    }

    private void Miss()
    {
        OnMiss?.Invoke();
    }

    private void Hit(HitType hitType)
    {
        OnHit?.Invoke(this, rowHolder.Index);
        score.AddScore(hitType);
    }
    public void HitDestroy()
    {
        AkSoundEngine.PostEvent("Hit_Event", gameObject);
        gameObject.SetActive(false);
        Destroy(gameObject, 5);
    }
}
