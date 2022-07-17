using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//VEDERE SIMPLESHOOT
public class Gun : MonoBehaviour
{
    
    //associamo la camera all'oggetto
    public Transform cam;
    public float distance = 20;
    public float impact = 150;
    public int fireRate = 10;
    public float nextTime = 0;


    //effetto
    public ParticleSystem effect;

    void Start()
    {   }


    void Update()
    {
        if (GameEvent.isPaused)
            return;

        //quando si verifica l'evento richiamiamo il metodo Fire che ci permette di sparare
        if (Input.GetMouseButtonUp(0) && Time.time >=nextTime){
            nextTime = Time.time + 1f / fireRate;
            Fire();
            Debug.Log("spara");
        }

    }


    private void Fire()
    {
        RaycastHit hit;
        effect.Play();
        //se abbiamo colpito un oggetto
        if(Physics.Raycast(cam.position,cam.forward,out hit, distance))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impact);
            }

            
        }
    }


}