using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsScript : MonoBehaviour
{
    public Canvas playerStatsCanvas;

    [SerializeField]
    private TextMeshProUGUI damageText;

    [SerializeField]
    private TextMeshProUGUI attackSpeedText;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private TextMeshProUGUI armorText;

    [SerializeField]
    private TextMeshProUGUI longestRunText;

    [SerializeField]
    private TextMeshProUGUI lifetimeKillsText;

    [SerializeField]
    private TextMeshProUGUI ascensionText;

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
    private TextMeshProUGUI goldCountText;

    [SerializeField]
    private Text expCountText;

    [SerializeField]
    private StringManager stringManager;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private EscMenuScript escMenuScript;
    
    // Start is called before the first frame update
    void Start()
    {
        damageText.text = PlayerPrefs.GetInt(stringManager.upgradeOne, 1).ToString();
        attackSpeedText.text = PlayerPrefs.GetInt(stringManager.upgradeOne, 1).ToString();
        healthText.text = PlayerPrefs.GetInt(stringManager.upgradeThree, 10).ToString();
        armorText.text = PlayerPrefs.GetInt(stringManager.upgradeFour).ToString();
        goldCountText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();
        ascensionText.text = PlayerPrefs.GetInt("ascension").ToString();
        //expCountText.text = PlayerPrefs.GetInt(stringManager.lifetimeKills).ToString();
        playerStatsCanvas = GetComponent<Canvas>();

        longestRunText.text = PlayerPrefs.GetInt(stringManager.longestRun).ToString();
        lifetimeKillsText.text = PlayerPrefs.GetInt(stringManager.lifetimeKills).ToString();
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
            ClosePlayerStats();
        }
        
    }

    public void ClosePlayerStats()
    {
        playerStatsCanvas.enabled = false;
        escMenuScript.hasOpenCanvas = false;
    }

    public void TogglePlayerStats()
    {
        playerStatsCanvas.enabled = !playerStatsCanvas.enabled;
        if (playerStatsCanvas.enabled) escMenuScript.hasOpenCanvas = true;
        else escMenuScript.hasOpenCanvas = false;
    }
}
