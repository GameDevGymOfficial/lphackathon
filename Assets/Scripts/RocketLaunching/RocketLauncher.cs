using UnityEngine;
using System.Collections.Generic;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private Transform launchTarget;
    [SerializeField] private GameObject rocketPrefab;

    [SerializeField] private Transform launchPointsParent;
    private List<Transform> launchPoints = new List<Transform>();

    private void Awake()
    {
        foreach(Transform ch in launchPointsParent)
        {
            launchPoints.Add(ch);
        }
    }

    [ContextMenu("Launch")]
    public void Launch()
    {
        LaunchForward();
    }
    [ContextMenu("LaunchToTarget")]
    public void LaunchToTarget()
    {
        LaunchTo(launchTarget);
    }

    public void LaunchTo(Transform target)
    {
        var rocket = SpawnRocket();

        rocket.SetTargetMovement(target);
    }
    public void LaunchForward()
    {
        var rocket = SpawnRocket();

        rocket.SetForwardMovement();
    }

    private Rocket SpawnRocket()
    {
        Transform spawnPoint = GetRandomLaunchPoint();

        var rocketGO = Instantiate(rocketPrefab, spawnPoint.position, spawnPoint.rotation);
        return rocketGO.GetComponent<Rocket>();
    }

    private Transform GetRandomLaunchPoint()
    {
        int randomSpawnPointIndex = Random.Range(0, launchPoints.Count);

        return launchPoints[randomSpawnPointIndex];
    }
}
