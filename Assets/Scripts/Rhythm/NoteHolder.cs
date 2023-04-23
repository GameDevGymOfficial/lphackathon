using UnityEngine;

public class NoteHolder : MonoBehaviour
{
    [SerializeField] private float Tempo;
    [SerializeField] private bool DownScroll = true;
    [SerializeField] private float[] timingList;
    [SerializeField] private GameObject Note;
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
        }
        if (DownScroll & started)
        {
            transform.position -= new Vector3(0, Tempo * Time.deltaTime, 0f);
        }
    }

    [ContextMenu("Move")]
    private void Move()
    {
        foreach (var timing in timingList)
        {
            transform.position = new Vector3(transform.position.x, ((Tempo / 60) * timing)-0.75f, 0f);
            Instantiate(Note, transform.position,transform.rotation);
        }
        transform.position = new Vector3(transform.position.x,  - 0.75f, 0f);
    }
}
