using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform[] launchPoints;

    private void Awake()
    {
        NoteObject[] notes = FindObjectsOfType<NoteObject>();
        foreach (NoteObject note in notes)
        {
            note.OnHit += LaunchTo;
        }
    }

    public void LaunchTo(NoteObject target, RowIndex index)
    {
        var rocket = SpawnRocket(launchPoints[(int)index]);

        rocket.SetTargetMovement(target);
    }
    public void LaunchForward(int index)
    {
        var rocket = SpawnRocket(launchPoints[index]);

        rocket.SetForwardMovement();
    }

    private Rocket SpawnRocket(Transform spawnPoint)
    {
        var rocketGO = Instantiate(rocketPrefab, spawnPoint.position, spawnPoint.rotation);
        return rocketGO.GetComponent<Rocket>();
    }
}
