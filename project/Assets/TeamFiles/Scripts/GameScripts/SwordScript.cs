using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    [SerializeField]
    private StringManager stringManager;

    private float timer;

    public Vector2 nearestMonster;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(nearestMonster);
        transform.GetChild(0).transform.localPosition = new Vector3(0,0,0) + new Vector3(nearestMonster.normalized.x, nearestMonster.normalized.y, 0)*3f;

        var angle = Vector2.Angle(new Vector2(0,1), nearestMonster);
        transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 65f);
        
        if(nearestMonster.x >= 0)
        {
            transform.GetChild(0).transform.localEulerAngles -= new Vector3(0,0,angle);
        }
        else
        {
            transform.GetChild(0).transform.localEulerAngles += new Vector3(0,0,angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 1f), 360f * Time.deltaTime / 1f);

        if(timer >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
