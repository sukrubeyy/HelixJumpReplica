using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform ball;
    public Vector3 difference;
    public float posOffset;

    private void Start()
    {
        difference = transform.position - ball.transform.position;
    }

    private void FixedUpdate()
    {
        if(ball.transform.position.y<transform.position.y+ posOffset)
        {
            Vector3 pos = difference + ball.position;
            transform.position = Vector3.Lerp(transform.position, pos,.1f);
        }
      
    }
}
