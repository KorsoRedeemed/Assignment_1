using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerOne;
    public Transform playerOneBody;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = playerOne.position - new Vector3(transform.position.x, playerOne.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float veritcalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * veritcalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerOneBody.forward = Vector3.Slerp(playerOneBody.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
