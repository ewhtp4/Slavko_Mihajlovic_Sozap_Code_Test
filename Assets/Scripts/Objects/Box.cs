using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 originalPosition, targetPosition;
    private List<GameObject> Walls = new List<GameObject>();
    private List<GameObject> BoxHolders = new List<GameObject>();
    private GameObject player;
    private bool isMoving;
    public float moveTime = 0.001f;
    private Vector3 direction;
    bool BoxHolderFound = false;
    bool CollidedWithWall = false;

    void Start()
    {
        gameObject.tag = "Box";
        foreach (GameObject Wall in GameObject.FindGameObjectsWithTag("Wall"))
        {
            Walls.Add(Wall);
            Debug.Log("Wall Found");
        }
        foreach (GameObject BoxHolder in GameObject.FindGameObjectsWithTag("BoxHolder"))
        {
            BoxHolders.Add(BoxHolder);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FindingBoxHolder();
        WallCollision();

        if (Collision(player))
        {
            StartCoroutine(MoveingBox(Direction(player)));
        }
    }

    private void MoveBox()
    {
        if(BoxHolderFound) { return; }

        originalPosition = transform.position;
        targetPosition = originalPosition + Direction(player);
        transform.position = targetPosition;
    }

    Vector3 Direction(GameObject other)
    {
        Vector3 temp = transform.position;
        if (temp.x > other.transform.position.x)
        {
            direction = Vector3.right;
            return direction;
        }
        if (temp.x < other.transform.position.x)
        {
            direction = Vector3.left;
            return direction;
        }
        if (temp.y > other.transform.position.y)
        {
            direction = Vector3.down;
            return direction;
        }
        if (temp.y < other.transform.position.y)
        {
            direction = Vector3.up;
            return direction;
        }
        return direction;
    }

    void FindingBoxHolder()
    {
        foreach (GameObject BoxHolder in BoxHolders)
        {
            if (Collision(BoxHolder))
            {
                BoxHolderFound = true;
            }
        }
    }

    void WallCollision()
    {
        foreach (GameObject Wall in Walls)
        {
            if (Collision(Wall))
            {
                CollidedWithWall = true;
            }
        }
    }

    public bool Collision(GameObject other)
    {
        if (this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            return true;
        }
        return false;
    }

    private IEnumerator MoveingBox(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        while (elapsedTime < moveTime)
        {
            transform.position = targetPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        /* Wall collision check */
        foreach (GameObject Wall in Walls)
        {
            if (Collision(Wall))
            {
                targetPosition = originalPosition - (direction / 100);
                transform.position = targetPosition;
            }
        }

        isMoving = false;
    }
}
