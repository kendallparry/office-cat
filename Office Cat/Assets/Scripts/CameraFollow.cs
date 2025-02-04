using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public float followOffset;

    private void Update()
    {
        if (cameraTarget != null)
        {
            followCat();
        }
        else
        {
            Debug.LogWarning("Camera target is not assigned.");
        }
    }

    public void followCat()
    {
        Vector3 targetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followOffset * Time.deltaTime);
        Debug.Log($"Camera position: {transform.position}, Target position: {targetPosition}");
    }
}