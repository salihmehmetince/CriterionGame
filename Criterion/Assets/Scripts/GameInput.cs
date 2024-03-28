using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class GameInput : MonoBehaviour
{

    private InputActs inputActs;

    public event EventHandler onInteract;

    public event EventHandler onJump;

    public event EventHandler onHorn;


    private void Awake()
    {
        inputActs=new InputActs();
        inputActs.Player.Enable();
        inputActs.Player.Interact.performed += onInteractPerformed;
        inputActs.Player.Jump.performed+= onJumpPerformed;
        inputActs.Car.Enable();
        inputActs.Car.Horn.performed += onHornPerformed;
        inputActs.Helicopter.Enable();
        inputActs.Plane.Enable();
    }

    private void onHornPerformed(InputAction.CallbackContext obj)
    {
        onHorn?.Invoke(this,EventArgs.Empty);
    }

    private void onJumpPerformed(InputAction.CallbackContext obj)
    {
        onJump?.Invoke(this,EventArgs.Empty);
    }

    private void onInteractPerformed(InputAction.CallbackContext obj)
    {
        onInteract?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 getPlayerMovementVectorNormalized()
    {
        Vector2 movement=inputActs.Player.Movement.ReadValue<Vector2>();
        movement=movement.normalized;
        return movement;
    }

    public Vector2 getCarMovementVectorNormalized()
    {
        Vector2 movement = inputActs.Car.Movement.ReadValue<Vector2>();
        movement = movement.normalized;
        return movement;
    }

    public InputActs getInputActs()
    {
        return inputActs;
    }

    public float getHelicopterAltitude()
    {
        float direction = inputActs.Helicopter.Altitude.ReadValue<float>();
        return direction;
    }

    public Vector2 getHelicopterMovementVectorNormalized()
    {
        Vector2 movement = inputActs.Helicopter.Movement.ReadValue<Vector2>();
        movement = movement.normalized;
        return movement;
    }

    public Vector2 getPlaneMovementVectorNormalized()
    {
        Vector2 movement = inputActs.Plane.Movement.ReadValue<Vector2>();
        movement = movement.normalized;
        return movement;
    }
}


