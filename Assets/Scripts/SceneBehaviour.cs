using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehaviour : MonoBehaviour
{
    public static SceneBehaviour sceneBehaviour;
    public UIManager.SceneItem itemBehaviour;

    public GameManager manager;
    public PlayerBehaviour player;
    [SerializeField]  GameObject[] platformsLoad;
    [SerializeField]  GameObject[] itemsLoad;
    [SerializeField] GameObject[] platformsSpawners;
    [SerializeField] GameObject[] itemsSpawners;
    [SerializeField] GameObject Scenario;
    public int platformCounter;
    [SerializeField] int pointsCounter;
    

    void Awake()
    {
        platformCounter=0;
        sceneBehaviour = this;
    }

    public void SceneStart()
    {   
        CreateScenePlatforms();
        CreateSceneItems();
   

    }

    public void CreateScenePlatforms()
    {   InvokeRepeating("CreatePlatforms", 1f, Random.Range(1,3)); }
    public void CreateSceneItems()
    {    InvokeRepeating("CreateItems", 1f, Random.Range(0,2));  }

    public void StopScenePlatforms()
    {   CancelInvoke("CreatePlatforms");    }
    public void StopSceneItems()
    {   CancelInvoke("CreateItems");  }

    private void CreatePlatforms()
    {   
       GameObject platform = Instantiate(platformsLoad[Random.Range(0,platformsLoad.Length)], platformsSpawners[Random.Range(0,platformsSpawners.Length)].transform.position, Quaternion.identity, Scenario.transform);
       platformCounter++;
       Destroy(platform, 6f);
       Invoke("checkForItems", 8f);
    }

    private void CreateItems()
    {      
       GameObject items = Instantiate(itemsLoad[Random.Range(0,itemsLoad.Length)], itemsSpawners[Random.Range(0,itemsSpawners.Length)].transform.position, Quaternion.identity, Scenario.transform);
       Destroy(items, 6f);

    }

    void checkForItems()
    {
        if(!GameObject.FindWithTag("Collectables"))
        {
            CreateSceneItems();
        }
    }
 
    
}
