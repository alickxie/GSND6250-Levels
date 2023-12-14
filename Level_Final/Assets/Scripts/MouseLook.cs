using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    bool isLocked = false;

    // make this script a instantce
    public static MouseLook instance;

    // Start is called before the first frame update
    void Start()
    {
        // make this script a instantce
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LockCursor(bool x)
    {
        isLocked = x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
/*
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
*/
            // Use Lerp for smoother rotation
            Quaternion newRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, newRotation, Time.deltaTime * mouseSensitivity);

            // Smooth player body rotation
            Vector3 newPlayerRotation = playerBody.eulerAngles + Vector3.up * mouseX;
            playerBody.eulerAngles = Vector3.Lerp(playerBody.eulerAngles, newPlayerRotation, Time.deltaTime * mouseSensitivity);
        }
    }
}
