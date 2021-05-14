using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    MoveController moveController;

    void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    public bool BlockedPlayer(Vector3 position, Vector2 direction)
    {
        if (ChechingForObstacles(position, direction, "Wall"))
        {
            return true;
        }
        if(BoxBlockedByBox(position, direction))
        {
            return true;
        }
        return false;
    }

    private bool BoxBlockedByBox(Vector3 position, Vector2 direction)
    {
        Vector2 targetPosition = new Vector2(position.x, position.y) + direction;
        GameObject[] Boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in Boxes)
        {
            if (box.transform.position.x == targetPosition.x && box.transform.position.y == targetPosition.y)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool BlockedBox(Vector3 position, Vector2 direction)
    {
        if (ChechingForObstacles(position, direction, "Wall") || ChechingForObstacles(position, direction, "Box"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ChechingForObstacles(Vector3 position, Vector2 direction, string objectsToCheck)
    {
        Vector2 targetPosition = new Vector2(position.x, position.y) + direction;
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag(objectsToCheck);

        foreach (var Obstacle in Obstacles)
        {
            if (Obstacle.transform.position.x == targetPosition.x && Obstacle.transform.position.y == targetPosition.y)
            {
                return true;
            }
        }
        return false;
    }
}
