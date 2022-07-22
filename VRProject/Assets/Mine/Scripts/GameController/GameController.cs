using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe che mi tiene il conto degli obiettivi raggiunti all'interno del gioco.
//Serve anche a capire se il gioco é finito.
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject hud = null;
    public FPSInput player = null;
    //Variabili per capire se i due obiettivi sono stati raggiunti.
    private static bool goal1 = false;
    private static bool goal2 = false;

    //Variabile che mi tiene conto del livello attuale
    private static int level = 0;

    //Variabile per capire se il gioco é finito.
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(goal1 == true && goal2 == true){
            hud.GetComponent<HUD>().OpenWinCanvas();
            if(Input.GetKeyDown("space")){
                Restart();
            }
        }

        if(Input.GetKeyDown("space") && gameOver == true){
            gameOver = false;
            SceneManager.LoadScene(level);
        }
    }

    public void StartGame(){
        GameEvent.isPaused = false;
        SceneManager.LoadScene(1);

        gameOver = false;
        goal1 = false;
        goal2 = false;
    }

    public void QuitGame(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        AudioManager.instance.setListnerPause(false);
        SceneManager.LoadScene(0);
    }

    //Setto gameOver a true se ho perso
    public void GameOver(){
        gameOver = true;
        player.enabled = false;
        hud.GetComponent<HUD>().OpenGameOverCanvas();
    }

    public void Restart(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    //Setto goal1 a true se ho raggiunto il primo obiettivo
    public void ReachGoal1(){ goal1 = true; }

    public void ReachGoal2(){ goal2 = true; }

    public void NextLevel(){ 
        level+=1;
        SceneManager.LoadScene(level); 
    }

    public int GetLevel(){
        return level;
    }

    public bool GetReach1(){
        return goal1;
    }

}
