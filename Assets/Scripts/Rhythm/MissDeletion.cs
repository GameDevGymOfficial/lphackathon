using UnityEngine;

public class MissDeletion : MonoBehaviour
{
    private HP hp;
    private ScoreHPScript score;

    private void Awake()
    {
        hp = FindObjectOfType<HP>();
        score = FindObjectOfType<ScoreHPScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
            AkSoundEngine.PostEvent("Miss_Event", gameObject);
;       }
    }
}
