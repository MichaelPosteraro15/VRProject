using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{

    public Transform cam;
    public float distance = 1;
    public float impact = 60;
    public float damage = 0;
    public Animator animator;

    void Start()
    {


        
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Shot();
        }

    }


    private void Shot()
    {
        RaycastHit hit;
        //AudioManager.instance.Play();
        animator.Play("punch");

        //se abbiamo colpito un oggetto
        if (Physics.Raycast(cam.position, cam.forward, out hit, distance))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impact);
            }


        }
    }


}
