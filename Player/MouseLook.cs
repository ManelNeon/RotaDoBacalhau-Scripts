using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePosition;
    private float smoothMouse;

    private float currentLookPosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        RotatePlayer();
    }

    void GetInput()
    {
        xMousePosition = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePosition *= sensitivity * smoothing;
        smoothMouse = Mathf.Lerp(smoothMouse, xMousePosition, 1f/smoothing);
    }

    void RotatePlayer()
    {
        currentLookPosition += smoothMouse;
        transform.localRotation = Quaternion.AngleAxis(currentLookPosition, transform.up);
    }
}
