/**********************************************
 *  Deals with instances when a Box is 
 *              on a holder
 *********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Collisions collisions;
    private SpriteRenderer sprite;
    public bool OnHolder;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collisions = GetComponent<Collisions>();
        OnHolder = false;
    }

    public bool GetOnHolder()
    {
        return OnHolder;
    }

    public bool Move(Vector2 direction)
    {
        if(FoundBoxHolder(transform.position, direction)) 
        { 
            return false; 
        }

        if (collisions.BlockedBox(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    bool FoundBoxHolder(Vector3 position, Vector2 direction)
    {
        if (collisions.ChechingForObstacles(position, direction, "BoxHolder"))
        {
            Vector2 targetPosition = new Vector2(position.x, position.y) + direction;
            transform.position = targetPosition;
            sprite.color = new Color(.5f, 0.7f, .3f, 1f);
            OnHolder = true;
            return true;
        }
        sprite.color = new Color(1f, 1f, 1f, 1f);
        OnHolder = false;
        return false;
    }
}
