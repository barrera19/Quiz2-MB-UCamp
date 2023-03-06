using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBehaviour : MonoBehaviour
{
    public int ItemCounter;
    [SerializeField] Collider2D colliderLimits;

    void Start()
    {
        ItemCounter = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collider)
    {
        if(collider.gameObject.tag==("Platform"))
        {
            ItemCounter++;
        }
    }
}
