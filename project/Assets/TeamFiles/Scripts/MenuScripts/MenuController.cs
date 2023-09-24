using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas upgradeCanvas;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private GameObject backButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private GameObject changeScenePrefab;

    public void Play()
    {
        playerStatsManager.reset();
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Upgrade()
    {
        menuCanvas.enabled = false;
        upgradeCanvas.enabled = true;

        eventSystem.firstSelectedGameObject = backButton;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
