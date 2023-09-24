using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
