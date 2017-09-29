using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -100.0f;
    private const float Y_ANGLE_MAX = 100.0f;
    private const float ZOOM_MIN = 1.0f;
    private const float ZOOM_MAX = 100.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 1.5f;
    private float sensitivityX = 1.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance -= 1.0f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance += 1.0f;
        }
        distance = Mathf.Clamp(distance, ZOOM_MIN, ZOOM_MAX);
        if (Input.GetKeyDown("space"))
            print("space key was pressed");
        if (Input.GetKeyDown("h"))
        {
            print("h key was pressed");
            if (Cursor.visible == true)
            {
                //Set Cursor to not be visible
                Cursor.visible = false;
                print("cursor invisible");
            }
            else if (Cursor.visible == false)
            {
                //Set Cursor to not be visible
                Cursor.visible = true;
                print("cursor visible");
            }
        }
            
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Vector3 offset = new Vector3(0, 6, 0);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir + offset;
        camTransform.LookAt(lookAt.position + offset);
    }


}