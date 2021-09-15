using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] float maxVelocity;
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
        return;
    }
}
