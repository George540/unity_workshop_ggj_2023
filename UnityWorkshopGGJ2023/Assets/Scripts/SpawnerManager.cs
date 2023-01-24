using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerManager : MonoBehaviour
{
    public Transform[] _spawners;
    public GameObject _box;
    public float _spawnTimer;
    private float _spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        _spawnCooldown = _spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnCooldown -= Time.deltaTime;
        
        // Spawn boxes when countdown has been finished
        if (_spawnCooldown <= 0)
        {
            // generate number that will indicate the spawner that won't spawn box
            var spawnerToBlock = Random.Range(0, _spawners.Length);
            for (var i = 0; i < _spawners.Length; ++i)
            {
                // spawn the box if the index does not match the generated number
                if (i != spawnerToBlock)
                {
                    SpawnBox(_spawners[i].position);
                }
            }
            // restart countdown uppon spawn
            _spawnCooldown = _spawnTimer;
        }
    }

    private void SpawnBox(Vector3 position)
    {
        var box = Instantiate(_box, position, Quaternion.identity);
        // We need a reference of the SpawnerManager, so we send it to the box
        box.GetComponent<Box>().SetSpawnerManager(this);
    }

    public void Restart()
    {
        StartCoroutine(RestartGame());
    }
    
    // Coroutines are separate from the main thread, so they run in parallel with the main thread (update,etc)
    private IEnumerator RestartGame()
    {
        // we wait two seconds before the scene restarts
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
