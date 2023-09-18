using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private int damage; // gonne be used later

    private GameObject monsterList;

    private Vector3 nearestMonster;

    private float lifeTime = 0f;

    public GameObject playercanvas;

    public

    // Start is called before the first frame update
    void Start()
    {
        monsterList = GameObject.Find("MonsterList");
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in monsterList.transform)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                nearestMonster = directionToTarget;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += nearestMonster.normalized * Time.deltaTime * speed;
        transform.localEulerAngles += new Vector3(0, 0, Time.deltaTime * speed * 20);
        lifeTime += Time.deltaTime;

        if(lifeTime >= 5)
        {
            Destroy(gameObject);
        }
    }
}
