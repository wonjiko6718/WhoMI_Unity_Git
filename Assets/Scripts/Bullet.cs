using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float attackSpeed = 10.0f;

    private Collider attackCol;
    private Transform attackTrans;
    // Start is called before the first frame update
    void Start()
    {
        attackTrans = GetComponent<Transform>();
        attackCol = GetComponent<Collider>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,0) * attackSpeed , ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
