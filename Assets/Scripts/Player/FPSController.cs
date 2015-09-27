using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour
{
    [Header("Movement speed of the character")]
    public float movementSpeed = 5.0f;
    [Header("Mouse sensitivity of the character")]
    public float mouseSensitivity = 5.0f;
    [Header("Character jump speed")]
    public float jumpSpeed = 20.0f;
    [Header("Vertical Rotation of the character")]
    float verticalRotation = 0;
    [Header("Up and down range of the character")]
    public float upDownRange = 60.0f;

    float verticalVelocity = 0;

    CharacterController characterController;

    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        //ROTATION

        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //MOVEMENT


        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);


    }
}