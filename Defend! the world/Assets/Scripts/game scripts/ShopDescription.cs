using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDescription : MonoBehaviour
{
    [SerializeField]
    private GameObject Description;
    // Start is called before the first frame update
    void Start()
    {
        Description.SetActive(false);
    }

    public void OnMouseOver()
    {
        if (Shop.buy==false)
        {
            Description.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        Description.SetActive(false);
    }
}
