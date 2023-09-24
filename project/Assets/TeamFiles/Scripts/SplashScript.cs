using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneChangerPrefab;
    
    public void ChangeScene()
    {
        sceneChangerPrefab.GetComponent<SceneChangerScript>().FadeToScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
