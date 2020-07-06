using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave : MonoBehaviour
{
    
    //Connected to the cash text object
    Text Wave;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to get the cash text object
        Wave = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //This is the presented score which the text will be displayed alongside the value of the cash variable
        Wave.text = "Wave: " + WaveSpawner.Currentwave;
    }
}
