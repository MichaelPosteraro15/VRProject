using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{ //associamo la camera all'oggetto

    public Transform cam;
    public float distance = 2;
    public float impact = 80;
    public float damage = 0;
   
    

    void Start()
    { }


    void Update()
    {

        //quando si verifica l'evento richiamiamo il metodo Fire che ci permette di sparare
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
