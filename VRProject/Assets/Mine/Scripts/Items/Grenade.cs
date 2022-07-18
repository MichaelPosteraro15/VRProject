using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public ParticleSystem effect;
    public float radius = 30f;
    public Transform cam;
    private float range = 1000f;
    public int maxGrenade = 5;
    public int currentGrenade;
    public GameObject grenade;
    public float distance = 500;
    public Animator animator;

    //danno che fa ai nemici
    public float damage = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        currentGrenade = maxGrenade;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEvent.isPaused)
        {
            AudioManager.instance.Stop("gas leak");
            return;

        }

        if (currentGrenade == 0)
            Destroy(gameObject);

        if (Input.GetButtonDown("Fire1"))
        {
            if(currentGrenade>0)
                _throw();
            
                
        }
    }

    private void _throw()
    {
        effect.Play();
        animator.Play("ThrowOb");

        AudioManager.instance.Play("gas leak");
        currentGrenade--;
        Debug.Log("lancia");



        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //il raycast in questo caso mi serve solo per indirizzare la granata verso la direzione desiderata
        if (Physics.Raycast(ray, out hit,distance))
        {
            //instanzio una nuova granata
            GameObject _grenade = Instantiate(grenade, transform.position, transform.rotation);
            //gli applico una forza che lo fa muovere verso la direzione desiderata, simulando il lancio
            _grenade.GetComponent<Rigidbody>().AddForceAtPosition(ray.direction * range, hit.point, ForceMode.Force);
        }


        
    }
}
