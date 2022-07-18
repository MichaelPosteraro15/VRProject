using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            CloseAll();
        }
    }

    public void PauseGame (){
        GameEvent.isPaused = true;
        Time.timeScale = 0f;
    }

    public void UnPauseGame (){
        GameEvent.isPaused = false;
        Time.timeScale = 1f;
    }

    public void LockMouse(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnlockMouse(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Open() {
        gameObject.SetActive(true);
        PauseGame ();
    }

    public void Close() {
        gameObject.SetActive(false);
        //UnPauseGame ();
    }

    public void CloseAll(){
        gameObject.SetActive(false);
        UnPauseGame();
        UnlockMouse();
    }

}
