using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    private GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            CloseTutorial();
            Close();
        }
    }

    public void Open() {
        gameObject.SetActive(true);
        OpenTutorial(0);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void OpenTutorial(int i){
        window = transform.GetChild(0).gameObject;
        window.SetActive(false);
        window = transform.GetChild(i).gameObject;
        window.SetActive(true);
    }

    public void CloseTutorial(){
        window.SetActive(false);
    }
}
