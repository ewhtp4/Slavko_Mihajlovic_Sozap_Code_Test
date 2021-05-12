using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public CollisionHandler collisionHandler;

    private List<GameObject> Walls = new List<GameObject>();
    private List<GameObject> BoxHolders = new List<GameObject>();

    void Awake()
    {
        collisionHandler = this.GetComponent<CollisionHandler>();
        foreach (GameObject Wall in GameObject.FindGameObjectsWithTag("Wall"))
        {
            Walls.Add(Wall);
        }
        foreach (GameObject BoxHolder in GameObject.FindGameObjectsWithTag("BoxHolder"))
        {
            BoxHolders.Add(BoxHolder);
        }
    }

    void FixedUpdate()
    {
        foreach (GameObject BoxHolder in BoxHolders)
        {
            collisionHandler.CollisionProkletiBoxHolder(BoxHolder);
        }
        foreach (GameObject Wall in Walls)
        {
            collisionHandler.CollisionProkletiWall(Wall);
        }
    }
}
