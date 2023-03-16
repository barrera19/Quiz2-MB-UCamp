using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour playerBH;
    ObstacleBehaviour obstacleBH;
    CollectablesBehaviour collectablesBH;
    EnemyBehaviour enemyBH;
    GameManager manager;
    public int playerLives;
    public int playerPoints;
    public CircleCollider2D colliderPlayer;
    public Rigidbody2D rb;
    public GameObject playerGO;
    private Animator animator;

    [Header("Jump Control")]
    [SerializeField] float  jumpForce;
    public bool canJump;
    public bool onGround;
    [SerializeField] Transform groundControl; 
    [SerializeField] LayerMask isGround;
    [SerializeField] Vector2 groundBox;
    [Range(0,1)] [SerializeField] float jumpCancelMult;
    [SerializeField] float gravityMultiplier;
    private float newScale;
    private bool jumpUpButton= true;
    int pointsForLives = 0;

    void Awake() {
        playerBH = this;
    }

    void Start()
    {
        colliderPlayer = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        playerGO = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        newScale = rb.gravityScale;
        playerLives = 3;
        playerPoints = 0;
        pointsForLives = 0;
 
        manager = GameManager.manager;   
        collectablesBH = CollectablesBehaviour.collectablesBH;
        obstacleBH = ObstacleBehaviour.obstacleBH;
        enemyBH = EnemyBehaviour.enemyBH;

 
    }

    void Update()
    {
        if(Input.GetKey("space") || Input.GetMouseButton(0)) {   
            canJump = true;
        }
        if(Input.GetKeyUp("space") || Input.GetMouseButtonUp(0)) {
            JumpButtonUp();
        }
        onGround = Physics2D.OverlapBox(groundControl.position, groundBox, 0, isGround);
        animator.SetBool("onGround", onGround);
    }

    void FixedUpdate()
    {
        if (canJump && onGround && jumpUpButton)
        {
            Jump();
            animator.SetBool("onGround", !onGround);
        }
        if(rb.velocity.y <0 && !onGround)
        {
            rb.gravityScale = newScale * gravityMultiplier;
        }
        else {
            rb.gravityScale = newScale;
        }
        
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        onGround = false;
        canJump = false;
        jumpUpButton = false;
    }

    void JumpButtonUp(){
        if(rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1- jumpCancelMult), ForceMode2D.Impulse);
        }
        jumpUpButton = true;
        canJump = false;
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground")) {
            onGround = true;
        }
        if(collision.collider.CompareTag("Enemy")) {  
            playerGO.SetActive(false);
            // GameOVER
            manager.GameOver();
            print("choque con enemigo ");
        }
        if(collision.collider.CompareTag("Obstacle"))
        {
            UIManager.uiManager.audioObstacle.Play();
            PlayerHurt();
            Destroy(collision.collider.gameObject);
        }
    }

       void OnTriggerEnter2D(Collider2D collectable)
        {
            if(collectable.tag == ("Collectables"))
            {
                PlayerWonPoints();
                UIManager.uiManager.audioCollectable.Play();
                Destroy(collectable.gameObject);
            }
            if(collectable.tag == ("PlayerLife"))
            {
                PlayerWonLife();
                UIManager.uiManager.audioExtraLife.Play();
                Destroy(collectable.gameObject);
            }
            
        }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundControl.position, groundBox);
    }

    void PlayerHurt() 
    {
        playerLives--;
        animator.SetInteger("PlayerLives", playerLives);
        if(playerPoints>=50)
        playerPoints -= 50;
        else playerPoints = 0;
         
        if(playerLives <= 0) manager.GameOver();
      
    }

    void PlayerWonPoints()
    {
        playerPoints += 10;
        pointsForLives += 10;
        if(pointsForLives == 150)
        {
            playerLives++;
            pointsForLives = 0;
            animator.SetInteger("PlayerLives", playerLives);    
        }
    }

    void PlayerWonLife()
    {
        playerLives++;
        animator.SetInteger("PlayerLives", playerLives);
    }
}
