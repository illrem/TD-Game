using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class LevelManager2Path : MonoBehaviour
{
    //get the gameobject tower to be referenced later
    [SerializeField]
    private GameObject[] towers;

    [SerializeField]
    private GameObject[] tilePrefabs;
    private List<GameObject> grass;

    [SerializeField]
    private string Level1name;
    [SerializeField]
    private string Level2name;

    //contains the map as an array of strings
    private char[,] charmap;
    private char[,] charmap1;
    private char[,] charmap2;


    //method calculates size of tile and returns it as a float
    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
    private string[] textFile(String Levelname)
    {
        TextAsset joinText = Resources.Load(Levelname) as TextAsset;


        string text = joinText.text.Replace(Environment.NewLine, string.Empty);
        return text.Split(';');
    }


    // Start is called before the first frame update
    void Start()
    {

        grass = new List<GameObject>();
        string[] mapData1 = textFile(Level1name);
        string[] mapData2 = textFile(Level2name);
        ////
        Debug.Log(mapData1);
        int map1X = mapData1[0].ToCharArray().Length;
        int map1Y = mapData1.Length;
        int map2X = mapData2[0].ToCharArray().Length;
        int map2Y = mapData2.Length;


        charmap1 = CreateCharMap(mapData1, map1X, map1Y);
        charmap2 = CreateCharMap(mapData2, map2X, map2Y);

        Combinecharmap(map1X, map1Y,charmap1,charmap2);

        Vector3 MapStart = Camera.main.ScreenToWorldPoint(new Vector3(TileSize / 2, Screen.height + TileSize / 2));
        //y axis
        for (int y = 0; y < map1Y; y++)
        {
            //x axis
            for (int x = 0; x < map1X; x++)
            {
                PlaceTile(charmap[x,y].ToString(), x, y, MapStart, map1Y, map1X);
            }
        }
    }

    private void Combinecharmap(int mapX, int mapY, char[,] charmap1, char[,] charmap2)
    {
        charmap = new char[mapX, mapY];
        char temp;

        for (int i = 0; i < mapY; i++)
        {
            for (int j = 0; j < mapX; j++)
            {
                temp = '0';
                //if not a grass tile
                if (charmap1[j,i] != '0' || charmap2[j, i] != '0')
                {
                    //if it is the end add the end tile else add a path tile
                    if (charmap1[j, i] == '3' || charmap2[j, i] == '3')
                    {
                        temp = '3';
                    }
                    else
                    {
                        temp = '1';
                    }
                }
                charmap[j, i] = temp;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if mouse is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector3 ClickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

            switch (Shop.GetInstance().curBuyTowerType)
            {
                case TowerType.Default:
                    Debug.LogError("Please Buy Your Tower!!!");
                    break;
                case TowerType.Tower1:
                    TowerSpawn(ClickVector, (int)TowerType.Tower1);
                    break;
                case TowerType.Tower2:
                    TowerSpawn(ClickVector, (int)TowerType.Tower2);
                    break;
                case TowerType.Tower3:
                    TowerSpawn(ClickVector, (int)TowerType.Tower3);
                    break;
                case TowerType.Tower4:
                    TowerSpawn(ClickVector, (int)TowerType.Tower4);
                    break;
                default:
                    break;
            }

        }
    }

    private void CreateTower(Vector3 clickVector, TowerType towerType)
    {
        // create the location of the mouse at time of click

        //Debug.Log(ClickVector.x + ", " + ClickVector.y + ", " + ClickVector.z);
        TowerSpawn(clickVector, (int)towerType);
    }
    private char[,] CreateCharMap(string[] mapData, int mapX, int mapY)
    {
        

        //find the hieght and width of the map and store them
        //int mapX = mapData[0].ToCharArray().Length;
        //int mapY = mapData.Length;

        //initilaize the char array
        charmap = new char[mapX, mapY];
        char temp;
        for (int i = 0; i < mapY; i++)
        {
            for (int j = 0; j < mapX; j++)
            {
                //add the value to the char array at a specific point
                temp = mapData[i].ToCharArray()[j];
                charmap[j, i] = temp;
            }
        }
        return charmap;
    }
    public char[,] GetMap()
    {
        return charmap1;
    }
    public char[,] GetMap2()
    {
        return charmap2;
    }

    public float getTileSize()
    {
        return TileSize;
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 MapStart, int mapx, int mapy)
    {   // "1" = 1
        int tileIndex = int.Parse(tileType);
        int rotation = 0;
        //if the tile is a road piece do some extra proccessing to make sure the right road piece is put down
        if (tileIndex == 1)
        {
            bool top = false; bool left = false; bool right = false; bool bottom = false;

            //if if above is within bounds
            if (y - 1 >= 0)
            {
                //if there is road above set top to true
                if ((charmap[x, y - 1] == '1') || (charmap[x, y - 1] == '3') || (charmap[x, y - 1] == '2'))
                {
                    top = true;
                }
            }

            //if if below is within bounds
            if (y + 1 <= mapy)
            {
                //if there is road below set bottom to true
                if ((charmap[x, y + 1] == '1') || (charmap[x, y + 1] == '3') || (charmap[x, y + 1] == '2'))
                {
                    bottom = true;
                }
            }

            //if if above is within bounds
            if (x - 1 >= 0)
            {
                //if there is road above set top to true
                if ((charmap[x - 1, y] == '1') || (charmap[x - 1, y] == '3') || (charmap[x - 1, y] == '2'))
                {
                    left = true;
                }
            }

            //if if below is within bounds
            if (x + 1 <= mapx)
            {
                //if there is road below set bottom to true
                if ((charmap[x + 1, y] == '1') || (charmap[x + 1, y] == '3') || (charmap[x + 1, y] == '2'))
                {
                    right = true;
                }
            }

            //statements to rotate the roads based on which roads it is connecting to
            if (top && bottom)
            {
                rotation = 90;
            }
            else if (top && left)
            {
                rotation = -90;
                tileIndex = 4;
            }
            else if (top && right)
            {
                rotation = 180;
                tileIndex = 4;
            }
            else if (bottom && right)
            {
                rotation = 90;
                tileIndex = 4;
            }
            else if (bottom && left)
            {
                tileIndex = 4;
            }
        }

        

        //make reference to the newTile variable by creating new tile.
        GameObject newTile = Instantiate(tilePrefabs[tileIndex]);

        //change position of tile with the newTile variable
        newTile.transform.position = new Vector3(MapStart.x + (TileSize * x), MapStart.y - (TileSize * y), 0);
        newTile.transform.Rotate(0.0f, 0.0f, rotation, Space.Self);
        grass.Add(newTile);
    }

    private void TowerSpawn(Vector3 clickVector, int index)
    {
        clickVector.z = towers[index].transform.position.z;
        Vector3 MapStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        //make sure mouse is within bounds of the array
        //if (Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize) <= charmap.GetLength(0) && Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize) >= 0 && Mathf.RoundToInt((clickVector.y - MapStart.y) / TileSize) <= charmap.GetLength(1) && Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize) >= 0)
        //{
        var w = charmap[Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize), -Mathf.RoundToInt((clickVector.y - MapStart.y) / TileSize)];

        //check location is not already occupied (convert from game coordinates and float to array coodinates)
        if (charmap[Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize), -Mathf.RoundToInt((clickVector.y - MapStart.y) / TileSize)] == '0')
        {
            var Vector2 = new Vector2((clickVector.x - MapStart.x) / TileSize, (clickVector.y - MapStart.y) / TileSize);
            //getting the list where the tower can not putting in
            var list = GameObject.Find("Level").GetComponent<PathPlanning>().list;
            var pointX = Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize);
            var pointY = -Mathf.RoundToInt((clickVector.y - MapStart.y) / TileSize);
            var point = list.FirstOrDefault(o => (o[0] == pointX && o[1] == pointY));
            if (point == null)
            {
                if (Cash.cashNumber >= (index + 1) * 100)
                {
                    Cash.cashNumber -= (index + 1) * 100;
                    //convert the position to be center of the clicked tile
                    clickVector.x = ((Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize))) * TileSize + MapStart.x;
                    clickVector.y = ((Mathf.RoundToInt((clickVector.y - MapStart.y) / TileSize))) * TileSize + MapStart.y;
                    //create a tower at the passed in position
                    Instantiate(towers[index]).transform.position = clickVector;
                    //defult the tower after build it
                    Shop.GetInstance().curBuyTowerType = TowerType.Default;
                    //set the space in the array to be full/ marked as a tower
                    charmap[Mathf.RoundToInt((clickVector.x - MapStart.x) / TileSize), -Mathf.RoundToInt((clickVector.y - MapStart.y) / TileSize)] = '4';
                }
                else
                {
                    Debug.LogError("No Enough Cash!!!");
                }
            }
            else
            {
                Debug.LogError("Can not bulid tower in current location!");
            }
        }
        //}
    }
}