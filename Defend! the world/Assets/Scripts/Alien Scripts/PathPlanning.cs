using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlanning : MonoBehaviour
{
    //get the gameobject level so we can use its methods
    [SerializeField]
    private GameObject level;

    //int array to store the map
    private char[,] map;
    private char[,] map2;
    public List<int[]> list;

    //int to store the size of all the tiles
    private float tilesize;

    //create variables to store the start and end coordinates
    private int startx, starty;
    private int endx, endy;

    //stores the x and y coordinates of the route the aliens will take
    //private float[] routeX, routeY;

    //initializing the route arrays
    float[] routeX = new float[100];
    float[] routeY = new float[100];


    float[] route2X = new float[100];
    float[] route2Y = new float[100];


    // Start is called before the first frame update
    void Start()
    {
        //if there is only 1 path
        if (!level.GetComponent<LevelManager2Path>())
        {
            list = new List<int[]>();
            //get the tile size from level manager
            tilesize = level.GetComponent<LevelManager>().getTileSize();

            //get the map that was created in level manager and store it in map
            map = level.GetComponent<LevelManager>().GetMap();

            //loop through the array and find the start and end points
            for (int k = 0; k < map.GetLength(1); k++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    //if the start is found save the coordinates
                    //Debug.Log(j + " " + k);
                    if (map[j, k] == '2')
                    {
                        //Debug.Log("start found at" + j+ k);
                        startx = j; starty = k;
                        //add start block in map
                        list.Add(new int[2] { j, k });
                    }
                    //if the end is found save the coordinates
                    else if (map[j, k] == '3')
                    {
                        //Debug.Log("end found at" + j + k);
                        endx = j; endy = k;
                        //add end block in map
                        list.Add(new int[2] { j, k });
                    }
                }
            }
            int x = startx; int y = starty; int i = 0;
            Debug.Log("start " + startx + ", " + starty);
            Debug.Log("end " + endx + ", " + endy);

            //define the starting point of the map
            Vector3 mapstart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

            //set start to 0
            map[x, y] = '0';
            //save coodinates of route start adjusted for game world
            routeX[i] = mapstart.x + (tilesize * x); routeY[i] = mapstart.y - (y * tilesize);


            while ((x != endx) || (y != endy))
            {

                //check all the adjacent tiles
                if ((map[x + 1, y] == '1') || (map[x + 1, y] == '3'))
                {
                    x++;
                }
                else if ((map[x - 1, y] == '1') || map[x - 1, y] == '3')
                {
                    x--;
                }
                else if ((map[x, y + 1] == '1') || (map[x, y + 1] == '3'))
                {
                    y++;
                }
                else if ((map[x, y - 1] == '1') || (map[x, y - 1] == '3'))
                {
                    y--;
                }
                //if there are no unvisted path tiles the map cannot be completed
                else
                {
                    Debug.Log("invalid map: map path cannot be computed");
                    break;
                }
                i++;

                map[x, y] = '0';


                //add road block in map
                list.Add(new int[2] { x, y });
                //Debug.Log("i =" + i+ " (" + x+", "+ y + ")");
                //Debug.Log(new Vector3.mapstart.x);


                //save coodinates of route adjusted for game world
                routeX[i] = (mapstart.x + (tilesize * x)); routeY[i] = (mapstart.y - (y * tilesize));

            }
        }
        else
        {
            list = new List<int[]>();
            //get the tile size from level manager
            tilesize = level.GetComponent<LevelManager2Path>().getTileSize();

            //get the map that was created in level manager and store it in map
            map = level.GetComponent<LevelManager2Path>().GetMap();
            Debug.Log(map);
            map2 = level.GetComponent<LevelManager2Path>().GetMap2();

            //loop through the array and find the start and end points
            for (int k = 0; k < map.GetLength(1); k++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    //if the start is found save the coordinates
                    //Debug.Log(j + " " + k);
                    if (map[j, k] == '2')
                    {
                        //Debug.Log("start found at" + j+ k);
                        startx = j; starty = k;
                        //add start block in map
                        list.Add(new int[2] { j, k });
                    }
                    //if the end is found save the coordinates
                    else if (map[j, k] == '3')
                    {
                        //Debug.Log("end found at" + j + k);
                        endx = j; endy = k;
                        //add end block in map
                        list.Add(new int[2] { j, k });
                    }
                }
            }

            int x = startx; int y = starty; int i = 0;
            Debug.Log("start " + startx + ", " + starty);
            Debug.Log("end " + endx + ", " + endy);

            //define the starting point of the map
            Vector3 mapstart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

            //set start to 0
            map[x, y] = '0';
            //save coodinates of route start adjusted for game world
            routeX[i] = mapstart.x + (tilesize * x); routeY[i] = mapstart.y - (y * tilesize);


            while ((x != endx) || (y != endy))
            {

                //check all the adjacent tiles
                if ((map[x + 1, y] == '1') || (map[x + 1, y] == '3'))
                {
                    x++;
                }
                else if ((map[x - 1, y] == '1') || map[x - 1, y] == '3')
                {
                    x--;
                }
                else if ((map[x, y + 1] == '1') || (map[x, y + 1] == '3'))
                {
                    y++;
                }
                else if ((map[x, y - 1] == '1') || (map[x, y - 1] == '3'))
                {
                    y--;
                }
                //if there are no unvisted path tiles the map cannot be completed
                else
                {
                    Debug.Log("invalid map: map path cannot be computed");
                    break;
                }
                i++;

                map[x, y] = '0';


                //add road block in map
                list.Add(new int[2] { x, y });
                //Debug.Log("i =" + i+ " (" + x+", "+ y + ")");
                //Debug.Log(new Vector3.mapstart.x);


                //save coodinates of route adjusted for game world
                routeX[i] = (mapstart.x + (tilesize * x)); routeY[i] = (mapstart.y - (y * tilesize));

            }

            for (int k = 0; k < map2.GetLength(1); k++)
            {
                for (int j = 0; j < map2.GetLength(0); j++)
                {
                    //if the start is found save the coordinates
                    //Debug.Log(j + " " + k);
                    if (map2[j, k] == '2')
                    {
                        //Debug.Log("start found at" + j+ k);
                        startx = j; starty = k;
                        //add start block in map
                        list.Add(new int[2] { j, k });
                    }
                    //if the end is found save the coordinates
                    else if (map2[j, k] == '3')
                    {
                        //Debug.Log("end found at" + j + k);
                        endx = j; endy = k;
                        //add end block in map
                        list.Add(new int[2] { j, k });
                    }
                }
            }

            x = startx; y = starty; i = 0;
            Debug.Log("start " + startx + ", " + starty);
            Debug.Log("end " + endx + ", " + endy);


            //set start to 0
            map2[x, y] = '0';
            //save coodinates of route start adjusted for game world
            route2X[i] = mapstart.x + (tilesize * x); route2Y[i] = mapstart.y - (y * tilesize);


            while ((x != endx) || (y != endy))
            {

                //check all the adjacent tiles
                if ((map2[x + 1, y] == '1') || (map2[x + 1, y] == '3'))
                {
                    x++;
                }
                else if ((map2[x - 1, y] == '1') || map2[x - 1, y] == '3')
                {
                    x--;
                }
                else if ((map2[x, y + 1] == '1') || (map2[x, y + 1] == '3'))
                {
                    y++;
                }
                else if ((map2[x, y - 1] == '1') || (map2[x, y - 1] == '3'))
                {
                    y--;
                }
                //if there are no unvisted path tiles the map cannot be completed
                else
                {
                    Debug.Log("invalid map: map path cannot be computed");
                    break;
                }
                i++;

                map2[x, y] = '0';


                //add road block in map
                list.Add(new int[2] { x, y });
                //Debug.Log("i =" + i+ " (" + x+", "+ y + ")");
                //Debug.Log(new Vector3.mapstart.x);


                //save coodinates of route adjusted for game world
                route2X[i] = (mapstart.x + (tilesize * x)); route2Y[i] = (mapstart.y - (y * tilesize));

            }
        }
    }


    public float getRouteX(int l, int routeno)
    {
        if (routeno == 0)
        {
            return routeX[l];
        }

        else
        {
            return route2X[l];
        }
    }

    public float getRouteY(int l, int routeno)
    {
        if (routeno == 0)
        {
            return routeY[l];
        }

        else
        {
            return route2Y[l];
        }
    }
}

