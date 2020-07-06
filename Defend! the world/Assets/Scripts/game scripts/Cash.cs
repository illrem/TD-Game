using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cash : MonoBehaviour
{


    //Assign the value of the cash to zero as a static int
    public static int cashNumber = 200;
    //Connected to the cash text object
    Text cash;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to get the cash text object
        cash = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //This is the presented score which the text will be displayed alongside the value of the cash variable
        cash.text = "Cash: " + Mathf.Clamp(cashNumber,0,100000) ;
    }
}