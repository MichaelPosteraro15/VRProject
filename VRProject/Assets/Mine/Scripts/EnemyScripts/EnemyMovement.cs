using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;        //posizione player
    public Transform alarmButton;   //posizione bottone allarme
    public float forwardRange;      //raggio visivo in avanti della guardia
    public float dirRange;          //raggio visivo ai lati
    public float rangeForEscape;    //distanza massima entro quale la guardia inseguirà il player
    private bool alert;             //la guardia è in stato di allerta
    private bool alarm;             //la guardia sta correndo a dare l'allarme
    private Animator animator;      //gestore animazioni
    public NavMeshAgent agent;      
    public Transform[] destinations;    //punti di pattuglia
    private int destPoint=0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        alert = false;
        alarm = false;
        agent.autoBraking = false;
        goToNextPoint();        //fa avanzare da un punto di pattuglia all'altro
    }

    private void goToNextPoint()
    {
        if (destinations.Length==0)
        { return; }
        agent.destination = destinations[destPoint].position;
        destPoint = (destPoint + 1) % destinations.Length;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("minSpeed", agent.velocity.magnitude);
        animator.SetBool("Alert", alert);
        if (!alarm)
        {
            if (!alert)
            {
                if (agent.remainingDistance<0.5f) 
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
                    agent.SetDestination(player.position);      
                }
                else
                {

                    alarm = true;
                    Debug.Log("SEI SCAPPATO");  //se il player è troppo lontano si considera scappato
                    agent.SetDestination(alarmButton.position);
                }


            }
        }
        else { agent.SetDestination(alarmButton.position); }
        
        //public void OnDrawGizmos()
        //{
        //    RaycastHit hit;
        //    RaycastHit hit2;
        //    bool isHit = Physics.SphereCast(transform.position, 1.5f, transform.right, out hit,
        //        forwardRange);
        //    bool isHit2 = Physics.SphereCast(transform.position, 10f, transform.right, out hit2,
        //       forwardRange);
        //    if (isHit)
        //    {
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawRay(transform.position, transform.right * hit.distance);
        //        Gizmos.DrawWireSphere(transform.position + transform.right * hit.distance, 1.5f);
        //    }
        //    if (isHit2)
        //    {
        //        Gizmos.color = Color.blue;
        //        Gizmos.DrawRay(transform.position, transform.right * hit2.distance);
        //        Gizmos.DrawWireSphere(transform.position + transform.right * hit2.distance, 10.0f);
        //    }
        //    else
        //    {
        //        Gizmos.color = Color.green;
        //        Gizmos.DrawRay(transform.position, transform.right * forwardRange);
        //    }

        //}
    }

    private void check(Vector3 direction, float distance)
    {

        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        float radius;
        if ((Vector3.Distance(transform.position, player.position) > 10.0f))
        {
            radius = 10.0f;
        }
        else { radius = 1.5f; }
        if (Physics.SphereCast(ray, radius, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hit.distance < distance && hitObject.GetComponent<PlayerCharacter>())
            {
                Debug.Log("T'ha visto");
                alert = true;
                agent.speed = agent.speed * 2;
            }

        }

    }

}
