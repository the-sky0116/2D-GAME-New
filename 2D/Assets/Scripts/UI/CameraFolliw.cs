using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolliw : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;


    private void LateUpdate()
    {
        Vector3 desiredPosition= target.position+offset;
        Vector3 smoothPosi= Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position= smoothPosi;
        transform.LookAt(target);
    }
}
