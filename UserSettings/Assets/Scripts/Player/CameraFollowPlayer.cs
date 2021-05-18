using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 offset;
    public float zoomSize;
    
    void Start()
    {
        offset.z = -10;
        Vector3 targetPosition = transform.position + offset;
        transform.position = targetPosition;
        GetComponent<Camera>().orthographicSize = 10f;
    }
    void Update()
    {
        GetComponent<Camera>().orthographicSize = 10f;
    }
}
