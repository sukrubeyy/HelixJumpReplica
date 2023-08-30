using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotate : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(transform.position.x,-Input.GetAxis("Mouse X")* speed,
            transform.position.z));
    }
}

