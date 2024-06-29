using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 inputDirection;
    public bool jumpButton;
    SetVelocityController setVelocityController;
    AddForceController addForceController;

    private void Start()
    {
        setVelocityController = GetComponent<SetVelocityController>();
        addForceController = GetComponent<AddForceController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Store the inputs in a variable
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        jumpButton = Input.GetButtonDown("Jump");

        //Send the inputs to the controller
        if (setVelocityController != null)
        {
            setVelocityController.inputDirection = inputDirection;
            setVelocityController.jump = jumpButton;
        }

        if (addForceController != null)
        {
            addForceController.inputDirection = inputDirection;
            addForceController.jump = jumpButton;
        }
    }
}
