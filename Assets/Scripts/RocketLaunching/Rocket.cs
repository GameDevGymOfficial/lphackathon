using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private bool isTargetMovement;

    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float targetSpeed = 1f;

    private Transform target;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Boom();
        }
    }

    public void SetTargetMovement(Transform target)
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
        rb2d.MovePosition(Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * targetSpeed));
    }

    private void Boom()
    {
        Destroy(gameObject);
    }
}
