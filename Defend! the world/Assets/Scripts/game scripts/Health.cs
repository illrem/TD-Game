using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    [SerializeField]
    private GameObject Died;

    public static float CurrentHealth { get; set; }
    public static float MaximumHealth { get; set; }

    public Slider healthbar;
        
    // Start is called before the first frame update
    void Start()
    {
        // The Maximum health property is assigned to a maximum health of 100
        MaximumHealth = 100;

        //The current health is assigned to the maximum health so that once the game loads the health is resetted
        CurrentHealth = MaximumHealth;

        //hide the death screen
        Died.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Once the letter D is pressed is on the keyboard then the health will lose the health by 5
        if (CurrentHealth <= 0)
            Dead();

        healthbar.value = CalculateHealth();
    }
    
    void Dead()
    {
        //Once no health is remaining then a message will alert the user that they are dead
        CurrentHealth = 0;
        Debug.Log("Game Over - You are Dead");
        WaveSpawner.Currentwave = "0";
        Died.gameObject.SetActive(true);
    }

    float CalculateHealth() 
    { 
    return CurrentHealth / MaximumHealth;
    }
}