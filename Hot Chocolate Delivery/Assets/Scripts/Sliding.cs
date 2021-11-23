using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{

    CharacterController controller;
    //Rigidbody rig;

    float originalHeight;
    float modifiedHeight;

    public float slideSpeed = 15f;
    public float speed = 12f;

    bool isSliding;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
       // rig = GetComponent<Rigidbody>();
        originalHeight = controller.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            IsSliding();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GoUp();
        }

        // - slide -    
        if (Input.GetKeyDown("f") && !isSliding) // press F to slide
        {
            slideTimer = 0.0; // start timer
            isSliding = true;
            slideForward = tr.forward;
        }
        if (isSliding)
        {
            h = 0.5 * height; // height is crouch height
            speed = slideSpeed; // speed is slide speed
            chMotor.movement.velocity = slideForward * speed;

            slideTimer += Time.deltaTime;
            if (slideTimer > slideTimerMax)
            {
                isSliding = false;
            }
        }

        // - apply movement modifiers -    
        chMotor.movement.maxForwardSpeed = speed; // set max speed
        var lastHeight = controller.height; // crouch/stand up smoothly 
        controller.height = Mathf.Lerp(controller.height, h, 5 * Time.deltaTime);
        tr.position.y += (controller.height - lastHeight) / 2; // fix vertical position
    

}

    private void IsSliding()
    {
        controller.height = modifiedHeight;
        controller.attachedRigidbody.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        controller.height = originalHeight;
    }

}
