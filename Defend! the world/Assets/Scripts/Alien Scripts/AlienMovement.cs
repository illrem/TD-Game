using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    //get the level gameobject so we can use its methods
    
    private GameObject level;
    // Start is called before the first frame update

    //a variable to track our current node
    private int currentnode = 0;

    private int routeno = 0;

    [SerializeField]
    private Animator animator;

    //variables to work out direction
    private Vector3 lastPosition;
    private Vector3 CurrentPosition;

    [SerializeField]
    public float speed;
    public void setcurrentnode(int node, int no)
    {
        currentnode = node;
        routeno = no;
        //Debug.Log("xxxxxxx" + passedinnode);
    }

    //used to define which route the alien is on when there are multiple routes
    //also sets the start position of the alien
    public void setRouteNo(int no, Vector3 start)
    {
        routeno = no;
        this.gameObject.transform.position = start;
    }

    

    public int getcurrentnode()
    {
        return currentnode;
    }

    public int getRouteNo()
    {
        return routeno;
    }
    void Start()
    {

        level = GameObject.FindWithTag("level");
        //move to the start of the path
        //Debug.Log(level.GetComponent<PathPlanning>().getRouteX(currentnode));
        //transform.position.Set(level.GetComponent<PathPlanning>().getRouteX(currentnode), level.GetComponent<PathPlanning>().getRouteY(currentnode), -1);
    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = GetComponent<Transform>().position;
        //Debug.Log("i" + passedinnode);
        //Debug.Log("i =" + currentnode);
        //Debug.Log("x =" + level.GetComponent<PathPlanning>().getRouteX(currentnode));
        //Debug.Log("y =" + level.GetComponent<PathPlanning>().getRouteY(currentnode));
        //if we have reached the current node move to the next node

        if (transform.position.Equals(new Vector3(level.GetComponent<PathPlanning>().getRouteX(currentnode, routeno), level.GetComponent<PathPlanning>().getRouteY(currentnode,routeno), -1)))
        {
            currentnode++;

            //Debug.Log("c"+currentnode);
        }

        Mathf.Clamp(speed,1,100);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, (new Vector3(level.GetComponent<PathPlanning>().getRouteX(currentnode,routeno), level.GetComponent<PathPlanning>().getRouteY(currentnode,routeno), -1)), step);
        //Debug.Log("j" + currentnode);
        CurrentPosition = GetComponent<Transform>().position;
        getDirection();
    }

    public void getDirection()
    {
        float x = CurrentPosition.x - lastPosition.x;
        float y = CurrentPosition.y - lastPosition.y;

        if (Mathf.Abs(x) < Mathf.Abs(y))
        {
            if (y < 0)
            {
                animator.SetInteger("Direction", -1);
            }
            else
            {
                animator.SetInteger("Direction", 1);
            }
        }
        else
        {
            if (x < 0)
            {
                animator.SetInteger("Direction", 0);
            }
            else
            {
                animator.SetInteger("Direction", 0);
            }
        }
    }


}