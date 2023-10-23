using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
