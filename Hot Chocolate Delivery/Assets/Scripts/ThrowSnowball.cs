using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThrowSnowball : MonoBehaviour
{
    //fields
    public GameObject snowball;
    public int throwStrength = 2000;
    public int reloadTime = 1;
    private float timeSinceThrow = 1.0f;
    List<GameObject> snowballs;
    public Camera cameraMain;

    private GameObject levelManager;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Stores reference to LevelManager game object
            levelManager = GameObject.Find("LevelManager");
            player = GameObject.Find("Player");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceThrow += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && timeSinceThrow > reloadTime && !levelManager.GetComponent<LevelManager>().gamePaused)
        {
            timeSinceThrow = 0.0f;
            GameObject clone = SnowballPool.SharedInstance.GetPooledObject();// (snowball, transform.position, transform.rotation);
            if(clone != null)
            {
                clone.transform.position = transform.position;
                //clone.transform.rotation = new Quaternion(cameraMain.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
                clone.transform.rotation = transform.rotation;
                clone.SetActive(true);
                clone.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrength); //from cam position
            }
        }
    }
}
