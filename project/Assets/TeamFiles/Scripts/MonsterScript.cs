using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    public float moveInterval;
    private float moveTimer = 5f;

    public SpriteRenderer spriteRenderer;
    public float fadeTimer = 1f;

    private bool fade;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        moveInterval = Random.Range(1f, 5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
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
        
        if (moveTimer <= 0)
        {
            MonsterMove();
            moveTimer = moveInterval;
        }

        moveTimer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Monster trigger rammer player");
            var playerScript = other.GetComponent<PlayerScript>();
            playerScript.kills++;
            GameObject.Find("PlayerCanvas").GetComponentInChildren<Text>().text =
                playerScript.kills.ToString();
            Destroy(gameObject);
        }
    }

    void MonsterMove()
    {
        float range = Random.Range(-4f, 4f);
        spriteRenderer.flipX = range < 0;
        agent.SetDestination(transform.position + new Vector3(range, 0, 0));
    }
}
