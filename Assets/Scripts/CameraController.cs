using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 0.05f;
    public float zoomSpeed = 10.0f;
    public float rotationSpeed = 0.5f;

    public float maxHeight = 40f;
    public float minHeight = 4f;

    Vector3 initialPosition;
    Vector3 initialRotation;
    Vector2 p1;
    Vector2 p2;

    private Camera mainCamera;

    private void OnValidate()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    private void Start()
    {
        initialPosition = transform.position;
        initialRotation.x = mainCamera.transform.eulerAngles.x;
        initialRotation.y = mainCamera.transform.eulerAngles.y;
        initialRotation.y = mainCamera.transform.eulerAngles.z;
    }
    void Update()
    {
        float horizontalSpeed = transform.position.y * speed * Input.GetAxis("Horizontal");
        float verticalSpeed = transform.position.y * speed * Input.GetAxis("Vertical");
        float scrollspeed = -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if ((transform.position.y >= maxHeight) && (scrollspeed > 0))
        {
            scrollspeed = 0;
        }
        else if((transform.position.y <= minHeight) && (scrollspeed < 0))
        {
            scrollspeed = 0;
        }

        if((transform.position.y + scrollspeed) > maxHeight)
        {
            scrollspeed = maxHeight - transform.position.y;
        }
        if ((transform.position.y + scrollspeed) < minHeight)
        {
            scrollspeed = minHeight - transform.position.y;
        }

        Vector3 verticalMove = new Vector3(0, scrollspeed, 0);
        Vector3 lateralMove = horizontalSpeed * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= verticalSpeed;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;
        getCameraRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = initialPosition;
            mainCamera.transform.eulerAngles = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z);
        }
    }

    void getCameraRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            p1 = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            p2 = Input.mousePosition;

            float dirX = (p1 - p2).x * rotationSpeed;
            float dirY = (p1 - p2).y * rotationSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, -dirX, 0));
            mainCamera.transform.rotation *= Quaternion.Euler(new Vector3(dirY, 0, 0));
        }
    }
}
