using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int kills;

    public int health = 10;
    
    private PlayerScript playerScript;
    private Text killsText;
    private Text healthText;
    private Text endKillsText;
    public GameObject playercanvas;
    public GameObject endRunCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        killsText = GameObject.Find("KillsText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        endKillsText = GameObject.Find("EndKillsText").GetComponent<Text>();
        playercanvas = GameObject.Find("PlayerCanvas");
        endRunCanvas = GameObject.Find("EndRunCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitByMonster()
    {
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
    }
}
