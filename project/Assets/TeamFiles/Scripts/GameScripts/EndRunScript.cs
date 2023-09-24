using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunScript : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private GameObject changeScenePrefab;

    [SerializeField]
    private StringManager stringManager;

    public void BackToMenuButton()
    {
        PlayerPrefs.SetInt(stringManager.currency, PlayerPrefs.GetInt(stringManager.currency) + playerStatsManager.kills);
        PlayerPrefs.SetInt(stringManager.lifetimeKills, PlayerPrefs.GetInt(stringManager.lifetimeKills) + playerStatsManager.kills);
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
