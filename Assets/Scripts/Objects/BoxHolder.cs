using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHolder : MonoBehaviour
{
    private List<GameObject> Boxes = new List<GameObject>();
    ParticleSystem particleSystem;

    void Start()
    {
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
            if (Collision(Box))
            {
                GetComponent<ParticleSystem>().Play();
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
}
