using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Collisions collisions;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collisions = GetComponent<Collisions>();
    }

    public bool Move(Vector2 direction)
    {
        if(this.transform.gameObject.tag == "Player")
        {
            DirectionNormalize(direction);
        }
        if (this.transform.gameObject.tag == "Box")
        {
            FoundBoxHolder(transform.position, direction);
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

    void DirectionNormalize(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
    }

    bool FoundBoxHolder(Vector3 position, Vector2 direction)
    {
        if (collisions.ChechingForObstacles(position, direction, "BoxHolder"))
        {
            Vector2 targetPosition = new Vector2(position.x, position.y) + direction;
            transform.position = targetPosition;
            sprite.color = new Color(.5f, 1f, .5f, .5f);
        }
        return false;
    }
}
