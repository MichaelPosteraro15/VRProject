using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDevice : MonoBehaviour
{
    [SerializeField] private Text timerLabel;
    [SerializeField] private Text deviceLabel;
    [SerializeField] private Text phaseLabel;
    [SerializeField] private GameController gameController;

    [SerializeField] private string device;

    //Variabili utili per il timer.
    private float time = 0;
    private float startTime = -1;
    private float seconds = 0;

    private bool isClicked = false; 
    private bool isDragged = false;
    private bool isHacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0;
        seconds = time % 60;

        if(isClicked == true){
            timerLabel.text = string.Format ("{0:00}", seconds);
            if (Input.GetMouseButtonDown(0)){
                if(isDragged == false){ startTime = UnityEngine.Time.time; isDragged = true;}
            }
            else if (Input.GetMouseButtonUp(0)){
                isClicked = false;
                isDragged = false;
                startTime = -1;
                timerLabel.text = string.Format ("{0:00}", 0);
            }

            if(seconds > 10){
                time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0; 
                startTime = -1;
                phaseLabel.text = "COMPLETE";
                phaseLabel.color = Color.green;
                gameController.ReachGoal2();
            }
        }

    }

    void OnMouseDown(){
        isClicked = true;
        deviceLabel.text = device;
        phaseLabel.text = "Connection....";
        phaseLabel.color = Color.red;
    }

}
