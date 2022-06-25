using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private PasswordScreen screen;
    [SerializeField] private string password;
    [SerializeField] private GameObject doors;

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

            Doors doorsScript = doors.GetComponent<Doors>();
            doorsScript.enabled = true;
        }
    }
}
