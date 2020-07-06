using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerTower : MonoBehaviour
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
        if (a>= fireRate)
        {
            Fire();
            a = 0;
        }
    }
    void Fire()
    {
        var firepoints = transform.GetComponentsInChildren<Transform>();
        foreach (var item in firepoints)
        {
            if (item.GetComponent<lazerTower>() == null)
            {
                //create a bullet at the end of the towers gun facing the same way as the tower
                GameObject lazerbullet = Instantiate(projectile, item.position, item.rotation, null);
                lazerbullet.GetComponent<Rigidbody2D>().AddForce(lazerbullet.transform.up, ForceMode2D.Impulse);
            }
        }
    }
}