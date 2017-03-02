using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelcoity = 0.0f;
    private float gravity = 12.0f;
    // Use this for initialization



    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int speedHash = Animator.StringToHash("Speed");

    //States
    int runStateHash = Animator.StringToHash("monkey_run");
    int idleStateHash = Animator.StringToHash("monkey_idle");
    int jumpStateHash = Animator.StringToHash("monkey_jump");
    int dieStateHash = Animator.StringToHash("monkey_die");



    void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Infinite Move
        moveVector = Vector3.zero;
        anim.SetFloat("Speed", speed);

        //Gravity Check
        if (controller.isGrounded)
        {
            verticalVelcoity = -5f;
            //verticalVelcoity -= 0;
        }
        else
        {
            verticalVelcoity -= gravity * Time.deltaTime;
            //verticalVelcoity -= 1;
        }



        //X LEFT and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y UP and Down
        moveVector.y = verticalVelcoity;

        //Z Forward and back
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpHash);
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius) {

     //       death();
        }
    }

    private void death() {
        Debug.Log("Death");
    }

}