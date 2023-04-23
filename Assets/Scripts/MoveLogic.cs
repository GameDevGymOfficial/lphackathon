using UnityEngine;

public class MoveLogic : MonoBehaviour
{
    private RocketLauncher rocketLauncher;

    [SerializeField] private RowHolder[] rowHolders;
    [SerializeField] private Transform defaultPosition;

    private bool isKey1Inputed, isKey2Inputed, isKey3Inputed, isKey4Inputed;

    private KeyCode[] moveKeys;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        rocketLauncher = GetComponent<RocketLauncher>();
    }

    private void Start()
    {
        moveKeys = new KeyCode[] 
        { 
            rowHolders[0].RowCode, 
            rowHolders[1].RowCode, 
            rowHolders[2].RowCode, 
            rowHolders[3].RowCode 
        };
    }

    private void Update()
    {
        isKey1Inputed = Input.GetKey(SettingsManager.Key1);
        isKey2Inputed = Input.GetKey(SettingsManager.Key2);
        isKey3Inputed = Input.GetKey(SettingsManager.Key3);
        isKey4Inputed = Input.GetKey(SettingsManager.Key4);

        InputKey(SettingsManager.Key1, 0);
        InputKey(SettingsManager.Key2, 1);
        InputKey(SettingsManager.Key3, 2);
        InputKey(SettingsManager.Key4, 3);

        bool isAnyButtonPressed = isKey1Inputed || isKey2Inputed || isKey3Inputed || isKey4Inputed;

        Transform target = defaultPosition;

        if (isKey1Inputed)
        {
            target = rowHolders[0].transform;
        }
        else if (isKey2Inputed)
        {
            target = rowHolders[1].transform;
        }
        else if (isKey3Inputed)
        {
            target = rowHolders[2].transform;
        }
        else if (isKey4Inputed)
        {
            target = rowHolders[3].transform;
        }

        MoveTo(new Vector3(target.position.x, transform.position.y, 0));
    }

    private void InputKey(KeyCode key, int i)
    {
        if (Input.GetKeyDown(key))
        {
            //rocketLauncher.LaunchForward(i);
        }
    }

    private void MoveTo(Vector3 pos)
    {
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, 0.05f);
    }
}
