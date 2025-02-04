using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform cat;
    public float smoothTime = 0.125f;
    //public Vector2 posOffset;
    Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 startPos = transform.position;
        Vector3 endPos = cat.transform.position;
        //endPos.x += transform.position.x;
        //endPos.y += posOffset.y;
        endPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, endPos, ref velocity, smoothTime);
        //transform.position = Vector3.Lerp(startPos, endPos, speedOfFset * Time.deltaTime);

        
    }
}
