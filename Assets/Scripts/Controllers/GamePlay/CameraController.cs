/****************************************************************
 *  Set's up Camera Z off sets as it wil be spaawned at 0,0,0 
 *                by the Level Generator
 ***************************************************************/

using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
  
    private void Start()
    {
        offset.z = -10;
        Vector3 targetPosition = transform.position + offset;
        transform.position = targetPosition;
        GetComponent<Camera>().orthographicSize = 10f;
    }
    private void Update()
    {
        GetComponent<Camera>().orthographicSize = 10f;
    }
}
