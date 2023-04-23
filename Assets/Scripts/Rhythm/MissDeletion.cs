using UnityEngine;

public class MissDeletion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            collision.GetComponent<NoteObject>().OnMissDeletion();
            Destroy(collision.gameObject);
            AkSoundEngine.PostEvent("Miss_Event", gameObject);
;       }
    }
}
