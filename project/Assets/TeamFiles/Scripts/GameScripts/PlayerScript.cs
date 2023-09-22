using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int kills;

    public int health;

    public float attackSpeed;
    private float attackSpeedTimer = 0f;

    private GameObject monsterList;

    private Text killsText;
    private Text healthText;
    private Text endKillsText;
    public GameObject playercanvas;
    public GameObject endRunCanvas;

    [SerializeField]
    private GameObject ProjectilePrefab;

    [SerializeField]
    private CameraShakeScript cameraShake;
    
    // Start is called before the first frame update
    void Start()
    {
        health += PlayerPrefs.GetInt("upgradeThree");
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        healthText.text = health.ToString();

        attackSpeed *= 1f / (float)PlayerPrefs.GetInt("upgradeTwo");
        Debug.Log(PlayerPrefs.GetInt("upgradeTwo"));

        killsText = GameObject.Find("KillsText").GetComponent<Text>();
        endKillsText = GameObject.Find("EndKillsText").GetComponent<Text>();
        playercanvas = GameObject.Find("PlayerCanvas");
        endRunCanvas = GameObject.Find("EndRunCanvas");

        monsterList = GameObject.Find("MonsterList");
    }

    // Update is called once per frame
    void Update()
    {
        if(attackSpeedTimer >= attackSpeed && monsterList.transform.childCount > 0 && health > 0)
        {
            Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            attackSpeedTimer = 0f;
        }
        attackSpeedTimer += Time.deltaTime;
    }

    public void HitByMonster()
    {
        health--;
        healthText.text = health.ToString();
        gameObject.GetComponent<AudioSource>().Play();
        playercanvas.GetComponent<Animator>().Play("healthFadeIn");
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        if (health <= 0)
        {
            endKillsText.text = kills.ToString();
            playercanvas.GetComponent<Canvas>().enabled = false;
            endRunCanvas.GetComponent<Canvas>().enabled = true;
            endRunCanvas.GetComponent<AudioSource>().Play();
        }
    }

    public void Kill()
    {
        kills++;
        killsText.text = kills.ToString();
    }
}
