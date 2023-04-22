using UnityEngine;

public class RocketWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.transform.CompareTag("Rocket"))
        {
            Debug.Log("Rocket");
            Destroy(collision.gameObject);
        }
    }
}
