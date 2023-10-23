using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas playeruiCanvas;
    public Canvas blacksmithCanvas;
    public Canvas churchCanvas;
    public Canvas wizardCanvas;
    public Canvas knightCanvas;
    public Canvas playerCanvas;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private GameObject backButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private GameObject changeScenePrefab;

    public EscMenuScript escMenuScript;
    
    public TextMeshProUGUI buyAscensionText;
    public Button buyAscensionButton;
    public Image buyAscensionButtonImg;
    public Image ascensionBgImg;
    public Image ascensionBgBorderImg;
    public TextMeshProUGUI ascensionContext;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(playerCanvas.enabled == true) Back();
            else if(escMenuScript.hasOpenCanvas == false) PlayerToggle();
        }
    }

    public void Ascend()
    {
        PlayerPrefs.SetInt("ascension", PlayerPrefs.GetInt("ascension")+1);
        playerStatsManager.ascension = PlayerPrefs.GetInt("ascension");
        
        // reset stats and perks and upgrades
        PlayerPrefs.SetInt("upgradeOne", 0);
        PlayerPrefs.SetInt("upgradeTwo", 0);
        PlayerPrefs.SetInt("upgradeThree", 0);
        PlayerPrefs.SetInt("upgradeFour", 0);
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetInt("perk1", 0);
        PlayerPrefs.SetInt("perk2", 0);
        PlayerPrefs.SetInt("perk3", 0);

        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(1);
    }

    public void Play()
    {
        playerStatsManager.reset();
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BlacksmithToggle()
    {
        Back();
        playeruiCanvas.enabled = false;
        blacksmithCanvas.enabled = true;

        eventSystem.firstSelectedGameObject = backButton;
        escMenuScript.hasOpenCanvas = true;
    }
    public void WizardToggle()
    {
        Back();
        playeruiCanvas.enabled = false;
        wizardCanvas.enabled = true;
        escMenuScript.hasOpenCanvas = true;
    }
    public void ChurchToggle()
    {
        Back();
        playeruiCanvas.enabled = false;
        churchCanvas.enabled = true;
        escMenuScript.hasOpenCanvas = true;
    }
    public void KnightToggle()
    {
        Back();
        playeruiCanvas.enabled = false;
        knightCanvas.enabled = true;
        escMenuScript.hasOpenCanvas = true;

        // ascend canvas
        if(playerStatsManager.ascension < 2)
        {
            if(PlayerPrefs.GetInt("currency") >= 10000)
            {
                // show ascension
                buyAscensionText.enabled = true;
                buyAscensionButton.enabled = true;
                buyAscensionButtonImg.enabled = true;
                ascensionBgImg.enabled = true;
                ascensionBgBorderImg.enabled = true;
                ascensionContext.enabled = true;
            }
            else
            {
                buyAscensionText.enabled = false;
                buyAscensionButton.enabled = false;
                buyAscensionButtonImg.enabled = false;
                ascensionBgImg.enabled = false;
                ascensionBgBorderImg.enabled = false;
                ascensionContext.enabled = false;
            }
            
        }
    }

    public void PlayerToggle()
    {
        Back();
        playeruiCanvas.enabled = false;
        playerCanvas.enabled = true;
        escMenuScript.hasOpenCanvas = true;
    }

    public void Back()
    {
        playeruiCanvas.enabled = true;
        knightCanvas.enabled = false;
        playerCanvas.enabled = false;
        churchCanvas.enabled = false;
        wizardCanvas.enabled = false;
        blacksmithCanvas.enabled = false;
        escMenuScript.hasOpenCanvas = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
