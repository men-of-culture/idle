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

    public SpriteRenderer fadeIn;
    public float fadeTimer = 1f;

    private bool fade;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        moveInterval = Random.Range(1f, 5f);
        fadeIn = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTimer <= 0 && !fade)
        {
            fadeIn.color += new Color(0f,0f,0f,1f);
            fade = true;
        } 
        else if (fadeTimer > 0)
        {
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, 1f - fadeTimer);
            fadeTimer -= Time.deltaTime;
        }
        
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
