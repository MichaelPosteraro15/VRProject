using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator animator;
    bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("PLAYER ENTER");
            doorOpen = true;
            DoorControl("Open");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(doorOpen)
        {
            //Debug.Log("PLAYER EXIT");
            doorOpen = false;
            DoorControl("Close");
        }
    }

    void DoorControl(string direction)
    {
        try{
            animator.SetTrigger(direction);
        }
        catch{}
    }
}
