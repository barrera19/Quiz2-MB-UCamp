using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public static PlatformBehaviour platformBH;
    [SerializeField] Rigidbody2D rb2D;
    private BoxCollider2D platformColider;
    private GameObject platformGO;


    void Awake() {
        platformBH = this;
    }
    public void Start()
    {
        
        platformColider = GetComponent<BoxCollider2D>();
        platformGO = GameObject.FindWithTag("Platform");
        
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D (Collision2D limit)
    {
        print("Plataforma en el Final");
        if(limit.collider.tag == ("LimitDestroy")) {
            SceneBehaviour.sceneBehaviour.platformCounter++;
            Destroy(this);
            
        }
    }
}
