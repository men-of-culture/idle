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
    [SerializeField]
    private Canvas escMenuCanvas;

    [SerializeField]
    private Canvas endExitCanvas;
    
    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private StringManager stringManager;

    [SerializeField]
    private GameObject exitGameButton;
    
    [SerializeField]
    private GameObject endRunButton;

    [SerializeField]
    private GameObject exitGamePromptButton;
    
    [SerializeField]
    private GameObject endRunPromptButton;

    [SerializeField]
    private TextMeshProUGUI exitGamePromptText;
    
    [SerializeField]
    private TextMeshProUGUI endRunPromptText;
    
    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private GameObject changeScenePrefab;

    [SerializeField]
    private AudioSource popAudioSource;

    [SerializeField]
    private MonsterSpawnerManager monsterSpawnerManager;

    public bool hasOpenCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // disable end run button
            endRunButton.GetComponent<Button>().enabled = false;
            endRunButton.GetComponent<Image>().enabled = false;
            endRunButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = false;

            // disable end run prompt button and text
            endRunPromptButton.GetComponent<Button>().enabled = false;
            endRunPromptButton.GetComponent<Image>().enabled = false;
            endRunPromptButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = false;
            endRunPromptText.enabled = false;

            // enable exit game button
            exitGameButton.GetComponent<Button>().enabled = true;
            exitGameButton.GetComponent<Image>().enabled = true;
            exitGameButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = true;

            // enable end run prompt button and text
            exitGamePromptButton.GetComponent<Button>().enabled = true;
            exitGamePromptButton.GetComponent<Image>().enabled = true;
            exitGamePromptButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = true;
            exitGamePromptText.enabled = true;
        }
        else
        {
            // disable exit game button
            exitGameButton.GetComponent<Button>().enabled = false;
            exitGameButton.GetComponent<Image>().enabled = false;
            exitGameButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = false;
            // disable end run prompt button and text
            exitGamePromptButton.GetComponent<Button>().enabled = false;
            exitGamePromptButton.GetComponent<Image>().enabled = false;
            exitGamePromptButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = false;
            exitGamePromptText.enabled = false;

            // enable exit run button
            endRunButton.GetComponent<Button>().enabled = true;
            endRunButton.GetComponent<Image>().enabled = true;
            endRunButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = true;
            // enable end run prompt button and text
            endRunPromptButton.GetComponent<Button>().enabled = true;
            endRunPromptButton.GetComponent<Image>().enabled = true;
            endRunPromptButton.GetComponentsInChildren<TextMeshProUGUI>().First().enabled = true;
            endRunPromptText.enabled = true;
        }

        volumeSlider.value = playerStatsManager.volume;
        monsterSpawnerManager = GameObject.FindObjectOfType<MonsterSpawnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !hasOpenCanvas)
        {
            ToggleEscMenu();
        }
    }

    public void ToggleEscMenu()
    {
        popAudioSource.Play();
        escMenuCanvas.enabled = !escMenuCanvas.enabled;
        endExitCanvas.enabled = false;
    }

    public void ToggleEndExit()
    {
        popAudioSource.Play();
        // disable canvas
        escMenuCanvas.enabled = !escMenuCanvas.enabled;

        // enable canvas
        endExitCanvas.enabled = !endExitCanvas.enabled;
    }

    public void EndRun()
    {
        popAudioSource.Play();
        PlayerPrefs.SetInt(stringManager.currency, PlayerPrefs.GetInt(stringManager.currency) + playerStatsManager.loot);
        PlayerPrefs.SetInt(stringManager.lifetimeKills, PlayerPrefs.GetInt(stringManager.lifetimeKills) + playerStatsManager.kills);
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex - 1);

        if(PlayerPrefs.GetInt(stringManager.longestRun) < Mathf.Floor(monsterSpawnerManager.timer))
        {
            PlayerPrefs.SetInt(stringManager.longestRun, (int)Mathf.Floor(monsterSpawnerManager.timer));
        }
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
