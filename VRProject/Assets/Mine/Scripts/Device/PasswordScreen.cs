using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordScreen : MonoBehaviour
{
    [SerializeField] private InputField passwordField;
    [SerializeField] private Text statusLabel;

    public void Open(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void Close(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void insertNumber(int number){
        passwordField.text += number.ToString();
    }

    public void deleteNumber(){
        passwordField.text = "";
    }

    public void exit(){
        Close();
    }

    public string getPassword(){
        return passwordField.text;
    }

    public void setStatus(string status){
        statusLabel.text = status;
        statusLabel.color = Color.green;
        passwordField.text = "";
        Close();
    }
}
