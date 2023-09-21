using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private StringManager stringManager;

    private int sceneToLoad;

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToScene (int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        animator.SetTrigger(stringManager.fadeOutTrigger);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
