using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quando le mani sono vuote il player può tirare pugni
public class Empty : Weapon
{


    void Start()
    {
        distance = 1;
        impact = 60;
        damage = WeaponsDamage.PUNCH;
    }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            _shoot();
        }

    }


    //metodo che gestisce quando avviene il colpo

    public override void _shoot()
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

            GameObject hitObject = hit.transform.gameObject; //oggetto colpito
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            if (target != null)
            { target.react(damage); }


        }
    }
}
