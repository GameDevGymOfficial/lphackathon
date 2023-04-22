using UnityEngine;
public class RowHolder : MonoBehaviour
{
    public bool NoteCanBePressed { get; private set; }
    [field: SerializeField] public KeyCode RowCode { get; private set; }
}
