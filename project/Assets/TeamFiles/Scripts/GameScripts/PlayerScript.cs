using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float attackSpeedTimer = 0f;

    [SerializeField]
    private StringManager stringManager;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    [SerializeField]
    private GameObject playercanvas;

    [SerializeField]
    private GameObject endRunCanvas;

    [SerializeField]
    private GameObject ProjectilePrefab;

    [SerializeField]
    private GameObject monsterList;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text killsText;

    [SerializeField]
    private Text endKillsText;
    
    [SerializeField]
    private CameraShakeScript cameraShake;

    [SerializeField]
    private GameObject projectileList;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStatsManager.reset();
        playerStatsManager.health += PlayerPrefs.GetInt(stringManager.upgradeThree);
        healthText.text = playerStatsManager.health.ToString();

        playerStatsManager.attackSpeed *= 1f / (float)PlayerPrefs.GetInt(stringManager.upgradeTwo);
    }

    // Update is called once per frame
    void Update()
    {
        if(attackSpeedTimer >= playerStatsManager.attackSpeed && monsterList.transform.childCount > 0 && playerStatsManager.health > 0)
        {
            Instantiate(ProjectilePrefab, transform.position, Quaternion.identity, projectileList.transform);
            attackSpeedTimer = 0f;
        }
        attackSpeedTimer += Time.deltaTime;
    }

    public void HitByMonster()
    {
        playerStatsManager.health--;
        healthText.text = playerStatsManager.health.ToString();
        gameObject.GetComponent<AudioSource>().Play();
        playercanvas.GetComponent<Animator>().Play(stringManager.healthFadeInSound);
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        if (playerStatsManager.health <= 0)
        {
            endKillsText.text = playerStatsManager.kills.ToString();
            playercanvas.GetComponent<Canvas>().enabled = false;
            endRunCanvas.GetComponent<Canvas>().enabled = true;
            endRunCanvas.GetComponent<AudioSource>().Play();
        }
    }

    public void Kill()
    {
        playerStatsManager.kills++;
        killsText.text = playerStatsManager.kills.ToString();
    }
}
