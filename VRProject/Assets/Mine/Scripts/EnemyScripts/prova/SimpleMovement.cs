using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour
{
    public Transform goal;
    public Transform player;
    public Transform alarmButton;
    public NavMeshAgent agent;
    public float forwardRange;
    public float dirRange;
    public float rangeForEscape;
    private bool alert;
    private bool alarm;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
        alert = false;
        alarm = false;
        agent.SetDestination(goal.position);
    }

    public void Update()
    {
        animator.SetFloat("minSpeed", agent.velocity.magnitude);
        animator.SetBool("Alert", alert);
        if (!alarm)
        {
            if (!alert)
            {
                check(transform.forward, forwardRange);
                check(transform.right, dirRange);
                check((transform.right * -1), dirRange);
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
                    Debug.Log("SEI SCAPPATO");
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
