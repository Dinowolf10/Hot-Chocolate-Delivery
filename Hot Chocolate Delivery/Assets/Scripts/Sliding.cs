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
