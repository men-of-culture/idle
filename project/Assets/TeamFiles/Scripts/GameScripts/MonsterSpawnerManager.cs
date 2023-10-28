using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterSpawnerManager : MonoBehaviour
{
    public GameObject monsterPrefab, monsterBossPrefab;
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
    public int bossSpawned;
    public int bossSpawnTime = 120;

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

        Debug.DrawCircle(new Vector3(playerTransform.position.x-0.5f, playerTransform.position.y, 0), spawnDistanceFromPlayer, 32, Color.green);

        SpawnBoss();
    }

    void SpawnBoss()
    {
        if(bossSpawned < Mathf.Floor(timer/(bossSpawnTime)))
        {
            bossSpawned += 1;
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
            var x = Instantiate(monsterBossPrefab, spawnPosition, Quaternion.identity, monsterList);
            var mobScript = x.GetComponent<MonsterScript>();
            mobScript.maxHealth = mobScript.maxHealth*Mathf.Floor(timer/60);
            mobScript.damage = mobScript.damage*(int)Mathf.Floor(timer/60);
            mobScript.loot += (int)Mathf.Floor(timer/60);
        }
    }

    void SpawnEnemy()
    {
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

        var x = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity, monsterList);
        var mobScript = x.GetComponent<MonsterScript>();
        mobScript.maxHealth += mobScript.maxHealth*Mathf.Floor(timer/60);
        mobScript.damage += mobScript.damage > 0 ? mobScript.damage*(int)Mathf.Floor(timer/60) : (int)Mathf.Floor(timer/60);
        mobScript.loot += (int)Mathf.Floor(timer/60);
    }
}
