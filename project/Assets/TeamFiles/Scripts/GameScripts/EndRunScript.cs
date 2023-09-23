using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject changeScenePrefab;

    [SerializeField]
    private PlayerScript playerScript;

    [SerializeField]
    private StringManager stringManager;

    public void BackToMenuButton()
    {
        PlayerPrefs.SetInt(stringManager.currency, PlayerPrefs.GetInt(stringManager.currency) + playerScript.kills);
        PlayerPrefs.SetInt(stringManager.lifetimeKills, PlayerPrefs.GetInt(stringManager.lifetimeKills) + playerScript.kills);
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
