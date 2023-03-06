using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour

    
{
    public static BackgroundBehaviour backgroundBH;
    [SerializeField] Vector2 BGVelocity;
    private Vector2 offset;
    private Material material;
    private Vector2 _acelerate= new Vector2(1,1);
    
    void Awake()
    {
        backgroundBH = this;
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = BGVelocity * Time.deltaTime;
        material.mainTextureOffset += offset*_acelerate;
     }    

     public void Acelerate(float xA, float yA)
     {
        _acelerate.x = xA;
        _acelerate.y = yA;
     }
}
