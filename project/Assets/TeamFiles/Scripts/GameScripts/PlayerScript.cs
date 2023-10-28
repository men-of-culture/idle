using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum Weapon
{
    Sword,
    Bomb,
    Arrow
}

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
    private GameObject swordPrefab;

    [SerializeField]
    private GameObject bombPrefab;

    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private GameObject monsterList;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text armorText;

    [SerializeField]
    private Text killsText;

    [SerializeField]
    private Text endKillsText;
    
    [SerializeField]
    private CameraShakeScript cameraShake;

    [SerializeField]
    private GameObject projectileList;

    [SerializeField]
    private Text attspdText;

    [SerializeField]
    private float attackRange;

    public Weapon weapon;
    public int damage;

    public float armorRegenTimer = 10f;

    public AudioSource attackAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStatsManager.reset();
        playerStatsManager.health += PlayerPrefs.GetInt(stringManager.upgradeThree);
        healthText.text = playerStatsManager.health.ToString();

        playerStatsManager.damage += PlayerPrefs.GetInt(stringManager.upgradeOne);
        damage = playerStatsManager.damage;

        playerStatsManager.attackSpeed *= 1f / ((float)PlayerPrefs.GetInt(stringManager.upgradeOne, 1)+1);
        attspdText.text = (1f/playerStatsManager.attackSpeed).ToString("F1")+"/s";

        playerStatsManager.armor += PlayerPrefs.GetInt(stringManager.upgradeFour);
        armorText.text = playerStatsManager.armor.ToString();

        if(playerStatsManager.blessing == "sword") weapon = Weapon.Sword;
        if(playerStatsManager.blessing == "arrow") weapon = Weapon.Arrow;
        if(playerStatsManager.blessing == "bomb") weapon = Weapon.Bomb;
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon == Weapon.Sword) attackRange = 4;
        if(weapon == Weapon.Bomb) attackRange = 12;
        if(weapon == Weapon.Arrow) attackRange = 20;

        var dirToNearestMonster = DrawAttackRangeCircle();
        var dirToSecondNearestMonster = SecondNearestMonster();

        if(attackSpeedTimer >= playerStatsManager.attackSpeed && monsterList.transform.childCount > 0 && playerStatsManager.health > 0 && dirToNearestMonster.magnitude < attackRange)
        {
            if(weapon == Weapon.Bomb)
            {
                var x = Instantiate(bombPrefab, new Vector3(transform.position.x-0.5f, transform.position.y, 0), Quaternion.identity, projectileList.transform);
                x.GetComponent<ProjectileScript>().nearestMonster = dirToNearestMonster;
                
                SecondTargetPerk(dirToSecondNearestMonster);
            }
            if(weapon == Weapon.Arrow)
            {
                var x = Instantiate(arrowPrefab, new Vector3(transform.position.x-0.5f, transform.position.y, 0), Quaternion.identity, projectileList.transform);
                x.GetComponent<ArrowScript>().nearestMonster = dirToNearestMonster;

                SecondTargetPerk(dirToSecondNearestMonster);
            }
            if(weapon == Weapon.Sword)
            {
                var x = Instantiate(swordPrefab, new Vector3(transform.position.x-0.5f, transform.position.y, 0), Quaternion.identity, projectileList.transform);
                x.GetComponent<SwordScript>().nearestMonster = dirToNearestMonster;
                x.transform.parent = transform;

                SecondTargetPerk(dirToSecondNearestMonster);
                
                attackAudioSource = projectileList.transform.GetComponent<AudioSource>();
                attackAudioSource.Play();
            }

            attackSpeedTimer = 0f;
        }
        attackSpeedTimer += Time.deltaTime;

        ArmorRegen();
    }

    void SecondTargetPerk(Vector2 dirToSecondNearestMonster)
    {
        if(playerStatsManager.perk3 != 1) return;
        if(dirToSecondNearestMonster.magnitude < attackRange)
        {
            if(weapon == Weapon.Sword)
            {
                var x = Instantiate(swordPrefab, new Vector3(transform.position.x-0.5f, transform.position.y, 0), Quaternion.identity, projectileList.transform);
                x.GetComponent<SwordScript>().nearestMonster = dirToSecondNearestMonster;
                x.transform.parent = transform;
            }
            if(weapon == Weapon.Arrow)
            {
                var x = Instantiate(arrowPrefab, new Vector3(transform.position.x-0.5f, transform.position.y, 0), Quaternion.identity, projectileList.transform);
                x.GetComponent<ArrowScript>().nearestMonster = dirToSecondNearestMonster;
            }
            if(weapon == Weapon.Bomb)
            {
                var x = Instantiate(bombPrefab, new Vector3(transform.position.x-0.5f, transform.position.y, 0), Quaternion.identity, projectileList.transform);
                x.GetComponent<ProjectileScript>().nearestMonster = dirToSecondNearestMonster;
            }
        }
    }

    void ArmorRegen()
    {
        armorRegenTimer -= Time.deltaTime;
        if(playerStatsManager.armor < PlayerPrefs.GetInt(stringManager.upgradeFour) && armorRegenTimer <= 0)
        {
            var regenAmount = 1+(int)Mathf.Floor((float)PlayerPrefs.GetInt(stringManager.upgradeFour)/2*0.1f);
            var maxArmor = PlayerPrefs.GetInt(stringManager.upgradeFour);

            if((playerStatsManager.armor + regenAmount) > maxArmor)
            {
                playerStatsManager.armor += (maxArmor - playerStatsManager.armor);
            }
            else
            {
                playerStatsManager.armor += regenAmount;
            }

            armorRegenTimer = 10f;
            armorText.text = playerStatsManager.armor.ToString();
        }
    }

    Vector2 DrawAttackRangeCircle()
    {
        var dirToNearestMonster = NearestMonster();
        var vec2 = dirToNearestMonster.normalized*attackRange;
        var circleColor = Color.yellow;
        var spritePos = new Vector3(transform.position.x-0.5f, transform.position.y, 0);

        if(monsterList.transform.childCount == 0)
        {

        }
        else if(dirToNearestMonster.magnitude > attackRange)
        {
            Debug.DrawLine(spritePos, spritePos+new Vector3(vec2.x, vec2.y, 0), circleColor);
        }
        else
        {
            circleColor = Color.red;
            Debug.DrawLine(spritePos, spritePos+new Vector3(dirToNearestMonster.x, dirToNearestMonster.y, 0), circleColor);
        }

        Debug.DrawCircle(spritePos, attackRange, 32, circleColor);

        return dirToNearestMonster;
    }


    private Vector2 NearestMonster()
    {
        // TODO: Look at it when it's not 2AM in the morning
        var nearestMonster = new Vector2(100f, 100f);
        monsterList = GameObject.Find(stringManager.monsterList);
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in monsterList.transform)
        {
            if(potentialTarget.GetComponent<MonsterScript>().startFadeOut == false)
            {
                Vector2 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    nearestMonster = directionToTarget;
                }
            }
        }
        return nearestMonster;
    }

    private Vector2 SecondNearestMonster()
    {
        // TODO: Look at it when it's not 2AM in the morning
        var nearestMonster = new Vector2(100f, 100f);
        var secondNearestMonster = new Vector2(100f, 100f);
        monsterList = GameObject.Find(stringManager.monsterList);
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in monsterList.transform)
        {
            if(potentialTarget.GetComponent<MonsterScript>().startFadeOut == false)
            {
                Vector2 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    secondNearestMonster = nearestMonster;
                    nearestMonster = directionToTarget;
                }
            }
        }
        return secondNearestMonster;
    }

    public void HitByMonster(int monsterDamage)
    {
        if(playerStatsManager.armor == 0)
        {
            playerStatsManager.health -= monsterDamage;
            gameObject.GetComponent<AudioSource>().Play();
            playercanvas.GetComponent<Animator>().Play(stringManager.healthFadeInSound);
        }
        else if(playerStatsManager.armor - monsterDamage < 0)
        {
            playerStatsManager.health -= (monsterDamage - playerStatsManager.armor);
            playerStatsManager.armor = 0;
            gameObject.GetComponent<AudioSource>().Play();
            playercanvas.GetComponent<Animator>().Play(stringManager.healthFadeInSound);
        }
        else
        {
            playerStatsManager.armor -= monsterDamage;
        }

        healthText.text = playerStatsManager.health.ToString();
        armorText.text = playerStatsManager.armor.ToString();
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        if (playerStatsManager.health <= 0)
        {
            endKillsText.text = playerStatsManager.kills.ToString();
            playercanvas.GetComponent<Canvas>().enabled = false;
            endRunCanvas.GetComponent<Canvas>().enabled = true;
            endRunCanvas.GetComponent<AudioSource>().Play();
        }
    }

    public void Loot(int loot)
    {
        playerStatsManager.loot += loot;
        killsText.text = playerStatsManager.loot.ToString();
    }
}
