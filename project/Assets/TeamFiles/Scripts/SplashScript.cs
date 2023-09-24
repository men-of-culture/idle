using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    [SerializeField]
    private StringManager stringManager;
    
    [SerializeField]
    private PlayerStatsManager playerStatsManager;
    
    void Start()
    {
        var volume = PlayerPrefs.GetFloat(stringManager.volume);
        AudioListener.volume = volume;
        playerStatsManager.volume = volume;
    }
    
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
    }
}
