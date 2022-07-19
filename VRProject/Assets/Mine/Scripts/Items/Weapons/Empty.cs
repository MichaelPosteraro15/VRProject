using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quando le mani sono vuote il player può tirare pugni
public class Empty : MonoBehaviour
{

    public Transform cam;
    public float distance = 1;
    public float impact = 60;

    //danno che fa ai nemici con il pugno
    public float damage = WeaponsDamage.PUNCH;
    public Animator animator;

    void Start()
    {


        
    }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }

    }


    //metodo che gestisce quando avviene il colpo
    private void Shoot()
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
