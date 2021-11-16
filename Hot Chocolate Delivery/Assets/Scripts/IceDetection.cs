using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tell the player if they are on top of ice or not
public class IceDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerMovement>().OnIce = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerMovement>().OnIce = false;
        }
    }
}
