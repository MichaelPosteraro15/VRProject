using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDevice : MonoBehaviour
{
    [SerializeField] private Text timerLabel;
    [SerializeField] private Text deviceLabel;
    [SerializeField] private Text phaseLabel;

    [SerializeField] private string device;

    //Variabili utili per il timer.
    private float time = 0;
    private float startTime = -1;
    private float seconds = 0;

    private bool isClicked = false; 
    private bool isDragged = false;
    private bool isHacking = false;
    private bool broken = false;
    private bool isTriggered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0;
        seconds = time % 60;

        /*
        if(Input.GetMouseButtonDown(0) && isTriggered == true){
            isClicked = true;
            deviceLabel.text = device;
            phaseLabel.text = "Connection....";
            phaseLabel.color = Color.red;
            Debug.Log("FUNZIONA");
        }
        */

        if(isClicked == true){
            timerLabel.text = string.Format ("{0:00}", seconds);
            if (Input.GetMouseButtonDown(0)){
                if(isDragged == false){ startTime = UnityEngine.Time.time; isDragged = true;}
            }
            else if (Input.GetMouseButtonUp(0) || isTriggered == false){
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
                broken = true;
            }
        }

    }

    void OnMouseDown(){
        if(isTriggered == true){
            isClicked = true;
            deviceLabel.text = device;
            phaseLabel.text = "Connection....";
            phaseLabel.color = Color.red;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            isTriggered = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            isTriggered = false;
        }
    }

    public bool isBroken()
    {
        return broken;
    }
}
