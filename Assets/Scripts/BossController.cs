﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float bossHP = 100.0f;
    private bool canAttack = true;

    public GameObject bossAttack;
    public GameObject target;

    private Transform bossTransform;
    private Rigidbody2D bossRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bossTransform = GetComponent<Transform>();
        bossRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        Attack();
        OnDamage();
        Move();
    }
    void Attack()
    {
        if(canAttack == true)
        {
            StartCoroutine(bossAttackDelay());
        }
    }
    void OnDamage()
    {
        
    }
    void Move()
    {

    }
    IEnumerator bossAttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f); // boss attack delay
        GameObject bossOnAttack = Instantiate(bossAttack,transform.position,Quaternion.identity); // spawn boss attack after 2 seconds
        canAttack = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "PlayerAttack")
        {
            bossHP -= 1;
            Debug.Log("Boss HP:" + bossHP);
        }
    }
}