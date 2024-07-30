using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlEve : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Transform cam;

    public float speed = 5;
    public float turnSmoothTime = 0.1f;

    public Vector3 currentMovement;

    float turnSmoothVelocity;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleAiming();

    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude > 0)
        {
            anim.SetBool("IsMoving", true);
            audioManager.playerIsMoving = true;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        else
        {
            audioManager.playerIsMoving = false;
            anim.SetBool("IsMoving", false);
        }
    }

    void HandleJumping()
    {
        if (Input.GetKey("r"))
        {
            anim.SetBool("IsJumping", true);
            audioManager.PlaySFX(audioManager.laughing);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
    }

    void HandleAiming() 
    {
        if (Input.GetKey("f") && !anim.GetBool("IsMoving"))
        {
            anim.SetBool("IsAiming", true);
            audioManager.PlaySFX(audioManager.LoadingGun);
        }
        else
        {
            anim.SetBool("IsAiming", false);
        }
    }

}
