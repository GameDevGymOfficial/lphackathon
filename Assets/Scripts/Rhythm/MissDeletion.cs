using UnityEngine;

public class MissDeletion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Absolute miss");
            AkSoundEngine.PostEvent("Miss_Event",gameObject);
            //Minus HP and combo
;        }
    }
}
