using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingWall : MonoBehaviour
{
    public float crumbleTime = 2.0f; // the time it takes for the wall to be destroyed after it is touched, in seconds
    private float timer = 0.0f;
    private bool crumbling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(crumbling) {
            timer += Time.deltaTime;
            if(timer >= crumbleTime) {
                Destroy(this.gameObject);
            }
        }
    }

    // begin crumbling if the player collided
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            crumbling = true;
        }
    }
}
