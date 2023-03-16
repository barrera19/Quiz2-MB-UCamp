using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introLogo : MonoBehaviour
{
    [SerializeField] RectTransform panelLogo;
    [SerializeField] RectTransform textDeveloper;
    [SerializeField] RectTransform positionMotion;
    
    void Start()
    {
        LeanTween.alpha(panelLogo, 1f, 1.618f).setEase(LeanTweenType.easeInCubic);
        LeanTween.alpha(textDeveloper, 1f, 0.618f).setDelay(0.318f).setEase(LeanTweenType.easeInCubic);
        LeanTween.move(textDeveloper.gameObject, positionMotion, 1.618f).setEase(LeanTweenType.easeInQuart);
        LeanTween.alpha(textDeveloper, 0f, 1.618f).setDelay(1.318f).setEase(LeanTweenType.easeInExpo).setOnComplete(StartGame);
    } 

    void StartGame()
    {
        
        StartCoroutine ("loadText");
        SceneManager.LoadScene("PlayScene");
    }

    IEnumerator loadText()
    {
        
        yield return new WaitForSeconds(1.618f);
    }

}
