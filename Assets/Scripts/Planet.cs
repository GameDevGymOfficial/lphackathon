using UnityEngine;

public class Planet : MonoBehaviour
{
    float t;
    float speed, minspeed = 0.01f, maxspeed = 0.5f;

    Vector2 startPoint, endPoint;

    private void Start()
    {
        speed = Mathf.Lerp(speed, minspeed, Random.Range(0, 1));
        startPoint = transform.position;
        endPoint = (Vector2)transform.position + Vector2.down * 10 + Vector2.right * Random.Range(-1, 1) * 10;
    }

    private void Update()
    {
        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(startPoint, endPoint, t);
    }
}
