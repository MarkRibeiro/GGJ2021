using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float zoomSpeed = 10.0f;
    public float rotationSpeed = 10.0f;

    public Transform islandTransform;
    public Transform cameraTransform;

    private void Update() {
        
        Vector3 pos = cameraTransform.position;
        pos += Input.GetAxis("Vertical") * Vector3.Normalize(new Vector3(cameraTransform.forward.x,0,cameraTransform.forward.z)) * panSpeed * Time.deltaTime;
        pos += Input.GetAxis("Horizontal") * Vector3.Normalize(new Vector3(cameraTransform.right.x,0,cameraTransform.right.z)) * panSpeed * Time.deltaTime;
        pos += Input.GetAxis("Mouse ScrollWheel") * cameraTransform.forward * zoomSpeed * Time.deltaTime;
        cameraTransform.position = pos;

        getCameraRotation();
    }


    private Vector2 pointOnMouseHold, pointOnMouseDown;
    void getCameraRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            pointOnMouseDown = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            pointOnMouseHold = Input.mousePosition;

            float dirX = (pointOnMouseDown - pointOnMouseHold).x * rotationSpeed * 0.001f;

            cameraTransform.Rotate(0,-dirX,0,Space.World);        
        }
    }
}