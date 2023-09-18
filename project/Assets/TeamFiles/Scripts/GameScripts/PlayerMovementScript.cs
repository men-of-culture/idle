using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
