using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    InputAction shoot;
    public float impact = 100;
    public int fireRate = 10;

    // Start is called before the first frame update
    void Start()
    {
        //spara con il tasto sinistro
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //leggiamo dalla variabile shoot se abbiamo dei valori allora vuol dire che stiamo sparando
        bool isShooting = shoot.ReadValue<float>() == 1;

        if (isShooting)
        {
            Fire();
        }
        
    }

    private void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.position,fpsCam.forward,out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impact);
            }
        }
    }
}
