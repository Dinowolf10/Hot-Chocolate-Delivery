using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBehavior : MonoBehaviour
{
    //fields 
    public GameObject iceToSpawn;
    private float offset = 4;
    private GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {   
        if(transform.position.y < -50)
        {
            this.AddToPool();
        }
        else if (Input.GetMouseButtonDown(0) && !levelManager.GetComponent<LevelManager>().gamePaused && isActiveAndEnabled)
        {
            SpawnIce();
        }
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
            case "LeftWall":
            case "RightWall":
                SpawnIce(collision);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// send the object back to the pool
    /// </summary>
    private void AddToPool()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// spawn ice at the current snowball location
    /// </summary>
    private void SpawnIce()
    {
        Vector3 spawnPoint = transform.position;
        GameObject clone = Instantiate(iceToSpawn, spawnPoint, Quaternion.identity);
        clone.transform.localScale = new Vector3(7.0f, 2.0f, 7.0f);
        this.AddToPool();
    }
    /// <summary>
    /// spawn snowball at the current collision location
    /// </summary>
    /// <param name="collision">Object the snowball collides with</param>
    private void SpawnIce(Collision collision)
    {
        Vector3 spawnPoint = transform.position;
        GameObject clone = Instantiate(iceToSpawn, spawnPoint, collision.transform.rotation);
        clone.transform.localScale = new Vector3(7.0f, 2.0f, 7.0f);
        this.AddToPool();
    }
}
