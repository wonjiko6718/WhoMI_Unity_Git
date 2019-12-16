using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float Hp = 100.0f;
    private float playerSpeed = 7.0f;
    private float jumpSpeed= 7.0f;
    private bool playerHit = false;

    public GameObject bulletPrefab;
    private Vector3 playerDir;
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
        Attack();
        if(Hp <= 0 )
        {
            playerDie();
        }
        
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
            playerDir = new Vector3(1.5f,0,0);
        }
        if(Input.GetAxisRaw("Horizontal") < 0) // PlayerMove Left
        {
            playerTransform.localScale = new Vector3(-1,1,1);
            moveVelocity = Vector2.left;
            playerDir = new Vector3(-1.5f,0,0);
        }
        playerTransform.position += moveVelocity * playerSpeed * Time.deltaTime;
    }
    void Jump() // Collider Vector + method fix please
    {
        Vector2 jumpVelocity = new Vector2(0,jumpSpeed);

        if((Input.GetButton("Jump")) && playerRigidbody.velocity.y == 0)
        {
            playerRigidbody.AddForce(jumpVelocity,ForceMode2D.Impulse);
        }
    }
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            GameObject bullet = Instantiate(bulletPrefab,transform.position + playerDir, Quaternion.identity);
        }
    }
    void playerDie()
    {
        Destroy(gameObject);
    }
    // collider Trigger method
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "BossAttack")
        {
            Debug.Log("Hit!");
            Hp -= 5;
            Debug.Log(Hp);
            playerRigidbody.velocity = -new Vector2(playerDir.x,playerDir.y).normalized * 2.0f;
        }
    }
}
