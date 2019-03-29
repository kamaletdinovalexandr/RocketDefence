using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour {

    public List<Transform> SpawnPoints;
    public float spawnIntervalMin;
    public float spawnIntervalMax;
    private float _currentInterval;
    private float _spawnTimer = 0f;
    public GameObject EnemyPrefab;
    public Transform target;

    // Update is called once per frame
    void Update () {
        if (GameController.Instance.IsGamOver) {
            return;
        }

        _spawnTimer += Time.deltaTime;
		if (_spawnTimer > _currentInterval) {
            _spawnTimer = 0f;
            _currentInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            var go = Instantiate(EnemyPrefab, GetRandomSpawnPoint().position, Quaternion.identity);
            go.GetComponent<Enemy>().Target = target;
        }
	}

    private Transform GetRandomSpawnPoint() {
        var spawnPoint =  Random.Range(0, SpawnPoints.Count);
        return SpawnPoints[spawnPoint];
    }
}
