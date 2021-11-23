using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{

    CharacterController controller;
    //Rigidbody rig;

    float originalHeight;
    float modifiedHeight;
    public Transform tr;

    public float slideSpeed = 0.2f;
    public float speed = 6f;

    private float height; // initial height
    private Vector3 slideForward; // direction of slide
    private float slideTimer = 0.0f;
    public float slideTimerMax = 0.05f; // time while sliding

    bool isSliding;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        tr = transform;
        originalHeight = controller.height;
    }

    // Update is called once per frame
    void Update()
    {

        // - slide -    
        if (Input.GetKeyDown(KeyCode.F) && !isSliding) // press F to slide
        {
            slideTimer = 0.0f; // start timer
            isSliding = true;
            slideForward = tr.forward;
        }
        if (isSliding)
        {
            controller.height = 0.5f * height; // height is crouch height
            speed = slideSpeed; // speed is slide speed
            controller.Move(slideForward * speed);

            slideTimer += Time.deltaTime;
            if (slideTimer > slideTimerMax)
            {
                isSliding = false;
            }
        }

        // - apply movement modifiers -    
        speed = slideSpeed; // set max speed
        var lastHeight = controller.height; // crouch/stand up smoothly 
        controller.height = Mathf.Lerp(controller.height, controller.height, 5 * Time.deltaTime);
        // fix vertical position
        tr.position = new Vector3(tr.position.x, tr.position.y + (controller.height - lastHeight) / 2, tr.position.z);

}



}
