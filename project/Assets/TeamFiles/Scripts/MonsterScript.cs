using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    public float moveInterval;
    private float moveTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        moveInterval = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= 0)
        {
            MonsterMove();
            moveTimer = moveInterval;
        }

        moveTimer -= Time.deltaTime;
    }

    void MonsterMove()
    {
        agent.SetDestination(transform.position + new Vector3(Random.Range(-4f, 4f), 0, 0));
    }
}
