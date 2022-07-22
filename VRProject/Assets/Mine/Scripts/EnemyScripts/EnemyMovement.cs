using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private GameObject _bullet;
    public Transform player;        //posizione player
    public Transform alarmButton;   //posizione bottone allarme
    public float forwardRange;      //raggio visivo in avanti della guardia
    public float dirRange;          //raggio visivo ai lati

    

    public float rangeForEscape;    //distanza massima entro quale la guardia inseguir� il player
    private bool alert;             //la guardia � in stato di allerta

   private bool isSleeping;

    private bool alarm;             //la guardia sta correndo a dare l'allarme
    private Animator animator;      //gestore animazioni
    public NavMeshAgent agent;
    public Transform[] destinations;    //punti di pattuglia
    private int destPoint = 0;
    public float radius;

   

    private float TimePassed;
    private EnemyDevice _device;
    public Transform door;

    // Start is called before the first frame update
    void Start()
    {
        _device = GetComponent<EnemyDevice>();
        TimePassed = 0f;
        animator = GetComponent<Animator>();
        alert = false;
        alarm = false;
        agent.autoBraking = false;
        goToNextPoint();        //fa avanzare da un punto di pattuglia all'altro
    }

    private void goToNextPoint()
    {
        if (destinations.Length == 0)
        { return; }
        agent.destination = destinations[destPoint].position;
        destPoint = (destPoint + 1) % destinations.Length;
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;
        animator.SetFloat("minSpeed", agent.velocity.magnitude);
        animator.SetBool("Alert", alert);
        if (_device.isBroken())
        {
            agent.SetDestination(door.position);
        }
        else if (!alarm)
        {
            if (!alert)
            {
                if (agent.remainingDistance < 0.5f)
                { goToNextPoint(); }
                check(transform.forward, forwardRange);
                check(transform.right, dirRange);
                check((transform.right * -1), dirRange); //check sinistra
                //questi 3 check controllano se a destra,sinistra e davanti si trova il giocatore
            }
            else
            {
                if (Vector3.Distance(transform.position, player.position) < rangeForEscape)
                {
                    if (TimePassed > 2f)
                    {
                        TimePassed = 0f;
                        shoot();
                    }
                    else
                    {
                      agent.SetDestination(player.position);
                    }


                }
                else
                {
                    alarm = true;
                    Debug.Log("SEI SCAPPATO");  //se il player � troppo lontano si considera scappato
                    agent.SetDestination(alarmButton.position);
                }


            }
        }
        else
        {
            agent.SetDestination(alarmButton.position);
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ExitDoor")
        {
            if (_device.isBroken())
            { Destroy(this.gameObject); }
        }
    }
    private void shoot()
    {
        if (isSleeping) { return; }
        _bullet = Instantiate(_bulletPrefab) as GameObject;
        _bullet.transform.position = transform.TransformPoint(0,1,1);
        _bullet.transform.rotation = transform.rotation;
        AudioManager.instance.Play("Fire");

    }

    public void wakeup()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        alert = true;
        animator.Play("assault_combat_run");

    }
    public void Setalert(bool v)
    {
        alert = v;
    }

    public void dieAnimation()
    {
        agent.isStopped = true;
        isSleeping = true;
        animator.Play("assault_death_C");
    }

    public void OnDrawGizmos()
    {
        RaycastHit hit;
        RaycastHit hit2;
        bool isHit = Physics.SphereCast(transform.position, 0.5f, transform.right, out hit,
            dirRange);
        bool isHit2 = Physics.SphereCast(transform.position, radius, transform.right, out hit2,
           dirRange);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.right * hit.distance);
            Gizmos.DrawWireSphere(transform.position + transform.right * hit.distance, 0.5f);
        }
        if (isHit2)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.right * hit2.distance);
            Gizmos.DrawWireSphere(transform.position + transform.right * hit2.distance, radius);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.right * dirRange);
        }

    }

    private void check(Vector3 direction, float distance)
    {

        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        float radiusSmall = 0.5f;


        if (Physics.SphereCast(ray, radiusSmall, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hit.collider.ToString().Equals(hitObject.GetComponent<BoxCollider>().ToString()) &&
                hit.distance < 15.0)
            { return; }
            if (hit.distance < distance && hitObject.GetComponent<FPSInput>())
            {
                Debug.Log("T'ha visto");
                //parte il suono d'allerta
                AudioManager.instance.Play("alert");
                alert = true;
            }

        }
        if (Physics.SphereCast(ray, radius, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hit.distance < distance && hitObject.GetComponent<FPSInput>())
            {
                Debug.Log("T'ha visto");
                AudioManager.instance.Play("alert");   
                alert = true;
            }

        }
        if (alert) { agent.speed = agent.speed * 2; }
    }

    

}