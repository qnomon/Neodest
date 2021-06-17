using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller; 
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public Animator animator;
    float gravity = 9.8f;
    float jumpSpeed = 8f;
    float vSpeed = 0;


    void Update(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetBool("Running", true);
            speed = 10f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("Running", false);
            speed = 6f;
        }
    }

    void FixedUpdate(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        animator.SetFloat("Speed", Mathf.Abs(horizontal)+Mathf.Abs(vertical));

        if(controller.isGrounded){
            vSpeed = 0;
            if(Input.GetKeyDown("space")){
                vSpeed = jumpSpeed;
            }
        }


        vSpeed -= gravity * Time.deltaTime;
        controller.Move(Vector3.down * -vSpeed *Time.deltaTime);

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y = vSpeed;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
