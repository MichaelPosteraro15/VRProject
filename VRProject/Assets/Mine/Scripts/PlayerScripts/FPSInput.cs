using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 11.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;
    private bool soundwalkingPlay=false;
    private bool soundrunningPlay = false;

    private bool isRunning = false;
    private bool isWalking = false;


    //aggiungo un animazione al player, ANIMATOR CONTENUTO IN ARMS
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       

        animator.SetBool("Run", false);
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //animazione camminata, semplicemente settiamo la variabile bool dichiarata nell animator
        if (deltaX != 0 || deltaZ != 0)
        {
            animator.SetBool("Run", true);
            if (!soundwalkingPlay)
            {
                AudioManager.instance.Play("footsteps3");
                soundwalkingPlay = true;
                isWalking = true;
            }
        }
        //altrimenti se non abbiamo nuove posizioni, quindi non è stato premuto un tasto di movimento
        //allora il suono si bloccherà
        else
        {
            AudioManager.instance.Stop("footsteps3");
            soundwalkingPlay = false;
            isWalking = false;


        }

        //se tiene premuto q allora correrà
        if ((deltaX != 0 || deltaZ != 0) && Input.GetKey(KeyCode.Q))
        {
            Debug.Log("corre");
            isRunning = true;   
            speed = 17.0f;
            animator.speed = 1.7f;

            //blocco suono cammino e starto corsa questo solo la prima volta
            if (!soundrunningPlay)
            {
                AudioManager.instance.Stop("footsteps3");
                AudioManager.instance.Play("footstepsx1");
                soundrunningPlay = true;
                soundwalkingPlay = false;

            }

        }
        //se tiene premuto tab  allora andra in modalità stealth
        else if ((deltaX != 0 || deltaZ != 0) && Input.GetKey(KeyCode.Tab))
        {
            speed = 7.0f;
            animator.speed = 0.5f;


        }

        else
        {
            speed = 11.0f;
            animator.speed = 1.0f;

            isRunning = false;

            soundrunningPlay = false;
            AudioManager.instance.Stop("footstepsx1");

            if (isWalking && !soundwalkingPlay)
            {
                AudioManager.instance.Play("footsteps3");
                soundwalkingPlay = true;
            }



        }



       



        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
