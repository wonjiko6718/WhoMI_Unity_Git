using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float attackSpeed = 10.0f;

    private GameObject playerTrans;
    private Rigidbody2D bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();

        playerTrans = GameObject.Find("Player"); // find player, and use it to direction of fire
        bulletRigidbody.velocity = new Vector2(-(playerTrans.transform.position.x - transform.position.x)* attackSpeed,0);
        Destroy(gameObject,3.0f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
