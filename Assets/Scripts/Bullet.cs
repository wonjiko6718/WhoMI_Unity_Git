using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float attackSpeed = 10.0f;

    private Collider attackCol;
    private Transform attackTrans;
    private Rigidbody2D bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        attackTrans = GetComponent<Transform>();
        attackCol = GetComponent<Collider>();
        bulletRigidbody = GetComponent<Rigidbody2D>();


        Destroy(gameObject,3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
