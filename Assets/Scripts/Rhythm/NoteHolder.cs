using UnityEngine;

public class NoteHolder : MonoBehaviour
{
    [SerializeField] private float Tempo;
    [SerializeField] private bool DownScroll = true;
    private bool started;

    private void Start()
    {
        Tempo = Tempo / 60f;
    }

    private void Update()
    {
        if (Input.anyKeyDown & !started)
        {
            started = true;
            AkSoundEngine.PostEvent("Lvl_one", gameObject);
        }
        if (DownScroll & started)
        {
            transform.position -= new Vector3(0, Tempo * Time.deltaTime, 0f);
        }
    }

    [ContextMenu("Move")]
    private void Move()
    {
        transform.position = new Vector3(transform.position.x, (Tempo / 60) * 15.28f, 0f);
    }
}
