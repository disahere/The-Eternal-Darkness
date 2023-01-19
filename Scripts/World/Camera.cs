using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
[SerializeField]
private Transform playerTransform;

const float CAMERA_LERP = 5.0f;

private float cameraZPosition;

    void Start()
    {
    cameraZPosition = transform.position.z;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * CAMERA_LERP);
        transform.position = new Vector3(transform.position.x, transform.position.y, cameraZPosition);
    }
}
