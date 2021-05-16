using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHolder : MonoBehaviour
{
    private List<GameObject> Boxes = new List<GameObject>();
    ParticleSystem particleSystem;
    public bool Occupied;

    void Start()
    {
        Occupied = false;
        gameObject.tag = "BoxHolder";
        particleSystem = GetComponent<ParticleSystem>();
        GetComponent<ParticleSystem>().Pause();

        foreach (GameObject Box in GameObject.FindGameObjectsWithTag("Box"))
        {
            Boxes.Add(Box);
        }
    }

    void Update()
    {    
        foreach (GameObject Box in Boxes)
        {
            Collision(Box);
        }
    }

    void Collision(GameObject other)
    {
        if (this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
