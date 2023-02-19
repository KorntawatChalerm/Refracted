using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xAxis;
    private Rigidbody2D rb2d;
    private Animator animator;
    public bool isCrouchPressed;
    private bool isRunning;
    private string currentAnimaton;
    public bool isdead;

    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float runAddSpeed = 2f;
    //States

    const string PLAYER_IDLE = "HaruIdle";
    const string PLAYER_RUN = "HaruRun";
    const string PLAYER_WALK = "HaruWalk";
    const string PLAYER_CROUCH = "HaruCrouch";

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.isdead)
        {
            return;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("crouch");
            Crouching();
            isCrouchPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouchPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            walkSpeed += runAddSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            walkSpeed -= runAddSpeed;
        }
        //Checking for inputs
        xAxis = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.isdead)
        {
            return;
        }

        //------------------------------------------

        //Check update movement based on input
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if (isCrouchPressed)
        {
            vel.x = 0;
            rb2d.velocity = vel;

            return;
        }

        if (xAxis < 0)
        {
            vel.x = -walkSpeed;
            transform.localScale = new Vector2(-1, 1);

        }
        else if (xAxis > 0)
        {
            vel.x = walkSpeed;
            transform.localScale = new Vector2(1, 1);

        }
        
        else
        {
            vel.x = 0;
            ChangeAnimationState(PLAYER_IDLE);
        }

        if(xAxis != 0 & !isRunning)
        {
            ChangeAnimationState(PLAYER_WALK);

        }
        else if(xAxis != 0 & isRunning)
        {
            ChangeAnimationState(PLAYER_RUN);

        }
        //assign the new velocity to the rigidbody
        rb2d.velocity = vel;
    }

    void Crouching()
    {
        ChangeAnimationState(PLAYER_CROUCH);

    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
