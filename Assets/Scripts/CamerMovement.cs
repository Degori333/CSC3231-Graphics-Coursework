using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class CamerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float sprintSpeed = 30f;
    private float currSpeed;

    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    public float minimumY = -60f;
    public float maximumY = 60f;

    float rotationY = 0f;

    float horizontalMovement = 0f;
    float verticalMovement = 0f;


    void Update()
    {
        MouseLook();
        MoveCamera();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currSpeed = speed;
    }

    void MouseLook()
    {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    void MoveCamera() 
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currSpeed = speed;
        }

        transform.Translate(Vector3.forward * verticalMovement * currSpeed);
        transform.Translate(Vector3.right * horizontalMovement * currSpeed);

    }
}
