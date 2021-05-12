using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CollisionHandler collisionHandler;

    public List<GameObject> Boxes = new List<GameObject>();
    public List<GameObject> Walls = new List<GameObject>();

    void Awake()
    {
        collisionHandler = this.GetComponent<CollisionHandler>();

        foreach (GameObject Box in GameObject.FindGameObjectsWithTag("Box"))
        {
            Boxes.Add(Box);
        }

        foreach (GameObject Wall in GameObject.FindGameObjectsWithTag("Wall"))
        {
            Walls.Add(Wall);
        }
    }

    void FixedUpdate()
    {
        foreach (GameObject Box in Boxes)
        {
            collisionHandler.CollisionProkletiBox(Box);
        }
        foreach (GameObject Wall in Walls)
        {
            collisionHandler.CollisionProkletiWall(Wall);
        }
    }
}
