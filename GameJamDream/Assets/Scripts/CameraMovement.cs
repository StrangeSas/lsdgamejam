using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public Transform cameraMovement;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = cameraMovement.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, damping);
    }
}
