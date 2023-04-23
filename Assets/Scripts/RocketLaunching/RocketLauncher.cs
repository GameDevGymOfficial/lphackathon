using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform[] launchPoints;

    public void LaunchTo(Transform target, int index)
    {
        var rocket = SpawnRocket(launchPoints[index]);

        rocket.SetTargetMovement(target);
    }
    public void LaunchForward(int index)
    {
        var rocket = SpawnRocket(launchPoints[index]);

        rocket.SetForwardMovement();
    }

    private Rocket SpawnRocket(Transform Pos)
    {
        var rocketGO = Instantiate(rocketPrefab, Pos.position, Pos.rotation);
        return rocketGO.GetComponent<Rocket>();
    }
}
