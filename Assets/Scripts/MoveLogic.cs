using UnityEngine;

public class MoveLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints = new GameObject[4];
    [SerializeField] private GameObject defaultPosition;
    private KeyCode[] moveKeys;
    private Vector3 velocity = Vector3.zero;
    private int index;
    private bool pressed;
    private void Start()
    {
        moveKeys = new KeyCode[] { movePoints[0].GetComponent<RowHolder>().RowCode, movePoints[1].GetComponent<RowHolder>().RowCode , movePoints[2].GetComponent<RowHolder>().RowCode , movePoints[3].GetComponent<RowHolder>().RowCode };
    }
    private void Update()
    {
        pressed = false;
        index = 0;
        foreach (var moveKey in moveKeys)
        {
            index++;
            if(Input.GetKey(moveKey))
            {
                transform.position=Vector3.SmoothDamp(transform.position, new Vector3(movePoints[index-1].transform.position.x, transform.position.y, 0),ref velocity,0.1f);
                pressed = true;
            }
        }
        if (!pressed)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(defaultPosition.transform.position.x, transform.position.y, 0), ref velocity, 0.1f);
        }
    }
}
