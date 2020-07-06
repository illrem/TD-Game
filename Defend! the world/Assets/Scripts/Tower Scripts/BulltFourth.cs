using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulltFourth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3);
    }
    float a = 0;
    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        transform.localScale += new Vector3(a, a, a)/10;
    }
}
