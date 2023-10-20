using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas blacksmithCanvas;
    public Canvas churchCanvas;
    public Canvas wizardCanvas;
    public Canvas knightCanvas;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private GameObject backButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private GameObject changeScenePrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Play()
    {
        playerStatsManager.reset();
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BlacksmithToggle()
    {
        //menuCanvas.enabled = false;
        blacksmithCanvas.enabled = true;

        eventSystem.firstSelectedGameObject = backButton;
    }
    public void WizardToggle()
    {
        menuCanvas.enabled = false;
        wizardCanvas.enabled = true;
    }
    public void ChurchToggle()
    {
        menuCanvas.enabled = false;
        churchCanvas.enabled = true;
    }
    public void KnightToggle()
    {
        menuCanvas.enabled = false;
        knightCanvas.enabled = true;
    }

    public void Back()
    {
        menuCanvas.enabled = true;
        knightCanvas.enabled = false;
        churchCanvas.enabled = false;
        wizardCanvas.enabled = false;
        blacksmithCanvas.enabled = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
