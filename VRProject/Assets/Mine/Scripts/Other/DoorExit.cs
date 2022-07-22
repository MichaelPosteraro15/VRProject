using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    [SerializeField] GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown(){
        if(gameController.GetLevel() == 5){ return; }
        if(gameController.GetLevel() == 4){
            if(gameController.GetReach1()){ gameController.NextLevel(); }
        }
        else{
            gameController.NextLevel();
        }
    }
}
