using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    

    //private Transform target;
    // Start is called before the first frame update
    void Start()
    {
       
        Destroy(this.gameObject, 30);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Score.scoreNumber = Score.scoreNumber + 100;
        Cash.cashNumber = Cash.cashNumber + 1;
        //if (!collision.gameObject.CompareTag("bullet"))
        //{
        //    Destroy(collision.collider.gameObject);
        //}
        Destroy(this.gameObject);
    }
}
