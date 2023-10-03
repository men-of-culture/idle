using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    public float moveInterval = 0.1f;
    public float moveTimer = 0.1f;

    public SpriteRenderer spriteRenderer;
    public float fadeTimer = 1f;

    private bool fade;

    private PlayerScript playerScript;

    public float movementSpeed = 1f;
    
    private Vector3 targetPosition;

    [SerializeField]
    private StringManager stringManager;

    [SerializeField]
    private AudioSource deathAudioSource;

    private bool startFadeOut;

    private CircleCollider2D collider;

    public GameObject lootPrefab;
    public Transform lootList;


    // Start is called before the first frame update
    void Start()
    {
        //moveInterval = Random.Range(1f, 5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = FindObjectOfType<PlayerScript>();
        //targetPosition = playerScript.transform.position;
        //spriteRenderer.flipX = targetPosition.x < 0;
        deathAudioSource = transform.parent.GetComponent<AudioSource>();
        collider = GetComponent<CircleCollider2D>();
        lootList = GameObject.Find("LootList").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTimer <= 0 && !fade)
        {
            spriteRenderer.color += new Color(0f,0f,0f,1f);
            fade = true;
        } 
        else if (fadeTimer > 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f - fadeTimer);
            fadeTimer -= Time.deltaTime;
        }
        StartFadeOut();
        
        //if (moveTimer <= 0)
        //{
        if (playerStatsManager.health <= 0 || startFadeOut) return;
            MonsterMove();
        //    moveTimer = moveInterval;
        //}

        //moveTimer -= Time.deltaTime;
        
        // need to update this when player is moving
        targetPosition = playerScript.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(stringManager.playerTag))
        {
            Debug.Log("This monster trigger was hit by: "+other.name);
            playerScript.HitByMonster();
            Destroy(gameObject);
        }

        if (other.CompareTag(stringManager.projectileTag))
        {
            deathAudioSource.Play();
            Debug.Log("This monster trigger was hit by: Projectile");

            spriteRenderer.color += new Color(0f,0f,0f,1f);
            fade = true;
            fadeTimer = 1.0f;
            startFadeOut = true;
            collider.enabled = false;
        }
    }

    void StartFadeOut()
    {
        if(!startFadeOut) return;
        if (fadeTimer > 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f + fadeTimer);
            fadeTimer -= Time.deltaTime;
        }
        else if (fade && fadeTimer <= 0)
        {
            playerStatsManager.kills++;
            if(Random.Range(1, 3) == 2)
            {
                var x = Instantiate(lootPrefab, lootList);
                x.transform.position = gameObject.transform.position;
            }
            Destroy(gameObject);
        }
    }

    void MonsterMove()
    {
        spriteRenderer.flipX = (targetPosition-transform.position).x < 0;
        transform.position += (targetPosition-transform.position).normalized * ((movementSpeed/10f) * Time.deltaTime);
    }
}
