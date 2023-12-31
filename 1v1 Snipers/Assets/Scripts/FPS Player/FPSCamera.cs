using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FPSCamera : MonoBehaviour
{
    //Code modified from: https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/#Section_1_First_Person_View
    public Transform bodyTransform;
    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        MouseAiming();
    }
    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;
        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
        // rotate camera
        transform.eulerAngles = new Vector3(-rotX, 0, 0);
        //make sure body rotates with camera
        bodyTransform.Rotate(0, y, 0);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, bodyTransform.eulerAngles.y, 0);
    }
}