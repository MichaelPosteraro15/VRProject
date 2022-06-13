using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public ParticleSystem effect;
    public float radius = 30f;
    public Transform cam;
    private float range = 30f;
    public int maxGrenade = 5;
    public int currentGrenade;
    public GameObject grenade;
   

   // public GameObject grenade;

    // Start is called before the first frame update
    void Start()
    {
        currentGrenade = maxGrenade;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGrenade == 0)
            Destroy(gameObject);

        if (Input.GetButtonDown("Fire1"))
        {
            if(currentGrenade>0)
                launch();
            
                
        }
    }

    private void launch()
    {
        effect.Play();
        AudioManager.instance.Play("gas leak");
        currentGrenade--;
        Debug.Log("lancia");
        GameObject _grenade = Instantiate(grenade, transform.position, transform.rotation);
        _grenade.GetComponent<Rigidbody>().AddForce(transform.forward *range,ForceMode.Impulse);



        
    }
}
