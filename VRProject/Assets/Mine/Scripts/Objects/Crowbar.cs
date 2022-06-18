using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public Transform cam;
    public float distance = 5;
    public float impact = 120;
    public float damage = 0;
    public Animator animator;


    void Start()
    { }


    void Update()
    {

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
            if (hit.rigidbody != null)
            {
                AudioManager.instance.Play("crowbarShoot");

                hit.rigidbody.AddForce(-hit.normal * impact);
                return;
            }


        }

        AudioManager.instance.Play("airHit");
    }


}
