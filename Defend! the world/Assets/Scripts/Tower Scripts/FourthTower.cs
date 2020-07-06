using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthTower : MonoBehaviour
{
    //the distance, speed and frequency the tower can fire
    public int fireRate = 100;

    [SerializeField]
    private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        Fire();
    }
    float a = 0;
    // Update is called once per frame
    void Update()
    {
        a += 1;
        if (a >= fireRate)
        {
            Fire();
            a = 0;
        }
    }
    void Fire()
    {
       GameObject lazerbullet = Instantiate(projectile, transform.position, transform.rotation, null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Base_Alien>()!=null)
        {
            if (collision.gameObject.GetComponent<Base_Alien>().speed>1)
            {
                collision.gameObject.GetComponent<Base_Alien>().speed = collision.gameObject.GetComponent<Base_Alien>().speed / 2;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Base_Alien>() != null)
        {
                collision.gameObject.GetComponent<Base_Alien>().speed = 2;
        }
    }
}
