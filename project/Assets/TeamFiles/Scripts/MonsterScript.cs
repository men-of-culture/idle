using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    public float moveInterval = 0.1f;
    public float moveTimer = 0.1f;

    public SpriteRenderer spriteRenderer;
    public float fadeTimer = 1f;

    private bool fade;

    private PlayerScript playerScript;
    private Text killsText;
    private Text healthText;
    private Text endKillsText;

    public float movementSpeed = 1f;
    
    private Vector3 targetPosition;

    public GameObject playercanvas;
    public GameObject endRunCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //moveInterval = Random.Range(1f, 5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = FindObjectOfType<PlayerScript>();
        killsText = GameObject.Find("KillsText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        endKillsText = GameObject.Find("EndKillsText").GetComponent<Text>();
        targetPosition = playerScript.transform.position - transform.position;
        spriteRenderer.flipX = targetPosition.x < 0;
        playercanvas = GameObject.Find("PlayerCanvas");
        endRunCanvas = GameObject.Find("EndRunCanvas");
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
        
        //if (moveTimer <= 0)
        //{
        if (playerScript.health <= 0) return;
            MonsterMove();
        //    moveTimer = moveInterval;
        //}

        //moveTimer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("This monster trigger was hit by: "+other.name);
            
            // put into function in playerscript with parameters
            playerScript.kills++;
            killsText.text = playerScript.kills.ToString();
            playerScript.health--;
            healthText.text = playerScript.health.ToString();
            if (playerScript.health <= 0)
            {
                endKillsText.text = playerScript.kills.ToString();
                playercanvas.GetComponent<Canvas>().enabled = false;
                endRunCanvas.GetComponent<Canvas>().enabled = true;
            }
            
            Destroy(gameObject);
        }
    }

    void MonsterMove()
    {
        transform.position += targetPosition * ((movementSpeed/100f) * Time.deltaTime);
    }
}
