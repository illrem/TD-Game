using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        //if the base is hit by an enemy
          if (collision.gameObject.tag == "Enemy")
          {
            Score.scoreNumber = Score.scoreNumber - 50;
            Health.CurrentHealth = Health.CurrentHealth - 5;
            Debug.Log("1");

            //      if (collision.gameObject.name == "Base Alien")
            //      {
            //          collision.gameObject.GetComponent(Base_Alien).Death();
            //      }
        }
        //Destroy(collision.collider.gameObject);
    }
}