using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    float smoothFactor = 1f;
    void Start()
    {
        offset.z = -10;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }
}
