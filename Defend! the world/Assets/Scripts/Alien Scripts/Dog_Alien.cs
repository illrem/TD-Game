﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Alien : AlienMovement
{
    [SerializeField]
    GameObject Alien;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("i" + currentnode);

        // if there is an alien to be created
        if (Alien != null)
        {
            //create the alien at this position
            Vector3 position = transform.position;
            GameObject alien = Instantiate(Alien, position, Quaternion.identity);
            //set the current node of the new alien to be the same as this one 
            alien.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
        }
        Destroy(this.gameObject);
    }
}
