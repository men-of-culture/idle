using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootScript : MonoBehaviour
{

    public float fadeTimer = 1.0f;
    public bool fade = false;
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private StringManager stringManager;
    private bool startFadeOut;
    private BoxCollider2D collider;
    private PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        playerScript = FindObjectOfType<PlayerScript>();
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit stuff");
        if (other.CompareTag(stringManager.playerTag))
        {
            Debug.Log("This loot trigger was hit by: "+other.name);
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
            Destroy(gameObject);
            playerScript.Kill();
        }
    }
}
