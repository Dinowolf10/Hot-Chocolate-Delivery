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

    private GameObject lastSnowball;
    private GameObject levelManager;
    private GameObject player;

    public Animator playerAnimator;

    public GameObject LastSnowball{ 
        get { return lastSnowball; }
        set { lastSnowball = value; }
    }

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
            // Simulates the player throwing the snowball
            StartCoroutine("Throw");

            timeSinceThrow = 0.0f;
        }
    }

    /// <summary>
    /// Controls the player's throwing animation
    /// </summary>
    /// <returns></returns>
    private IEnumerator Throw()
    {
        // Sets the animator's isThrowing to true
        playerAnimator.SetBool("isThrowing", true);

        // Wait for 0.25 seconds
        yield return new WaitForSeconds(0.25f);

        GameObject clone = SnowballPool.SharedInstance.GetPooledObject();// (snowball, transform.position, transform.rotation);
        if (clone != null)
        {
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;
            clone.SetActive(true);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrength); //from cam position
            lastSnowball = clone;
        }

        // Wait for 0.35 seconds
        yield return new WaitForSeconds(0.35f);

        // Set isThrowing to false
        playerAnimator.SetBool("isThrowing", false);
    }
}
