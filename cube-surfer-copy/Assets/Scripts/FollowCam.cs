using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destination;
    public Vector3 distance;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, destination.transform.position + distance, 0.25f);
    }
}
