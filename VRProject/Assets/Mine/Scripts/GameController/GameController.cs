using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe che mi tiene il conto degli obiettivi raggiunti all'interno del gioco.
//Serve anche a capire se il gioco é finito.
public class GameController : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    //Variabili per capire se i due obiettivi sono stati raggiunti.
    private bool goal1 = false;
    private bool goal2 = false;

    //Variabile che mi tiene conto del livello attuale
    private int level = 5;

    //Variabile per capire se il gioco é finito.
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(goal1 == true && goal2 == true){}

        if(Input.GetKeyDown("space") && gameOver == true){
            gameOverCanvas.gameObject.SetActive(false); 
            SceneManager.LoadScene(level);
            gameOver = false;
        }
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
        gameOver = false;
        goal1 = false;
        goal2 = false;
    }

    public void QuitGame(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //Setto gameOver a true se ho perso
    public void GameOver(){
        gameOverCanvas.gameObject.SetActive(true); 
        gameOverCanvas.GetComponent<GameOverCanvas>().GameOverScene();
        gameOver = true; 
    }

    //Setto goal1 a true se ho raggiunto il primo obiettivo
    public void ReachGoal1(){ goal1 = true; }

    public void ReachGoal2(){ goal2 = true; }

    public void NextLevel(){ 
        level+=1;
        SceneManager.LoadScene(level); 
    }
}
