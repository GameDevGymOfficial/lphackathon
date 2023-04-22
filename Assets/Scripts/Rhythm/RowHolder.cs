using UnityEngine;

public enum RowIndex
{
    D, F, J, K
}

public class RowHolder : MonoBehaviour
{
    [field: SerializeField] public RowIndex Index { get; private set; }
    public KeyCode RowCode { get; private set; }

    private void Awake()
    {
        switch (Index)
        {
            case RowIndex.D:
                RowCode = SettingsManager.Key1;
                break;
            case RowIndex.F:
                RowCode = SettingsManager.Key2;
                break;
            case RowIndex.J:
                RowCode = SettingsManager.Key3;
                break;
            case RowIndex.K:
                RowCode = SettingsManager.Key4;
                break;
        }
    }
}
