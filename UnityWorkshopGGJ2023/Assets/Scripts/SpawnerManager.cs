using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        if (_spawnCooldown <= 0)
        {
            var spawnerToBlock = Random.Range(0, _spawners.Length);
            for (var i = 0; i < _spawners.Length; ++i)
            {
                if (i != spawnerToBlock)
                {
                    SpawnBox(_spawners[i].position);
                }
            }
            _spawnCooldown = _spawnTimer;
        }
    }

    private void SpawnBox(Vector3 position)
    {
        Instantiate(_box, position, Quaternion.identity);
    }
}
