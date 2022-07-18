using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    //riferimenti
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform cam;

    public int maxAmmo = 20;
    public int currentAmmo;
    
    public float distance = 25;//distanza da cui puo colpire
    public float impact = 150;

    //danno che fa ai nemici
    public float damage = 5;


    public GameObject impactEffect;
    public Animator animator;


    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    void Start()
    {
        
        currentAmmo = maxAmmo;
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (GameEvent.isPaused)
            return;

        animator.SetBool("GunShoot", false);


        //tasto 1 mouse
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentAmmo > 0)
            {
                updateAmmo();
                
                //Calls animation on the gun that has the relevant animation events that will fire
                gunAnimator.SetTrigger("Fire");
                //metodo che gestisce il colpo
                _shoot();

            }
          
           

        }

        //se nell'inventario sono presenti i proiettili allora la pistola si ricarica
        if (Managers.Inventory.GetItemCount("bullets") != 0)
        {
            rechargeAmmo();
            AudioManager.instance.Play("reloadGun");
            Managers.Inventory.ConsumeItem("bullets");
        }
    }


    //quando avviene il colpo 
    private void _shoot()
    {
        //parte clip audio fire
        AudioManager.instance.Play("Fire");
        //settiamo a true il bool che riguarda l'animazione della pistola   
        animator.SetBool("GunShoot", true);



        RaycastHit hit;
        //se abbiamo colpito un oggetto 
        if (Physics.Raycast(cam.position, cam.forward, out hit, distance))
        {
            //se tale oggetto colpito è un rigidBody
            if (hit.rigidbody != null)
            {
                //gli applico una forza
                hit.rigidbody.AddForce(-hit.normal * impact);
            }

            //effetto su ciò che è stato colpito
            Quaternion impactR = Quaternion.LookRotation(hit.normal);
            GameObject _impact = Instantiate(impactEffect, hit.point, impactR);
            
            //mettiamo come genitore l'oggetto colpito
            _impact.transform.parent = hit.transform;
            Destroy(_impact, 4);
        }
    }

    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //animazione
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

       
        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }



    //le munizioni diminuiscono
    private void updateAmmo()
    {
        currentAmmo--;
    }

    //ricarico
    private void rechargeAmmo()
    {
        currentAmmo = maxAmmo;
    }



}
