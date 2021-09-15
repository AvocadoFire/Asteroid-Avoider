using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float maxVelocity;
    [SerializeField] float rotationSpeed;
    private Rigidbody rb;
    private Camera mainCamera;
    private Vector3 movementDirection;

    private void Start()
    {      
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void FixedUpdate()
    {
        if(movementDirection == Vector3.zero) { return; }

        rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force); //four different types of AddForce

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            //ONE TOUCH
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            //get position on screen
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            // transform.position - worldPosition; //returns vector pointing from where we touched to the player
            movementDirection = worldPosition - transform.position; //moves toward finger
            movementDirection.z = 0f; //making sure z doesn't change ever
            movementDirection.Normalize(); //makes it so doesn't go faster if finger farther away so ignoring magnitude
        }
        else //need to stop the velocity if we aren't touching the screen
        {
            movementDirection = Vector3.zero;
            //stop adding force and it will slow down.  Rate of slowing depends on drag on Rigidbody
        }
    }
    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1)
        {
           newPosition.x = -newPosition.x + 0.1f; //so not stuck in loop.
                  //supposed to be negative for 0. see if it keeps working.
        }
        if (viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }

        transform.position = newPosition;
    }

    private void RotateToFaceVelocity()
    {
        if (rb.velocity == Vector3.zero) { return; }
        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);
        transform.rotation = 
            Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

