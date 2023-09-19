using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveIndicatorScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f) Destroy(gameObject);
    }

    public void SpawnMoveIndicator(Vector3 targetPosition)
    {
        GameObject moveIndicator = GameObject.Find("MoveIndicator(Clone)");
        if (moveIndicator is not null) Destroy(moveIndicator);
        Instantiate(gameObject, targetPosition, Quaternion.identity);
    }

    public void SpawnAttackIndicator(Vector3 targetPosition)
    {
        Debug.Log("spawn attack indicator");
    }
}
