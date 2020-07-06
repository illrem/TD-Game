using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //the distance, speed and frequency the tower can fire
    public int range = 50;
    public int fireRate = 100;
    public float speed = 5  ;
    public float rotateSpeed = 100;

    [SerializeField]
    private GameObject tower;

    [SerializeField]
    private GameObject projectile;

    //get the point on the sprite that the bullet shoot from
    public Transform firepoint;

    int i = 0;
    // Update is called once per frame
    void Update()
    {
        i++;
        if (i == fireRate)
        {
            Aim();
            i = 0;
        }
    }

    private void Fire()
    {
        //create a bullet at the end of the towers gun facing the same way as the tower
        GameObject bullet = Instantiate(projectile, firepoint.position, firepoint.rotation);
        //give the rigid body of the bullet high velocity
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * speed, ForceMode2D.Impulse);
    }
    private void Aim()
    {
        //get the gameobject of the closest enemy
        GameObject Enemy = FindClosestEnemy();
        //make sure an enemy is found
        if (Enemy != null)
        {
            //find the angle between the objects
            Vector3 angle = Enemy.transform.position - tower.transform.position;
            //the angles anre in radians this calculates rotation and converts it to degrees (-90 to account for offset)
            float rotation = (Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg) - 90;
            //rotate the tower to face the enemy
            tower.transform.rotation = Quaternion.Slerp(tower.transform.rotation, Quaternion.Euler(0, 0, rotation), rotateSpeed * Time.deltaTime*2);
            Fire();
        }
    }
    public GameObject FindClosestEnemy()
    {
        //create an array of game objects that fit the tag enemy
        GameObject[] EnemyArray;
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        //reset the variables associated with finding closest enemy

        Vector3 position = transform.position;
        GameObject closest = null;
        float distance = Mathf.Infinity;

        //go through all the enemys and return the one with the smallest distance from the tower
        foreach (GameObject Enemy in EnemyArray)
        {
            Vector3 diff = Enemy.transform.position - position;
            float ShortestDistance = diff.sqrMagnitude;
            //if the current enemy has a distance smaller than the closest, replace it as the closest
            if (ShortestDistance < distance)
            {
                closest = Enemy;
                distance = ShortestDistance;
            }
        }
        //if the object is within range return it, otherwise return null
        if (range >= distance)
        {
            return closest;
        }
        else { return null; } 
    }
}
