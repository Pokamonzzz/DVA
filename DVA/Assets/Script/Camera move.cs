using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{ 
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    public bool invertY = false;
    
    [Header("Rotation Limits")]
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;
    
    [Header("Mouse Button")]
    public int mouseButton = 0; // 0 = Left Click, 1 = Right Click, 2 = Middle Click
    
    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    
    void Start()
    {
        // Initialize rotation based on current transform
        Vector3 currentRotation = transform.eulerAngles;
        rotationY = currentRotation.y;
        rotationX = currentRotation.x;
        
        // Handle rotation > 180 degrees
        if (rotationX > 180f)
            rotationX -= 360f;
    }
    
    void Update()
    {
        HandleMouseInput();
    }
    
    void HandleMouseInput()
    {
        // Check for mouse button press
        if (Input.GetMouseButtonDown(mouseButton))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        
        // Check for mouse button release
        if (Input.GetMouseButtonUp(mouseButton))
        {
            isDragging = false;
        }
        
        // Handle dragging
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;
            
            // Calculate rotation based on mouse movement
            float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime * 10f;
            float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime * 10f;
            
            // Apply Y inversion if enabled
            if (invertY)
                mouseY = -mouseY;
            
            // Update rotation values
            rotationY += mouseX;
            rotationX -= mouseY; // Subtract for natural mouse look
            
            // Clamp vertical rotation
            rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
            
            // Apply rotation to transform
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
            
            // Update last mouse position
            lastMousePosition = currentMousePosition;
        }
    }
    
    // Alternative method using Input.GetAxis (always active, no click required)
    void HandleMouseInputAlternative()
    {
        if (Input.GetMouseButton(mouseButton))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            
            if (invertY)
                mouseY = -mouseY;
            
            rotationY += mouseX;
            rotationX -= mouseY;
            
            rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
            
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
    
    // Smooth camera rotation version
    void HandleSmoothMouseInput()
    {
        if (Input.GetMouseButton(mouseButton))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            
            if (invertY)
                mouseY = -mouseY;
            
            rotationY += mouseX;
            rotationX -= mouseY;
            
            rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
            
            Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
    
    // Reset camera rotation
    public void ResetRotation()
    {
        rotationX = 0f;
        rotationY = 0f;
        transform.rotation = Quaternion.identity;
    }
    
    // Set rotation limits at runtime
    public void SetRotationLimits(float minAngle, float maxAngle)
    {
        minVerticalAngle = minAngle;
        maxVerticalAngle = maxAngle;
    }
}
