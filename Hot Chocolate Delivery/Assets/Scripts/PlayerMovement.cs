using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for movmeent and gravity
    public CharacterController controller;
    public float speed = 24f;
    public float gravity = -30f;
    public float jumpHeight = 5f;

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
    private float dashForce = 5f, dashDuration = 0.15f;

    // variables for ice movement
    public bool OnIce = false; // ice blocks change this from their script
    private Vector3 lastMovement = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      /*  //if player is holding down shift, sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 24f;
        }
      */
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

        if(isJumping == true)
        {
            controller.stepOffset = 0;
        }
        else
        {
            controller.stepOffset = 0.7f;
        }

        //move the player
        Vector3 move = transform.right * x + transform.forward * z;
        if (OnIce) {
            lastMovement += move * 0.8f; // accelerate. Change this to change how slippery it is
            if(lastMovement.magnitude > speed) {
                lastMovement = lastMovement.normalized;
                lastMovement *= speed;
            }
            controller.Move(lastMovement * Time.deltaTime);
        } else {
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
            }

            lastMovement = move; // prepare for ice movement
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


    /// <summary>
    /// if the player hits a wall with the tag "LeftWall" or "RightWall", the camera will tilt in the needed direction, and player can "wallrun"
    /// </summary>
    /// <param name="hit"></param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if player hits an object with one of these tags, increase their speed and lower the force of gravity
        if (hit.gameObject.tag == ("RightWall") || hit.gameObject.tag == ("LeftWall"))
        {
            gravity = -7f;
            speed = 30f;
            //addd camera tilt here
            if (hit.gameObject.tag == ("RightWall"))
            {
               // Camera.main.transform.rotation = Quaternion.Euler(new Vector3(0,0,13));
                Camera.main.transform.Rotate(0, 0, 13);
            }
            else if(hit.gameObject.tag == ("LeftWall"))
            {
                //Camera.main.transform.rotation = Quaternion.Euler(0, 0, -13);
                Camera.main.transform.Rotate(0, 0, -13);
            }
        }
        else
        {
            gravity = -20f;
            speed = 24f;
            //remove camera tilt here

        }
    }
}
