using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscMenuScript : MonoBehaviour
{
    private Canvas escMenuCanvas;
    
    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private StringManager stringManager;

    [SerializeField]
    private GameObject exitGameButton;
    
    [SerializeField]
    private GameObject endRunButton;
    
    [SerializeField]
    private Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        escMenuCanvas = GetComponent<Canvas>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // disable end run button
            endRunButton.GetComponent<Button>().enabled = false;
            endRunButton.GetComponent<Image>().enabled = false;
            endRunButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = false;
            // enable exit game button
            exitGameButton.GetComponent<Button>().enabled = true;
            exitGameButton.GetComponent<Image>().enabled = true;
            exitGameButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // disable exit game button
            exitGameButton.GetComponent<Button>().enabled = false;
            exitGameButton.GetComponent<Image>().enabled = false;
            exitGameButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = false;
            // enable exit run button
            endRunButton.GetComponent<Button>().enabled = true;
            endRunButton.GetComponent<Image>().enabled = true;
            endRunButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = true;
        }

        volumeSlider.value = playerStatsManager.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscMenu();
        }
    }

    public void ToggleEscMenu()
    {
        escMenuCanvas.enabled = !escMenuCanvas.enabled;
    }

    public void EndRun()
    {
        PlayerPrefs.SetInt(stringManager.currency, PlayerPrefs.GetInt(stringManager.currency) + playerStatsManager.kills);
        PlayerPrefs.SetInt(stringManager.lifetimeKills, PlayerPrefs.GetInt(stringManager.lifetimeKills) + playerStatsManager.kills);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1, LoadSceneMode.Single);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void VolumeChanged()
    {
        playerStatsManager.volume = volumeSlider.value;
        AudioListener.volume = playerStatsManager.volume;
        PlayerPrefs.SetFloat(stringManager.volume, AudioListener.volume);
    }
}
