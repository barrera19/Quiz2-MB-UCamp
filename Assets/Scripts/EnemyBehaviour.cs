using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   public UIManager.SceneItem itemBehaviour;
   public static EnemyBehaviour enemyBH;

   void Awake(){
    enemyBH = this;
   }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
