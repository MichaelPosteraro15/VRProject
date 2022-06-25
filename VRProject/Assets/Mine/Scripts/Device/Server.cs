using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
    [SerializeField] private PasswordScreen screen;
    [SerializeField] private string password;
    
    public void OnMouseDown(){
        screen.Open();
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
            Debug.Log("LEVEL COMPLETE");
        }
    }
}
