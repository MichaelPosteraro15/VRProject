using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenGameOverCanvas(){
        GameObject gameOverCanvas = transform.Find("GameOverCanvas").gameObject;
        gameOverCanvas.SetActive(true);
        gameOverCanvas.GetComponent<GameOverCanvas>().GameOverScene();

        GameObject popupCanvas = transform.Find("PauseCanvas").gameObject;
        popupCanvas.SetActive(false);
    }

    public void OpenWinCanvas(){
        GameObject WinCanvas = transform.Find("WinCanvas").gameObject;
        WinCanvas.SetActive(true);
        WinCanvas.GetComponent<WinCanvas>().WinScene();

        GameObject popupCanvas = transform.Find("PauseCanvas").gameObject;
        popupCanvas.SetActive(false);
    }

}
