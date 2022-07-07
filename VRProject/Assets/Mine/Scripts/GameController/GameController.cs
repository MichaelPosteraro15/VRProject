using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe che mi tiene il conto degli obiettivi raggiunti all'interno del gioco.
//Serve anche a capire se il gioco é finito.
public class GameController : MonoBehaviour
{
    //Variabili per capire se i due obiettivi sono stati raggiunti.
    private bool goal1 = false;
    private bool goal2 = false;

    //Variabile per capire se il gioco é finito.
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(goal1 == true && goal2 == true){}

        if(Input.GetKeyDown("space") && gameOver == true){
            SceneManager.LoadScene(0);
            gameOver = false;
        }
    }

    public void GameOver(){
        gameOver = true;
    }

    public void reachGoal1(){ goal1 = true; }

    public void reachGoal2(){ goal2 = true; }
}
