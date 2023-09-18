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
    private GameObject backButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    public void Play()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
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