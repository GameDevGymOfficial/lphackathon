using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float boomDistance = 0.5f;

    private bool isBoom;
    private bool isTargetMovement;

    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float targetSpeed = 1f;

    private NoteObject target;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isTargetMovement)
            MoveToTarget();
        else
            MoveForward();
    }

    public void SetTargetMovement(NoteObject target)
    {
        this.target = target;
        isTargetMovement = true;
    }
    public void SetForwardMovement()
    {
        isTargetMovement = false;
    }

    private void MoveForward()
    {
        rb2d.MovePosition((Vector2)transform.position + Vector2.up * forwardSpeed * Time.deltaTime);
    }
    private void MoveToTarget()
    {
        if (target == null)
            return;
        if (isBoom)
            return;

        rb2d.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * targetSpeed));

        if ((transform.position - target.transform.position).magnitude < boomDistance)
            Boom();
    }

    private void Boom()
    {
        isBoom = true;
        target.HitDestroy();
        gameObject.SetActive(false);
        Destroy(gameObject, 3);
    }
}
