using UnityEngine;

public class RocketWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Rocket"))
        {
            Destroy(collision.gameObject);
        }
    }
}
