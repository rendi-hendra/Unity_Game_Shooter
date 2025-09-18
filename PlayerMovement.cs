using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    public Transform cameraTransform;

    private float xRotation = 0f; // pitch
    private float yRotation = 0f; // yaw

    private void Update()
    {
        Movement();
        Rotate();
    }

    void Movement()
    {
        float inputAD = Input.GetAxis("Horizontal");
        float inputWS = Input.GetAxis("Vertical");
        Vector3 inputWASD = new Vector3(inputAD, 0, inputWS);

        Vector3 moveCameraDirection = cameraTransform.TransformDirection(inputWASD);
        moveCameraDirection.y = 0;

        controller.Move(moveCameraDirection * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float inputMouseHorizontal = Input.GetAxis("Mouse X");
        float inputMouseVertical = Input.GetAxis("Mouse Y");

        // simpan rotasi
        yRotation += inputMouseHorizontal * rotateSpeed * Time.deltaTime;
        xRotation -= inputMouseVertical * rotateSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        // set rotasi player (pitch + yaw bareng)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
