using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for movmeent and gravity
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //velocity for gravity calculations
    Vector3 velocity;

    //variables for checking if there is ground below the character
    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    // Determines if player is currently jumping
    public bool isJumping = false;

    // Determines if player is currently dashing and can dash during this jump
    public bool isDashing = false;
    public bool hasDashed = false;

    // Determines dash force and duration
    [SerializeField]
    private float dashForce = 5f, dashDuration = 0.1f;

    // variables for ice movement
    public bool OnIce = false; // ice blocks change this from their script
    private Vector3 lastMovement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if player is holding down shift, sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 24f;
        }

        //when the player stops sprinting, change the speed to reflect that
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }

        //check the player to see if they are grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        // If the player isGrounded, set isJumping and hasDashed to false
        if (isGrounded)
        {
            isJumping = false;
            hasDashed = false;
        }
        // Otherwise set isJumping to true
        else
        {
            isJumping = true;
        }

        //if the player is grouned, keep the velocity constant
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //hook up the movement to the controls on the keyboard
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // If the player presses E and they are jumping, start AirDash Coroutine
        if (Input.GetKeyDown(KeyCode.E) && isJumping && !isDashing && !hasDashed)
        {
            StartCoroutine("AirDash");
        }

        //if the playrer is on the ground and they are trying to jump, they jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            // Set isJumping to true
            isJumping = true;
        }

        //move the player
        if (OnIce && Input.GetKey("w") == false && Input.GetKey("a") == false && Input.GetKey("s") == false && Input.GetKey("d") == false && !isDashing) {
            // on ice and no movement being pressed: slip
            controller.Move(lastMovement * Time.deltaTime);
        } else {
            Vector3 move = transform.right * x + transform.forward * z;
            
            // If player isDashing, move player forward and include dashForce in movement
            if (isDashing)
            {
                controller.Move(transform.forward * speed * Time.deltaTime * dashForce);
                lastMovement = transform.forward * speed * dashForce;
            }
            // Otherwise move normally
            else
            {
                controller.Move(move * speed * Time.deltaTime);
                lastMovement = move * speed;
            }
        }

        if (!isDashing)
        {
            //calculate rate of fall when player falls
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    /// <summary>
    /// Keeps track of isDashing bool
    /// </summary>
    private IEnumerator AirDash()
    {
        // Sets isDashing and hasDashed to true
        isDashing = true;
        hasDashed = true;

        // Waits for dashDuration
        yield return new WaitForSeconds(dashDuration);

        // Sets isDashing to false
        isDashing = false;
    }
}
