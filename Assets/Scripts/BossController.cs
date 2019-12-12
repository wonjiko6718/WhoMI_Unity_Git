using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float bossHP = 100.0f;
    private float bossSpeed = 50.0f;
    private bool canAttack = true;
    private bool firstPattern = true;

    public GameObject bossAttack;
    public GameObject target;
    private Rigidbody2D bossRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bossRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        Attack();
        Move();
        if(bossHP <= 0 )
        {
            BossDie();
        }
    }
    void Attack()
    {
        if(canAttack == true && target != null)
        {
            StartCoroutine(bossAttackDelay());
        }
    }
    void Move()
    {
        if(bossRigidbody.velocity.y == 0)
        {
            int randomMove = Random.Range(-1,2); // -1,0,1 -> move Direction
            int randomJump = Random.Range(0,100); // 1% Possibility to Jump
            Vector2 BossRandomMove = new Vector2(randomMove,0);
            Vector2 BossRandomJump = new Vector2(0 , 10.0f);
            bossRigidbody.AddForce(BossRandomMove.normalized * bossSpeed);
            if(randomJump == 1 && bossRigidbody.velocity.y == 0)
            {
                bossRigidbody.AddForce(BossRandomJump * bossSpeed);
            }
        }
        if(bossHP == 50 && firstPattern == true)
        {
            transform.position = target.transform.position + new Vector3(0,2,0);
            firstPattern = false;
        }
    }
    void BossDie()
    {
        Destroy(gameObject);
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
