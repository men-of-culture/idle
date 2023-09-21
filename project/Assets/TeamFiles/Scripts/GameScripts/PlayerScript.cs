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

    [SerializeField]
    private StringManager stringManager;

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
    
    // Start is called before the first frame update
    void Start()
    {
        health += PlayerPrefs.GetInt(stringManager.upgradeThree);
        healthText.text = health.ToString();

        attackSpeed *= 1f / (float)PlayerPrefs.GetInt(stringManager.upgradeTwo);
        Debug.Log(PlayerPrefs.GetInt(stringManager.upgradeTwo));
    }

    // Update is called once per frame
    void Update()
    {
        if(attackSpeedTimer >= attackSpeed && monsterList.transform.childCount > 0)
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
