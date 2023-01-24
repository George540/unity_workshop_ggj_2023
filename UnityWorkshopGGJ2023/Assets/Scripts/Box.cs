using UnityEngine;

public class Box : MonoBehaviour
{
    private SpawnerManager _spawnerManager;
    // Start is called before the first frame update
    void Start()
    {
        // Set a life timer for the object to get destroyed when spawned
        Destroy(gameObject, 3.0f);
    }

    public void SetSpawnerManager(SpawnerManager manager)
    {
        _spawnerManager = manager;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // If the object that is hit has a collider and has component "Player", it's game over
        if (col.gameObject.TryGetComponent<Player>(out var player))
        {
            _spawnerManager.Restart();
            player.RevealTextField();
            player.gameObject.SetActive(false);
        }
    }
}
