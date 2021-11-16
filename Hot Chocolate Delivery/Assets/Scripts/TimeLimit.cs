using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public float TimeLeft = 20.0f; // time left in seconds. Change this to change how much time each level gets

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 0) {
            TimeLeft -= Time.deltaTime;
            this.gameObject.GetComponent<UnityEngine.UI.Text>().text = "Time Remaining: " + (int)TimeLeft;
            if(TimeLeft <= 0.0f) {
                // restart level
                this.gameObject.GetComponent<UnityEngine.UI.Text>().text = "Level Lost";
            }
        }
    }
}
