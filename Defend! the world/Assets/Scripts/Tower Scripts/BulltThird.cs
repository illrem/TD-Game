using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulltThird : MonoBehaviour
{
    public float destory;
    private float hp = 2;
    private void Start()
    {
        Destroy(gameObject, destory);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("bullet") && !collision.gameObject.CompareTag("Tower"))
        {
            if (collision.gameObject.CompareTag("Tank"))
            {
                collision.gameObject.GetComponent<Tank_Alien>().reduceHealth();
                collision.gameObject.GetComponent<Tank_Alien>().reduceHealth();
                collision.gameObject.GetComponent<Tank_Alien>().reduceHealth();
                Debug.Log("3");
                Destroy(this.gameObject);
            }
            else
            {
                Score.scoreNumber = Score.scoreNumber + 100;
                Cash.cashNumber = Cash.cashNumber + 1;
                Destroy(collision.gameObject);
            }
        }
        hp--;
        Debug.LogError(hp+ "------------");
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
