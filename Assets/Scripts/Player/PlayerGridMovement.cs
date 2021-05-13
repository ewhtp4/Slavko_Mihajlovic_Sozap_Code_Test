using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPosition, targetPosition;
    private List<GameObject> Walls = new List<GameObject>();

    public float moveTime = 0.001f;

    void Start()
    {
        foreach (GameObject Wall in GameObject.FindGameObjectsWithTag("Wall"))
        {
            Walls.Add(Wall);
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MoveingPlayer(Vector3.up));
        }
        if(Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MoveingPlayer(Vector3.left));
        }
        if(Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MoveingPlayer(Vector3.down));
        }
        if(Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MoveingPlayer(Vector3.right));
        }
    }

    private IEnumerator MoveingPlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.MoveTowards(originalPosition, targetPosition, 0.1f);
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


    public bool Collision(GameObject other)
    {
        if (this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            return true;
        }
        return false;
    }
}
