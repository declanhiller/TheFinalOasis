using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.1f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = desiredPos;
    }
}
