using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllarmButton : MonoBehaviour
{
    [SerializeField] private PasswordScreen screen;
    [SerializeField] private string password;
    [SerializeField] private GameController gameController;

    bool enabled = true;

    bool onTrigger = false;
    
    public void OnMouseDown(){
        if(onTrigger == true){
            screen.Open();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        screen.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if(screen.getPassword() == password){
            screen.setStatus("OK");
            enabled = false;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            onTrigger = true;
        }

        if(enabled == true && col.tag == "Enemy"){
            gameController.GameOver();
            AudioManager.instance.Play("alarm2");
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            onTrigger = false;
        }
    }
}
