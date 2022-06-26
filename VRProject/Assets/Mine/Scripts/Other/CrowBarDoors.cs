using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBarDoors : MonoBehaviour
{
    public Animator animator;

    private bool doorOpen;
    private bool inTrigger;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && !doorOpen)
        {
           if( Input.GetMouseButtonUp(0) && CurrentItem.Instance.getCurrentItem()=="crowbar"){
                Debug.Log("APRI");
                doorOpen = true;
                animator.Play("OpenWithCrowbar");
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Player"  )
        {
            inTrigger = true;            
        }
    }

    void OnTriggerExit(Collider col)
    {
        inTrigger = false;
    }

}
