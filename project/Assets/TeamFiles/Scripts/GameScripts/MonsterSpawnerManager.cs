using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterSpawnerManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    private float spawnTimer = 0f;
    private int spawnCount = 100;

    public float timer = 0f;
    
    [SerializeField]
    public PlayerStatsManager playerStatsManager;

    [SerializeField]
    public Transform monsterList;
    
    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private float spawnInterval;

    [SerializeField]
    private float initialSpawnInterval;

    public float spawnDistanceFromPlayer;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindObjectOfType<PlayerScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0 && playerStatsManager.health > 0)
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

        var spawnPosition = randomSpawnPoint.position + new Vector3(Random.Range(-4f, 4f), 0, 0);

        // make sure monsters dont spawn on top of player
        if((spawnPosition-playerTransform.position).magnitude < spawnDistanceFromPlayer)
        {
            spawnPosition = spawnPosition + ((spawnPosition-playerTransform.position).normalized * spawnDistanceFromPlayer);
            spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
        }

        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity, monsterList);
    }
}
