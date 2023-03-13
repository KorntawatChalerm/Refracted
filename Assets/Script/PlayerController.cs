using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PlayerController : MonoBehaviour
{
    private float xAxis;
    private float speed;
    private Rigidbody2D rb2d;
    private Animator animator;
    public bool isCrouchPressed;
    private bool isRunning;
    private string currentAnimaton;
    public bool isdead;
    public bool ismoving;
    public bool isExhaust;
    public float volumeWeight;


    [SerializeField]
    Volume exhaustVolume;

    [SerializeField]
    private float walkSpeed = 4f;
    [SerializeField]
    private float runSpeed = 5f;
    [SerializeField]
    private float staminaMax = 100f;
    [SerializeField]
    private float staminaLoseRate = 5f;
    [SerializeField]
    private float staminaFillRate = 5f;
    [SerializeField]
    private float staminaCurrent = 2f;
    [SerializeField]
    private float exhaustTime;

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
        if (Input.GetKey(KeyCode.LeftShift)  && ismoving && !isExhaust)
        {

            isRunning = true;
            Running();

        }
        else if (staminaCurrent != staminaMax)
        {

            Walk();

        }

        volumeWeight = ((staminaCurrent/100)-1)*-1;
        exhaustVolume.weight = volumeWeight;
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
        ismoving = false;

        if (isCrouchPressed)
        {
            vel.x = 0;
            rb2d.velocity = vel;

            return;
        }

        if (xAxis < 0)
        {
            vel.x = -speed;
            transform.localScale = new Vector2(-1, 1);
            ismoving = true;
        }
        else if (xAxis > 0)
        {
            vel.x = speed;
            transform.localScale = new Vector2(1, 1);
            ismoving = true;
        }

        else
        {
            vel.x = 0;
            ChangeAnimationState(PLAYER_IDLE);
        }

        if (xAxis != 0 & !isRunning)
        {
            ChangeAnimationState(PLAYER_WALK);

        }
        else if (xAxis != 0 & isRunning)
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

    void Running()
    {
        if (staminaCurrent > 0)
        {
            speed = runSpeed;
            //drain stamina
            staminaCurrent -= staminaLoseRate * Time.deltaTime;
        }
        else
        {
            StartCoroutine(RunCooldown());
        }

    }
    void Walk()
    {
        isRunning = false;

        speed = walkSpeed;
        //regen stamina
        if (staminaCurrent < staminaMax)
        {
            staminaCurrent += staminaFillRate * Time.deltaTime;
        }

    }

    IEnumerator RunCooldown()
    {

        isExhaust = true;

        yield return new WaitForSeconds(exhaustTime);
        isExhaust = false;

        StopCoroutine(RunCooldown());

    }

}
