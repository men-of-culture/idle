using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private int damage; // gonne be used later

    [SerializeField]
    private int rotationSpeed;

    [SerializeField]
    private int lifeTime;
    
    private GameObject monsterList;

    private Vector3 nearestMonster;

    private float lifeTimeTimer = 0f;

    private AudioSource attackAudioSource;

    [SerializeField]
    private StringManager stringManager;

    public GameObject explosionPrefab;
    public Vector3 monsterHitPosition;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Look at it when it's not 2AM in the morning
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

        attackAudioSource = transform.parent.GetComponent<AudioSource>();
        attackAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += nearestMonster.normalized * Time.deltaTime * speed;
        transform.localEulerAngles += new Vector3(0, 0, Time.deltaTime * speed * rotationSpeed);
        lifeTimeTimer += Time.deltaTime;

        if(lifeTimeTimer >= lifeTime)
        {
            Debug.Log("This Projectile trigger was hit by: Monster");
            var x = Instantiate(explosionPrefab, transform.parent);
            x.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(stringManager.monsterTag))
        {
            Debug.Log("This Projectile trigger was hit by: Monster");
            var x = Instantiate(explosionPrefab, transform.parent);
            x.transform.position = transform.position + ((other.transform.position-transform.position)/2);
            Destroy(gameObject);
        }
    }
}
