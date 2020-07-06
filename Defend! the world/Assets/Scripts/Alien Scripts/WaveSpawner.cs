using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //get the alien game object to create them later in the code
    [SerializeField]
    private GameObject[] Aliens;

    [SerializeField]
    private int numofroutes;

    //get the button used to start new waves
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject NextLevel;

    private string[][] wavedata;

    //get the current wave/ the alien currently beinmg spawned/get the maximum amount of aliens to spawn this cycle/ get the time between spawns
    int alien=0, number = 0, TimebetweenSpawn = 1000, i=0, j=0, k=0;

    public static string Currentwave = "0";

    //get level to reference to find start of map
    [SerializeField]
    private GameObject level;
    //set the spawn point of the aliens on the map
    private Vector3 position;

    [SerializeField]
    TextAsset Text;

    private string[][] textFile()
    {
        // load text file from sourceTextAsset Text = Resources.Load("Level1Waves") as TextAsset;

        //split the text file into an array using the line breaks
        string[] data = Text.text.Split(new char[] { '\n' });

        //divide the data into individual words
        string[][] wavearray = new string[data.Length][];

        for (int i = 1; i < data.Length; i++)
        {
            String[] row = data[i].Split(new char[] { ',' });
            //Debug.Log(row[1]);
            wavearray[i-1] = row;           
        }
        return wavearray;
    }

    

    void Start()
    {
        wavedata = textFile();
        alien = int.Parse(wavedata[0][1]);
        number = int.Parse(wavedata[0][2]);
        TimebetweenSpawn = int.Parse(wavedata[0][3]);

        NextLevel.gameObject.SetActive(false);
    }


        void Update()
    {

        //Debug.Log(wavedata[k][0]);
        //for the current wave
        if (Currentwave == wavedata[k][0])
        {
            //remove the new wave button from ui
            button.gameObject.SetActive(false);
            //if the time between spawn has elapsed spawn an alien
            if (i >= TimebetweenSpawn)
            {
                //create the alien set it to the correct route and give it a starting position
                Instantiate(Aliens[alien-1]).GetComponent<AlienMovement>().setRouteNo(0, new Vector3(level.GetComponent<PathPlanning>().getRouteX(0,0), level.GetComponent<PathPlanning>().getRouteY(0,0), -1));
                if (numofroutes == 2)
                {
                    //if there are 2 routes duplicate the alien on the other route
                    Instantiate(Aliens[alien - 1]).GetComponent<AlienMovement>().setRouteNo(1, new Vector3(level.GetComponent<PathPlanning>().getRouteX(0, 1), level.GetComponent<PathPlanning>().getRouteY(0, 1), -1));
                }
                i = 0;
                j++;
            }
            //if the number of aliens spawned is reached
            if (j >= number)
            {
                j = 0;
                k++;
                alien = int.Parse(wavedata[k][1]);
                number = int.Parse(wavedata[k][2]);
                TimebetweenSpawn = int.Parse(wavedata[k][3]);
            }
            i++;
            
        }
        else
        {
            if (wavedata[k][0] != "N")
            {
                //add the new wave button to ui
                button.gameObject.SetActive(true);
            }
            else
            {
                GameObject[] gos;
                gos = GameObject.FindGameObjectsWithTag("Enemy");

                if (gos.Length == 0)
                {
                    Debug.Log("No game objects are tagged with fred");


                    //add the next level button to the game
                    NextLevel.gameObject.SetActive(true);

                }
            }
        }
    }
    
 
    public void nextwave()
    {
        Currentwave = wavedata[k][0];
    }
}
