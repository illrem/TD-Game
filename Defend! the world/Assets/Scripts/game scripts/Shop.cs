using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TowerType
{
    Default = 4,
    Tower1 = 0,
    Tower2 = 1,
    Tower3 = 2,
    Tower4 = 3
}
public class Shop : MonoBehaviour
{
    public static Shop instance;

    public static Shop GetInstance() {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    public GameObject shop;
    public Button Showshop;

    public Button tower1;
    public Button tower2;
    public Button tower3;
    public Button tower4;
    public TowerType curBuyTowerType = TowerType.Default;

    public static bool buy = false; 
    private void Start()
    {
        Debug.Log(buy);
        Showshop.onClick.AddListener(()=> { shop.SetActive(!shop.activeSelf); });
        buy = true;
        Debug.Log("50");
        tower1.onClick.AddListener(BuyTower1);
        tower2.onClick.AddListener(BuyTower2);
        tower3.onClick.AddListener(BuyTower3);
        tower4.onClick.AddListener(BuyTower4);
    }

    private void BuyTower4()
    {
        curBuyTowerType = TowerType.Tower4;
        Debug.LogError("CreatTower4");
    }

    private void BuyTower3()
    {
        curBuyTowerType = TowerType.Tower3;
        Debug.LogError("CreatTower3");
    }

    private void BuyTower2()
    {
        curBuyTowerType = TowerType.Tower2;
        Debug.LogError("CreatTower2");
       
    }

    private void BuyTower1()
    {
        curBuyTowerType = TowerType.Tower1;
        Debug.LogError("CreatTower1");
    }
}
