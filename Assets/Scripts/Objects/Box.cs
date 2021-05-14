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

    public bool Move(Vector2 direction)
    {
        FoundBoxHolder(transform.position, direction);

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
            sprite.color = new Color(.5f, 1f, .5f, .5f);
            OnHolder = true;
        }
        return false;
    }
}
