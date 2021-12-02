using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignVisibiilty : MonoBehaviour
{
    public UnityEngine.UI.Text information; 

    // Start is called before the first frame update
    void Start()
    {
        information.gameObject.SetActive(false); // start invisible
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            information.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            information.gameObject.SetActive(false);
        }
    }
}
