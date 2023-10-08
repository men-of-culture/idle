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
    public Vector2 spawnBounds;

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
        /*if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points found. Please add child GameObjects to this spawner to act as spawn points.");
            return;
        }

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        var spawnPosition = randomSpawnPoint.position + new Vector3(Random.Range(-4f, 4f), 0, 0);*/

        // we can get rid of spawnpoints with spawnDistanceFromPlayer and this:
        var spawnPosition = new Vector3(0,0,0) + new Vector3(Random.Range(-spawnBounds.x, spawnBounds.x), Random.Range(-spawnBounds.y, spawnBounds.y), 0);

        // make sure monsters dont spawn on top of player
        if((spawnPosition-playerTransform.position).magnitude < spawnDistanceFromPlayer)
        {
            spawnPosition = spawnPosition + ((spawnPosition-playerTransform.position).normalized * spawnDistanceFromPlayer);
            spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);

            // make sure they spawn inside bounds, flip value if outside
            if(spawnPosition.x > spawnBounds.x || spawnPosition.x < -spawnPosition.x)
            {
                spawnPosition = spawnPosition - new Vector3((spawnPosition-playerTransform.position).x*2, 0, 0);
            }
            if(spawnPosition.y > spawnBounds.y || spawnPosition.y < -spawnPosition.y)
            {
                spawnPosition = spawnPosition - new Vector3(0, (spawnPosition-playerTransform.position).y*2, 0);
            }
        }

        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity, monsterList);
    }
}
