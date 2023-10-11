using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    public Canvas playerStatsCanvas;

    [SerializeField]
    private Text damageText;

    [SerializeField]
    private Text attackSpeedText;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text armorText;

    [SerializeField]
    private Text projectileCountText;

    [SerializeField]
    private Text multiHitCountText;

    [SerializeField]
    private Text goldGainText;

    [SerializeField]
    private Text skipMinText;

    [SerializeField]
    private Text expGainText;

    [SerializeField]
    private Text goldCountText;

    [SerializeField]
    private Text expCountText;

    private StringManager stringManager;
    
    // Start is called before the first frame update
    void Start()
    {
        damageText.text = PlayerPrefs.GetInt(stringManager.upgradeOne, 1).ToString();
        attackSpeedText.text = PlayerPrefs.GetInt(stringManager.upgradeTwo, 1).ToString();
        healthText.text = PlayerPrefs.GetInt(stringManager.upgradeThree, 10).ToString();
        goldCountText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();
        expCountText.text = PlayerPrefs.GetInt(stringManager.lifetimeKills).ToString();
        armorText.text = PlayerPrefs.GetInt(stringManager.upgradeFour).ToString();
        playerStatsCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            TogglePlayerStats();
            // if we want stats to updates as run goes on we need to set stats in 
            // if (playerStatsCanvas.GetComponent<Canvas>().enabled)
            // {
            //     expCountText.text = PlayerPrefs.GetInt("lifetimeKills").ToString();
            // }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerStatsCanvas.enabled = false;
        }
        
    }

    public void TogglePlayerStats()
    {
        playerStatsCanvas.enabled = !playerStatsCanvas.enabled;
    }
}
