using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_Alien : AlienMovement
{

    [SerializeField]
    float MaximumHealth = 100;

    float Currenthealth = 100;
    //alien to be spawned when the tank dies
    [SerializeField]
    GameObject Alien;

    [SerializeField]
    GameObject tank;

    //healthbar to be changed when the health decreases
    [SerializeField]
    Slider healthbar;

    
  public void Setcurrenthealth(float health)
    {
        Currenthealth = health;
    }
    
   public void reduceHealth()
    {
        Debug.Log("2");
        Currenthealth--;
        calchealth();
        checkdeath();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(Currenthealth);
        //Debug.Log("i" + currentnode);
        Currenthealth--;
        calchealth();
        Debug.Log(Currenthealth);
        Debug.Log(MaximumHealth);
        
        Debug.Log(Currenthealth / MaximumHealth);
        //if not colliding with the home base destroy collision
        if (collision.gameObject.tag != "Finish")
        {
            Destroy(collision.gameObject);
        }

        checkdeath();
    }
    public void calchealth()
    {
        healthbar.value = Currenthealth / MaximumHealth;
    }

    public void checkdeath()
    {
        if (Currenthealth <= 0)
        {
            // if there is an alien to be created
            if (Alien != null)
            {
                //create the alien at this position
                Vector3 position = transform.position;
                GameObject alien1 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien1.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien2 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien2.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien3 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien3.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien4 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien4.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien5 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien5.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien6 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien6.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien7 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien7.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien8 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien8.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien9 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien9.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
                position.x += 0.05F;
                GameObject alien10 = Instantiate(Alien, position, Quaternion.identity);
                //set the current node of the new alien to be the same as this one 
                alien10.GetComponent<AlienMovement>().setcurrentnode(this.GetComponent<AlienMovement>().getcurrentnode(), this.GetComponent<AlienMovement>().getRouteNo());
               
            }
            Destroy(this.gameObject);
        }
    }
}
