using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterSpawnerManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    public Transform monsterList;
    private float spawnTimer = 0f;
    private int spawnCount = 100;

    private float timer = 0f;
    
    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private float spawnInterval;

    [SerializeField]
    private float initialSpawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        monsterList = GameObject.Find("MonsterList").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            if (timer > 30)
            {
                spawnInterval = initialSpawnInterval / (timer/30);
            }
            SpawnEnemy();
            spawnTimer = spawnInterval;
            spawnCount -= 1;
        }
        
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F0");
        spawnTimer -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points found. Please add child GameObjects to this spawner to act as spawn points.");
            return;
        }

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(monsterPrefab, randomSpawnPoint.position + new Vector3(Random.Range(-4f, 4f), 0, 0), Quaternion.identity, monsterList);
    }
}
