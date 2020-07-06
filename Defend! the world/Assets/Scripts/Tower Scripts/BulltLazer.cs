using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulltLazer : MonoBehaviour
{
    public float destory;
    private void Start()
    {
        Destroy(gameObject, destory);
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
