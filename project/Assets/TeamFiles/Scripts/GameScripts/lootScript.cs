using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{

    public float fadeTimer = 1.0f;
    public bool fade = true;
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private StringManager stringManager;
    
    [SerializeField]
    private PlayerStatsManager playerStatsManager;
    public bool startFadeOut;
    private BoxCollider2D boxCollider2D;
    private PlayerScript playerScript;
    private PlayerMovementScript playerMovementScript;
    private bool fadeIn;
    public int loot;
    public int lootMagnetSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerScript = FindObjectOfType<PlayerScript>();
        playerMovementScript = FindObjectOfType<PlayerMovementScript>();
        fadeIn = true;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);

        loot = loot + (loot * PlayerPrefs.GetInt("ascension"));
    }

    // Update is called once per frame
    void Update()
    {
        StartFadeIn();
        StartFadeOut();
        LootMagnetPerk();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit stuff");
        if (other.CompareTag(stringManager.playerTag))
        {
            Debug.Log("This loot trigger was hit by: "+other.name);
            startFadeOut = true;
            boxCollider2D.enabled = false;
            fadeTimer = 1.0f;
            playerMovementScript.startLooting = true;
            playerMovementScript.lootingTimer = 1f;
        }
    }

    void LootMagnetPerk()
    {
        if(playerStatsManager.perk1 == 1 && !fadeIn && !startFadeOut)
        {
            transform.position += ((playerScript.transform.position-transform.position).normalized*Time.deltaTime/10)*lootMagnetSpeed;
        }
    }

    void StartFadeIn()
    {
        if(!fadeIn) return;

        if (fadeTimer > 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f - fadeTimer);
            fadeTimer -= Time.deltaTime;
        }
        else if (fadeTimer <= 0)
        {
            fadeIn = false;
            fadeTimer = 0;
        }
    }

    void StartFadeOut()
    {
        if(!startFadeOut) return;
        if (fadeTimer > 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f + fadeTimer);
            fadeTimer -= Time.deltaTime*3;
        }
        else if (fadeTimer <= 0)
        {
            playerScript.Loot(loot);

            Destroy(gameObject);
        }
    }
}
