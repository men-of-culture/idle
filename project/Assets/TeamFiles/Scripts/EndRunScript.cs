using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenuButton()
    {
        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") + GameObject.Find("Player").GetComponent<PlayerScript>().kills);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
