using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager uiManager; 
    public enum SceneItem {Null, EnemyBehaviour, CollectablesBehaviour, ObstacleBehaviour, PlayerBehaviour, GameManager, PlatformBehaviour, SceneBehaviour};
    public static Dictionary<SceneItem, System.Action> instBehaviour = new Dictionary<SceneItem, System.Action>();
    
    
    public TextMeshProUGUI speed;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI points;
    public GameManager manager;
    public PlayerBehaviour playerBH;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject collectable;
 
    void Awake()
    {
        uiManager = this;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        speed.text = manager.worldSpeed.ToString();
        lives.text = playerBH.playerLives.ToString();
        points.text = playerBH.playerPoints.ToString();
    }

    public void MuteMusic()
    {
        //Mutear Musica
    
    }
    public void soundEfect()
    {
        
    }


}
