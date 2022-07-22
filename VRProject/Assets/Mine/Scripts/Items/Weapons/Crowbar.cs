using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : Weapon
{

    
    void Start()
    { 
        damage = WeaponsDamage.CROWBAR;
        distance = 5;
        impact = 120;

    }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            _shoot();
            Debug.Log("colpisce");
        }

    }


    public override void _shoot()
    {
        RaycastHit hit;
        animator.Play("knifeShot");



        if (Physics.Raycast(cam.position, cam.forward, out hit, distance))
        {
            GameObject hitObject = hit.transform.gameObject; //oggetto colpito
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            if (target != null)
            { target.react(damage); }

            //se ho colpito un oggetto che ha un rigidbody 
            if (hit.rigidbody != null)
            {
                //parte suono
                AudioManager.instance.Play("crowbarShoot");

                //accedo all'oggetto colpito e gli applico una forza
                hit.rigidbody.AddForce(-hit.normal * impact);
                return;
            }


        }

        AudioManager.instance.Play("airHit");
    }


}
