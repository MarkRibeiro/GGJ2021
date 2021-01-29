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


    void Update()
    {
        float horizontalSpeed = transform.position.y * speed * Input.GetAxis("Horizontal");
        float verticalSpeed = transform.position.y * speed * Input.GetAxis("Vertical");
        float scrollspeed = -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        /*if ((transform.position.y >= maxHeight) && (scrollspeed > 0))
        {
            scrollspeed = 0;
        }
        else if((transform.position.y <= minHeight) && (scrollspeed < 0))
        {
            scrollspeed = 0;
        }*/

        Vector3 verticalMove = new Vector3(0, scrollspeed, 0);
        Vector3 lateralMove = horizontalSpeed * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= verticalSpeed;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;

    }
}
