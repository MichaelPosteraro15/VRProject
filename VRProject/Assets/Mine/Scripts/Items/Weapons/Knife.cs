using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{ 

   


    void Start()
    {
        damage = WeaponsDamage.KNIFE;
        impact = 80;
        distance = 2;
    }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        //quando si verifica l'evento richiamiamo il metodo Fire che ci permette di colpire
        if (Input.GetMouseButtonUp(0) )
        {
            _shoot();
            Debug.Log("colpisce");
        }

    }

    //metodo che definisce cosa avviene quando il colpo con il coltello viene sferrato\
    public override void _shoot()
    {
        RaycastHit hit;
        AudioManager.instance.Play("knife");
        animator.Play("knifeShot");

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
            { target.react(damage);
               Managers.Audio.Play("enemyKnife");
            }


        }
    }


}
