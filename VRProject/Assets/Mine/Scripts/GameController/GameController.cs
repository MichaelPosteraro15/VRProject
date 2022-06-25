using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameOverCanvas gameOverCanvas;

    private bool goal1 = false;
    private bool goal2 = false;

    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goal1 == true && goal2 == true){
            Debug.Log("YOU WIN");
        }

        if(Input.GetKeyDown("space") && gameOver == true){
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver(){
        gameOver = true;
        gameOverCanvas.GameOverScene();
    }

    public void reachGoal1(){
        goal1 = true;
    }

    public void reachGoal2(){
        goal2 = true;
    }
}
