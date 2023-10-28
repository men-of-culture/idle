using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private int damage; // gonne be used later

    [SerializeField]
    private int lifeTime;

    public Vector3 nearestMonster;

    private float lifeTimeTimer = 0f;

    private AudioSource attackAudioSource;

    [SerializeField]
    private StringManager stringManager;

    // Start is called before the first frame update
    void Start()
    {
        attackAudioSource = transform.parent.GetComponent<AudioSource>();
        attackAudioSource.Play();

        var angle = Vector2.Angle(new Vector2(Vector3.up.x, Vector3.up.y), nearestMonster);
        Debug.Log(angle);
        Debug.Log(nearestMonster);
        transform.localEulerAngles = new Vector3(0, 0, 45f);
        
        if(nearestMonster.x >= 0)
        {
            transform.localEulerAngles -= new Vector3(0,0,angle);
        }
        else
        {
            transform.localEulerAngles += new Vector3(0,0,angle);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += nearestMonster.normalized * Time.deltaTime * speed;
        lifeTimeTimer += Time.deltaTime;

        if(lifeTimeTimer >= lifeTime)
        {
            Debug.Log("lifespan is up");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(stringManager.monsterTag))
        {
            Debug.Log("This Projectile trigger was hit by: Monster");
            Destroy(gameObject);
        }
    }
}
