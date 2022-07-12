using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAlarm : MonoBehaviour
{
    [SerializeField] GameController gameController;

    private bool alarm = false;
    private bool triggered = false;
    
    private float time = 0;
    private float startTime = -1;
    private float seconds = 0;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0;
        seconds = time % 60;

        if(alarm == true){ Debug.Log(seconds); }

        if(seconds > 5 && alarm == true){
            gameController.GameOver();
            alarm = false;
        }
    }

    void OnTriggerEnter(Collider col){
        startTime = UnityEngine.Time.time;
        alarm = true;
    }

    void OnTriggerExit(Collider col){
        startTime = -1;
        alarm = false;
    }
}
