using UnityEngine;
using System.Collections.Generic;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private Transform launchTarget;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform[] launchPoints;

    private void Awake()
    {
        launchPoints = new Transform[4];
    }

    [ContextMenu("Launch")]
    public void Launch()
    {
        LaunchForward(1);
    }
    [ContextMenu("LaunchToTarget")]
    public void LaunchToTarget()
    {
        LaunchTo(launchTarget,1);
    }

    public void LaunchTo(Transform target,int index)
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
