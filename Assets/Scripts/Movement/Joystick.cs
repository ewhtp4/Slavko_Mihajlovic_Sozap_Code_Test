using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    private Transform player;
    public float speed = 5f;
    private bool touchStart = false;
    public bool m_ReadyForInput;
    private Vector2 pointA;
    private Vector2 pointB;

    private Transform innerCircle;
    private Transform outerCircle;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        innerCircle = GameObject.FindGameObjectWithTag("innerCircle").GetComponent<Transform>();
        outerCircle = GameObject.FindGameObjectWithTag("outerCircle").GetComponent<Transform>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //Getting the position of where we clicked in world view
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                Input.mousePosition.y, Camera.main.transform.position.z));
            //Also need to reverse value here
            innerCircle.transform.position = pointA;
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.transform.position = pointA;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;

        }
        if(Input.GetMouseButton(0))
        {
            touchStart = true;
            //Doing the same foe point B as for point A
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    //Movement and Physics are calcilated in FixedUpdate
    private void FixedUpdate()
    {
        // if we touched or clicked the off set is calculated
        if(touchStart)
        {
            Vector2 offset = pointB - pointA;
            //Insuring the ofset is in a radius of 1
            offset.Normalize();
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DirectionNormalize(direction);
            PlayerMove(direction);

            innerCircle.transform.position = new Vector2(pointA.x + direction.x,
                pointA.y + direction.y);
            touchStart = false;
        }
        else
        {
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void PlayerMove(Vector2 direction)
    { 
        if (direction.sqrMagnitude > 0.5) //Button is pressed or held
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CheckMovement(direction);
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }
}
