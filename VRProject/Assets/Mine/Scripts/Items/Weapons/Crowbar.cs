using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{

    public Transform cam;
    public float distance = 5;
    public float impact = 120;

    //danno che fa ai nemici
    public float damage = WeaponsDamage.CROWBAR;
    public Animator animator;


    void Start()
    { }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
            Debug.Log("colpisce");
        }

    }


    private void Shoot()
    {
        RaycastHit hit;
        animator.Play("knifeShot");



        if (Physics.Raycast(cam.position, cam.forward, out hit, distance))
        {
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
