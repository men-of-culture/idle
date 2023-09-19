using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject changeScenePrefab;

    public void BackToMenuButton()
    {
        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") + GameObject.Find("Player").GetComponent<PlayerScript>().kills);
        PlayerPrefs.SetInt("lifetimeKills", PlayerPrefs.GetInt("lifetimeKills") + GameObject.Find("Player").GetComponent<PlayerScript>().kills);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        changeScenePrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
