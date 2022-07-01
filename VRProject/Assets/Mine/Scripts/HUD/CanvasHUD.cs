using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PausePopup pausePopup;
    [SerializeField] Animator animator;

    bool gameOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameOver == false){
            pausePopup.Open();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            gameOver = false;
        }
    }

    void GameOverScene(){
        animator.SetTrigger("FadeIn");
        gameOver = true;
    }

}
