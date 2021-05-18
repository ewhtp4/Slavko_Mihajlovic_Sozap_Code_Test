/**********************************************
 *  Deals with instances when a Box is 
 *              on a holder
 *********************************************/              

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHolder : MonoBehaviour
{
    private List<GameObject> Boxes = new List<GameObject>();
    public bool Occupied;

    private void Start()
    {
        Occupied = false;
        gameObject.tag = "BoxHolder";

        foreach (GameObject Box in GameObject.FindGameObjectsWithTag("Box"))
        {
            Boxes.Add(Box);
        }
    }

    private void Update()
    {    
        foreach (GameObject Box in Boxes) // Checks if a box is on a holder
        {
            Collision(Box);
        }
    }

    private void Collision(GameObject other)
    {
        if (this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            //TODO
        }
    }
}
