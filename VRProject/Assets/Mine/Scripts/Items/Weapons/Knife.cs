using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{ 

    public Transform cam;
    //distanza
    public float distance = 2;
    public float impact = 80;

    //danno che fa ai nemici
    public float damage = 3;
    public Animator animator;


    void Start()
    {
      //  Vector3 newRotation = new Vector3(-8.3f, 35.6f, -15.773f);
       // leftArm.eulerAngles=newRotation;
       // leftArm.rotation= Quaternion.Euler(-8.3f, 35.6f, -15.773f);
    }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        //quando si verifica l'evento richiamiamo il metodo Fire che ci permette di colpire
        if (Input.GetMouseButtonUp(0) )
        {
            Shoot();
            Debug.Log("colpisce");
        }

    }


    private void Shoot()
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


        }
    }


}
