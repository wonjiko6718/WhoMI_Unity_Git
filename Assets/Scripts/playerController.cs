using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private int Hp;
    private float playerSpeed = 5.0f;
    private bool isJumpNow = false;
    private Vector2 playerMovement;
    private Rigidbody2D playerRigidbody;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
       Move();
       Jump();
    }
    //etc Methods
    void Move()
    {
        Vector3 moveVelocity = Vector2.zero;
        if(Input.GetAxisRaw("Horizontal") > 0) // Player Move Right
        {
            playerTransform.localScale = new Vector3(1,1,1);
            moveVelocity = Vector2.right;
        }
        if(Input.GetAxisRaw("Horizontal") < 0) // PlayerMove Left
        {
            playerTransform.localScale = new Vector3(-1,1,1);
            moveVelocity = Vector2.left;
        }
        playerTransform.position += moveVelocity * playerSpeed * Time.deltaTime;
    }
    void Jump()
    {

    }
}
