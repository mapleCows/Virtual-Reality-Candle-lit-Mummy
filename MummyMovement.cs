using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMovement : MonoBehaviour
{
    
    public float speed = 5f;
    public float height = 0.5f;
    Vector3 initialHeight;

    private void Start()
    { 
        initialHeight = transform.localPosition;
    }
    void Update()
    {
        
        float newY = Mathf.Sin(Time.time * speed) * height + initialHeight.y+1;
        transform.position = new Vector3(transform.position.x, newY,transform.position.z);

    }
}
