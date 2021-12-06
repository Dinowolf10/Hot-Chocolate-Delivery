using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBehavior : MonoBehaviour
{
    //fields 
    public GameObject iceToSpawn;
    private float offset = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ice":
                this.AddToPool();
                break;
            case "CrackedIce":
                this.AddToPool();
                break;
            case "RegSurface":
                Vector3 spawnPoint = transform.position;
                //attempt at offsetting it properly but I am not awake enough to finish
                //if (Mathf.Abs(transform.position.x - collision.transform.position.x) > iceToSpawn.transform.localScale.x / 2)
                //{
                //    if (transform.position.x > collision.transform.position.x)
                //        spawnPoint.x += offset;
                //    if (transform.position.x < collision.transform.position.x)
                //        spawnPoint.x -= offset;
                //}
                //if (Mathf.Abs(transform.position.y - collision.transform.position.y) > iceToSpawn.transform.localScale.y / 2)
                //{
                //    if (transform.position.y > collision.transform.position.y)
                //        spawnPoint.y += offset;
                //    if (transform.position.y < collision.transform.position.y)
                //        spawnPoint.y -= offset;
                //}
                //if (Mathf.Abs(transform.position.z - collision.transform.position.z) > iceToSpawn.transform.localScale.z / 2)
                //{
                //    if (transform.position.z > collision.transform.position.z)
                //        spawnPoint.z += offset;
                //    if (transform.position.z < collision.transform.position.z)
                //        spawnPoint.z -= offset;
                //}
                GameObject clone = Instantiate(iceToSpawn, spawnPoint, collision.transform.rotation);
                clone.transform.localScale = new Vector3(5.0f, 3.0f, 5.0f);
                this.AddToPool();
                break;
            default:
                break;
        }
    }

    private void AddToPool()
    {
        gameObject.SetActive(false);
    }
}
