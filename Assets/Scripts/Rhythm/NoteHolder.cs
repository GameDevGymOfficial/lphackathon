using UnityEngine;

public class NoteHolder : MonoBehaviour
{
    public float Tempo;
    public bool DownScroll = true;
    private void Start()
    {
        Tempo = Tempo / 60f;
    }
    private void Update()
    {
        if (DownScroll)
        {
            transform.position -= new Vector3(0, Tempo * Time.deltaTime, 0f);
        }
    }
    [ContextMenu("Move")]
    void Move()
    {
        transform.position = new Vector3(transform.position.x, (Tempo/60) * 15.28f, 0f);
    }
}
