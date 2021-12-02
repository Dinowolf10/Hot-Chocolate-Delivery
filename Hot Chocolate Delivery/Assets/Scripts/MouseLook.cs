using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //keep the mouse locked to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        //calculate look sensitivity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //calculate rotation, and clamp it to reasonable values
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //rotate the camera and player to show camrea movement
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
