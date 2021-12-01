using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnowParticles : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        try
        {
            // Stores reference to player game object
            player = GameObject.Find("Player");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    private void Update()
    {
        // Follows the player's position with an offset of 10 on the y axis
        this.transform.position = (new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z));
    }
}
