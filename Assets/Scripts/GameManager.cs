using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public BackgroundBehaviour backgroundBH;
    public TextMeshProUGUI finalPoints;
    public PlayerBehaviour playerBH;
  

    [Header("GameObjects")]
    public GameObject player;
    public GameObject Scenario;
    public GameObject limits;
    public GameObject collectables;
    public GameObject enemy;
    public GameObject obstacle;
    

     [Header("Game Play Scenarios")]

     
     public GameObject gamePlay;
     public GameObject backgroundStart;
     public GameObject backgroundGameplay;
     public GameObject backgroundGameOver;

     int platformMultiplier;
     float timeMultiplier;

    private Animator animator;
    private Animator groundAnimator;

    
    [Header("UI CONTROL - CANVA")]
    [Range(0,20)] public float worldSpeed;
    [SerializeField] GameObject canvaIntro;
    [SerializeField] GameObject canvaStart;
    [SerializeField] GameObject canvaGame;
    [SerializeField] GameObject canvaGameOver;
    [SerializeField] GameObject canvaPause;


    void Awake(){
        worldSpeed = 0f;
        manager = this;
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        groundAnimator = GameObject.FindWithTag("Ground").GetComponent<Animator>();
        canvaStart.SetActive(true);
        
    }
    void Start()
    {
        // UI control 
        canvaStart.SetActive(true);
        canvaGame.SetActive(false);
        canvaGameOver.SetActive(false);
        canvaPause.SetActive(false);
        
        // GO Control
        backgroundStart.SetActive(true);
        gamePlay.SetActive(false);
        backgroundGameplay.SetActive(false);
        backgroundGameOver.SetActive(false);
        timeMultiplier = 1f;
        
        UIManager.uiManager.gameAudio.Play();
        


    }

    void Update()
    {
       Scenario.transform.position = new Vector3 (Scenario.transform.position.x -worldSpeed*Time.deltaTime , Scenario.transform.position.y, Scenario.transform.position.z);
       
    }

    void TimeMultiplier()
    {
        if(SceneBehaviour.sceneBehaviour.platformCounter>10 )
       {
         if(timeMultiplier<=3)
         {
            timeMultiplier = 1.05f * (Time.timeScale);
         }
        
        Time.timeScale = 1.0f * timeMultiplier;
        print("Counter: "+ SceneBehaviour.sceneBehaviour.platformCounter);
        print("Time Multiplier: " + timeMultiplier);
       }
    }
    public void StartGame(){
        
        canvaStart.SetActive(false);
        backgroundStart.SetActive(false);
        backgroundGameplay.SetActive(true);
        canvaGame.SetActive(true);
        gamePlay.SetActive(true);
        SceneBehaviour.sceneBehaviour.CreateScenePlatforms();
        SceneBehaviour.sceneBehaviour.CreateSceneItems();
        InvokeRepeating("TimeMultiplier", 10f, 15f);
        
        
        worldSpeed = 5f;
    }

    public void PauseGame(){
        Time.timeScale = 0;
        canvaPause.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = timeMultiplier;
        canvaPause.SetActive(false); 
    }

    public void GameOver()
    {
        canvaGame.SetActive(false);
        gamePlay.SetActive(false);
        backgroundGameplay.SetActive(false);
        backgroundGameOver.SetActive(true);
        worldSpeed = 0;
        Time.timeScale = 1;
        canvaGameOver.SetActive(true);
        UIManager.uiManager.gameAudio.Pause();
        UIManager.uiManager.gameOverSound.Play();
        finalPoints.text = playerBH.playerPoints.ToString();
        SceneBehaviour.sceneBehaviour.StopScenePlatforms();
        SceneBehaviour.sceneBehaviour.StopSceneItems();
        

        print("GameOver");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        SceneBehaviour.sceneBehaviour.platformCounter= 0;
        
    }
   public void ExitGame()
    {
        Application.Quit();
    }

    void FixedUpdate()
    {
        AcelerateWorld();
        
    }

    void AcelerateWorld()
    {
        float worldSpeedMultiplier = 1.1f;
        if(Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftShift)) {   
            {    
                backgroundBH.Acelerate(1.3f, 1.2f);
                    worldSpeed = worldSpeed+ (1*worldSpeedMultiplier);
                    if(worldSpeed>=20f)
                    { worldSpeed=20f; }
                animator.SetFloat("isSpeed", worldSpeed);
                groundAnimator.SetFloat("isSpeed", worldSpeed);
            }    
        }
        if(!Input.GetMouseButton(1) || Input.GetKeyUp(KeyCode.LeftShift)) {
            {   
                backgroundBH.Acelerate(0.8f, 0.8f);
                while(worldSpeed > 5)
                {
                    if ((worldSpeed/worldSpeedMultiplier)>5)
                    worldSpeed = 5 - (worldSpeed/worldSpeedMultiplier);
                    else worldSpeed = 5;
                    if(worldSpeed < 5 ) 
                    { worldSpeed = 5; break; }
                }
                animator.SetFloat("isSpeed", worldSpeed);
                groundAnimator.SetFloat("isSpeed", worldSpeed);
            }
        }
    }
    
}
