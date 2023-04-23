using UnityEngine;

public class Planet : MonoBehaviour
{
    float speed, minspeed = 0.1f, maxspeed = 1f;

    Vector3 endPoint;

    private void Start()
    {
        speed = Mathf.Lerp(minspeed, maxspeed, Random.Range(0, 1));
        endPoint = transform.position + Vector3.down * 500 + Vector3.right * Random.Range(-1, 1) * 2;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
    }
}
