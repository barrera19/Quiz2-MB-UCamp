using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introGame : MonoBehaviour
{
     [SerializeField] RectTransform panelIntro;
     [SerializeField] GameObject panelStart;
    
    void Awake()
    {
        panelStart.SetActive(false);
    }
    void Start()
    {
        LeanTween.alpha(panelIntro, 0f, 0.88f).setDelay(0.3f).setEase(LeanTweenType.easeInCubic).setOnComplete(StartGame);
              
    } 
    void StartGame()
    {
        if(!panelStart)
        {
            panelStart.SetActive(true);
        }
        StartCoroutine ("loadText");
          
    }

    IEnumerator loadText()
    {
        panelIntro.GetComponent<CanvasGroup>().blocksRaycasts = false;
        yield return new WaitForSeconds(0.33f);
    }
}
