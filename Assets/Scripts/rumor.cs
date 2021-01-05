using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rumor : MonoBehaviour
{
    private Transform rumorTrans;
    private Rigidbody2D rumorRigid2D;
    private BoxCollider2D rumorCol2D;

    private float rumorMoveSpeed = 50.0f;
    private bool canJump = true;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rumorTrans = GetComponent<Transform>();
        rumorRigid2D = GetComponent<Rigidbody2D>();
        rumorCol2D = GetComponent<BoxCollider2D>();

        rumorTrans.localScale = new Vector3(0.4f,0.4f,0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        RumorMove();
    }
    void RumorMove()
    {
        if(canJump == true)
        {
            StartCoroutine(RumorJumpDelay());
        }
        if(canMove == true)
        {
            StartCoroutine(RumorMoveDelay());
        }
    }
    IEnumerator RumorJumpDelay()
    {
        canJump = false;
        rumorRigid2D.AddForce(new Vector2(0.0f,300.0f));
        yield return new WaitForSeconds(1.5f); // RumorJumpDelay
        canJump = true;
        
    }
    IEnumerator RumorMoveDelay()
    {
        canMove = false;
        int rumorMoveDirection = Random.Range(-1,2); // -1,0,1 <- rumor move Direction
        if(rumorMoveDirection == -1)
        {
            rumorTrans.localScale = new Vector3(0.4f,0.4f,0.4f);
        }
        else if (rumorMoveDirection == 1)
        {
            rumorTrans.localScale = new Vector3(-0.4f,0.4f,0.4f);
        }
        rumorRigid2D.AddForce(new Vector2(rumorMoveDirection * rumorMoveSpeed,0.0f)); // move
        yield return new WaitForSeconds(1.5f);
        canMove = true;
    }
}
