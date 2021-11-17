using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    //fields
    public GameObject snowball;
    public int throwStrength = 1000;
    public int reloadTime = 1;
    private float timeSinceThrow = 1.0f;
    List<GameObject> snowballs;
    public Camera cameraMain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeSinceThrow += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && timeSinceThrow > reloadTime)
        {
            timeSinceThrow = 0.0f;
            GameObject clone = Instantiate(snowball, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(cameraMain.transform.forward * throwStrength); //from cam position
            //clone.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrength); //on 2D plane
        }

        //foreach(GameObject s in snowballs)
        //{
        //    if(s.GetComponent<Rigidbody>.on)
        //}
    }
}
