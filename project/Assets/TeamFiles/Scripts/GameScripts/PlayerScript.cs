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

    [SerializeField]
    private Text attspdText;

    [SerializeField]
    private float attackRange;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStatsManager.reset();
        playerStatsManager.health += PlayerPrefs.GetInt(stringManager.upgradeThree);
        healthText.text = playerStatsManager.health.ToString();

        playerStatsManager.attackSpeed *= 1f / (float)PlayerPrefs.GetInt(stringManager.upgradeTwo, 1);
        attspdText.text = (1f/playerStatsManager.attackSpeed).ToString("F1")+"/s";
    }

    // Update is called once per frame
    void Update()
    {
        // add this as an extension of the Debug class
        var dirToNearestMonster = DrawAttackRangeCircle();

        if(attackSpeedTimer >= playerStatsManager.attackSpeed && monsterList.transform.childCount > 0 && playerStatsManager.health > 0 && dirToNearestMonster.magnitude < attackRange)
        {
            var x = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity, projectileList.transform);
            x.GetComponent<ProjectileScript>().nearestMonster = dirToNearestMonster;
            attackSpeedTimer = 0f;
        }
        attackSpeedTimer += Time.deltaTime;
    }

    // add this as an extension of the Debug class
    public static void DrawCircle(Vector3 position, float radius, int segments, Color color)
    {
        // If either radius or number of segments are less or equal to 0, skip drawing
        if (radius <= 0.0f || segments <= 0)
        {
            return;
        }
    
        // Single segment of the circle covers (360 / number of segments) degrees
        float angleStep = (360.0f / segments);
    
        // Result is multiplied by Mathf.Deg2Rad constant which transforms degrees to radians
        // which are required by Unity's Mathf class trigonometry methods
    
        angleStep *= Mathf.Deg2Rad;
    
        // lineStart and lineEnd variables are declared outside of the following for loop
        Vector3 lineStart = Vector3.zero;
        Vector3 lineEnd = Vector3.zero;
    
        for (int i = 0; i < segments; i++)
        {
            // Line start is defined as starting angle of the current segment (i)
            lineStart.x = Mathf.Cos(angleStep * i) ;
            lineStart.y = Mathf.Sin(angleStep * i);
    
            // Line end is defined by the angle of the next segment (i+1)
            lineEnd.x = Mathf.Cos(angleStep * (i + 1));
            lineEnd.y = Mathf.Sin(angleStep * (i + 1));
    
            // Results are multiplied so they match the desired radius
            lineStart *= radius;
            lineEnd *= radius;
    
            // Results are offset by the desired position/origin 
            lineStart += position;
            lineEnd += position;
    
            // Points are connected using DrawLine method and using the passed color
            Debug.DrawLine(lineStart, lineEnd, color);
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

        // draw circle
        DrawCircle(spritePos, attackRange, 32, circleColor);

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
            Vector2 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                nearestMonster = directionToTarget;
            }
        }
        return nearestMonster;
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
        playerStatsManager.loot++;
        killsText.text = playerStatsManager.loot.ToString();
    }
}
