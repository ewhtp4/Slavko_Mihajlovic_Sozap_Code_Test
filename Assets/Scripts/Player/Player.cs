/*******************************************************
 *                Controls Player movement
 ******************************************************/                
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

    /****************************************************
     *       Checking if Player is ready to move
     *      if the buton pressed and released then
     *        the the player can move again
     ***************************************************/        
    public void CheckMovement(Vector2 moveInput)
    {
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5) //Button is pressed or held
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                ShouldMove(moveInput); //Checks if the player should move
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    /*****************************************************************
     *           Checking if the player is trying to move 
     *           in the direction of a Wall or a Box
     ****************************************************************/

    public void ShouldMove(Vector2 direction)
    {

        /*********************************************************
         *    Checking for walls or boxes is done in the Collisions
         *********************************************************/    
        if (collisions.BlockedPlayer(transform.position, DirectionNormalize(direction))) 
        {
            return;
        }
        transform.Translate(direction);
    }

    public Vector2 DirectionNormalize(Vector2 direction)
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

        return direction;
    }
}

