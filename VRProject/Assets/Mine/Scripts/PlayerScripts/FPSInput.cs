using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;
    private bool soundPlay=false;

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
            if (!soundPlay)
            {
                AudioManager.instance.Play("footsteps3");
                soundPlay = true;
            }
        }
        else
        {
            AudioManager.instance.Stop("footsteps3");
            soundPlay = false;


        }




        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
