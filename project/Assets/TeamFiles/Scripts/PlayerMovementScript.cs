using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    UnityEngine.AI.NavMeshAgent agent;

    public GameObject movementIndicator;
    // public MoveIndicatorScript moveIndicatorScript;

    private NavMeshAgent navMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = moveSpeed;
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlayer()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 1f;
        agent.SetDestination(targetPosition); // TODO: this should be done as - we need to click on the mesh before we move player
        movementIndicator.GetComponent<MoveIndicatorScript>().SpawnMoveIndicator(agent.destination);
    }
}
