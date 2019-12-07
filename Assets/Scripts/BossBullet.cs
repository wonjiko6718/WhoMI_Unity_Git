using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float BossAttackSpeed = 10.0f;

    private GameObject target;
    private Rigidbody2D BBrigidbody;
    // Start is called before the first frame update
    void Start()
    {
        BBrigidbody = GetComponent<Rigidbody2D>();

        target = GameObject.Find("Player");
        BBrigidbody.velocity = ((target.transform.position - transform.position).normalized * BossAttackSpeed);
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
