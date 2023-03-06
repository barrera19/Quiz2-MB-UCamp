using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public static ObstacleBehaviour obstacleBH;
    public UIManager.SceneItem itemBehaviour;
    
    public BoxCollider2D obstacleCollider;
    public Rigidbody2D playerRB;
    public GameObject resetP;

    public GameObject player;


    void Awake(){
        obstacleBH = this;
    }

    void Start()
    {
        obstacleCollider = GetComponent<BoxCollider2D>();
        resetP = GameObject.FindWithTag("restartP"); 
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {   
       

        
    }
     void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.collider.CompareTag("Player")) 
        {
                if(PlayerBehaviour.playerBH.playerLives <=3)
                {
                Vector2 resetPosition = new Vector2(resetP.transform.position.x, resetP.transform.position.y); 
                player.transform.position =  resetPosition;
                resetP.transform.position =  new Vector2(resetP.transform.position.x -1f, resetP.transform.position.y);
                print("choque con obstaculo: X" + resetPosition.x + " Y: " + resetPosition.y + "Y Tiene: " + PlayerBehaviour.playerBH.playerLives + "Vidas");
                }
                else {
                Vector2 resetPosition = new Vector2(0, resetP.transform.position.y); 
                player.transform.position =  resetPosition;
                }


        }
    }



 
}
