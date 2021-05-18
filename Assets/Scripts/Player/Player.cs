using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collisions collisions;
    public bool m_ReadyForInput;
    
    void Start()
    {
        collisions = GetComponent<Collisions>();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        CheckMovement(moveInput);
    }

    public void CheckMovement(Vector2 moveInput)
    {
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5) //Button is pressed or held
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                ShouldMove(moveInput);
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    public void ShouldMove(Vector2 direction)
    {
        DirectionNormalize(direction);

        if (collisions.BlockedPlayer(transform.position, direction))
        {
            return;
        }
        transform.Translate(direction);
    }

    public void DirectionNormalize(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else if(Mathf.Abs(direction.x) < 0.5)
        {
            direction.y = 0;
        }
        direction.Normalize();
    }
}

