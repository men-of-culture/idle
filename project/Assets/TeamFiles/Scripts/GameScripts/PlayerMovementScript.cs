using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PlayerMovementScript : MonoBehaviour
{
    public Vector2 targetPosition;
    public bool startWalking;
    public bool shouldWalk;
    public float walkTimer;
    public Vector2 initialPosition;
    public float walkSpeed;
    public float pauseTimer;
    public float pauseDuration;
    public bool shouldPause;
    public int moveRange;
    public int minimumPauseDuration;
    public int maximumPauseDuration;
    public int minimumWalkDuration;
    public int maximumWalkDuration;
    public PlayerStatsManager playerStatsManager;
    public Animator animator;

    public Transform lootList;
    
    // Start is called before the first frame update
    void Start()
    {
        startWalking = true;
        animator = GetComponent<Animator>();
        lootList = GameObject.Find("LootList").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (startWalking)
        {
            targetPosition = lootList.childCount == 0 ? new Vector2(0, 0) : lootList.GetChild(0).position;
            startWalking = false;
            shouldWalk = true;
            initialPosition = gameObject.transform.position;
            animator.enabled = true;
        }
        
        if (shouldWalk && playerStatsManager.health > 0)
        {
            walkTimer += Time.deltaTime*(walkSpeed/10);
            gameObject.transform.position = initialPosition+((targetPosition-initialPosition)*(walkTimer/(targetPosition-initialPosition).magnitude));
            if (walkTimer >= (targetPosition - initialPosition).magnitude)
            {
                shouldWalk = false;
                shouldPause = true;
                pauseDuration = Random.Range(minimumPauseDuration, maximumPauseDuration);
                walkTimer = 0;
                animator.enabled = false;
            }
        }

        if (shouldPause)
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseDuration)
            {
                shouldPause = false;
                startWalking = true;
                pauseTimer = 0;
            }
        }
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        Debug.Log("Vi collider med monster");
        // if (other.gameObject.tag == "Monster")
        // {
        //     Debug.Log("Vi collider med monster");
        //     Destroy(other.gameObject);
        // }
    }

    void OnCollisionEnter2d(Collision collision) {
        Debug.Log ("xxx " + collision.collider.name);
    }

    public void MovePlayer()
    {
        
    }
}
