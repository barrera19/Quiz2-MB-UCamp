using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesBehaviour : MonoBehaviour
{
    public UIManager.SceneItem itemBehaviour;

    public static CollectablesBehaviour collectablesBH;

    private GameObject collectableGO;
    public BoxCollider2D collectableCollider;

    void Awake()
    {
        collectablesBH = this;
        collectableGO = GameObject.FindWithTag("Collectables");

    }
  
    void Start()
    {
        collectableCollider = GetComponent<BoxCollider2D>();
    }

}
