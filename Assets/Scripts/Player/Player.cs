using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collisions collisions;
    private bool m_ReadyForInput;
    
    void Start()
    {
        collisions = GetComponent<Collisions>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5) //Button is pressed or held
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                Move(moveInput);
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    public bool Move(Vector2 direction)
    {
        DirectionNormalize(direction);

        if (collisions.BlockedPlayer(transform.position, direction))
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
}

