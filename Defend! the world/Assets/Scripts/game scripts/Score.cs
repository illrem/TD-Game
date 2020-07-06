using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //Assign the value of the score to zero as a static int
    public static int scoreNumber = 0;
    //Connected to the score text object
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to get the score text object
        score = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        //This is the presented score which the text will be displayed alongside the value of the score variable
        score.text = "Score: " + scoreNumber;
    }
}
