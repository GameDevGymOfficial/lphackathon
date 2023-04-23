using UnityEngine;

public class MissDeletion : MonoBehaviour
{
    [SerializeField] private ScoreHPScript score;

    private void Awake()
    {
        score = FindObjectOfType<ScoreHPScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            collision.GetComponent<NoteObject>().OnMissDeletion();
            score.hitCount[4]++;
            Destroy(collision.gameObject);
            AkSoundEngine.PostEvent("Miss_Event", gameObject);
;       }
    }
}
