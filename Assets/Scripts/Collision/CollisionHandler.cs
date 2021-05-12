using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private SpriteRenderer sprite;

    float width;
    float height;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        width = sprite.bounds.size.x;
        height = sprite.bounds.size.y;
    }

    public void CollisionProkletiWall(GameObject other)
    {
        if(this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            float t = 0.4f;
            Vector3 temp = transform.position;
            Vector3 otherTemp = other.transform.position;

            if (temp.y < other.transform.position.y)
            {
                temp.y = temp.y - (height / 2);
                transform.position = Vector3.Lerp(transform.position, temp, t);
            }
            if (temp.y > other.transform.position.y)
            {
                temp.y = temp.y + (height / 2);
                transform.position = Vector3.Lerp(transform.position, temp, t);
            }
            if (temp.x < other.transform.position.x)
            {
                temp.x = temp.x - (width / 2);
                transform.position = Vector3.Lerp(transform.position, temp, t);
            }
            if (temp.x > other.transform.position.x)
            {
                temp.x = temp.x + (width / 2);
                transform.position = Vector3.Lerp(transform.position, temp, t);
            }
        }
        return;
    }

    public void CollisionProkletiBox(GameObject other)
    {
        if (this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            Vector3 temp = transform.position;
            Vector3 otherTemp = other.transform.position;

            if (temp.y < other.transform.position.y)
            {
                otherTemp.y = otherTemp.y + (height /2 );
                other.transform.position = Vector3.Lerp(other.transform.position, otherTemp, 0.1f);
            }
            if (temp.y > other.transform.position.y)
            {
                otherTemp.y = otherTemp.y - (height / 2);
                other.transform.position = Vector3.Lerp(other.transform.position, otherTemp, 0.1f);
            }
            if (temp.x < other.transform.position.x)
            {
                otherTemp.x = otherTemp.x + (width / 2);
                other.transform.position = Vector3.Lerp(other.transform.position, otherTemp, 0.1f);
            }
            if (temp.x > other.transform.position.x)
            {
                otherTemp.x = otherTemp.x - (width / 2);
                other.transform.position = Vector3.Lerp(other.transform.position, otherTemp, 0.1f);
            }
        }
        return;
    }

    public void CollisionProkletiBoxHolder(GameObject other)
    {
        if (this.GetComponent<Renderer>().bounds.Intersects(other.GetComponent<Renderer>().bounds))
        {
            Vector3 temp = transform.position;
            temp = other.transform.position;
            transform.position = temp;
        }
        return;
    }
}
