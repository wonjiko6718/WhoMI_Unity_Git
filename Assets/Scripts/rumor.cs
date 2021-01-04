using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rumor : MonoBehaviour
{
    private Transform rumorTrans;
    private Rigidbody2D rumorRigid2D;
    private BoxCollider2D rumorCol2D;
    private bool canJump = true;


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
    }
    IEnumerator RumorJumpDelay()
    {
        canJump = false;
        rumorRigid2D.AddForce(new Vector2(0.0f,300.0f));
        yield return new WaitForSeconds(1.5f); // RumorJumpDela
        canJump = true;
        
    }
}
