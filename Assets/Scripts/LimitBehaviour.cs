using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBehaviour : MonoBehaviour
{
    public int ItemCounter;
    [SerializeField] BoxCollider2D colliderLimits;

    void Awake()
    {
        colliderLimits = gameObject.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        ItemCounter = 0;
  
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        print(collision.collider.tag);
        if(collision.collider.CompareTag("Platform"))
        {
            Destroy(collision.collider.gameObject);
            ItemCounter++;
            print("Entro al Colider");
        }
    }
}
