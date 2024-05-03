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

    public event EventHandler<onChooseEventArgs> onChoose;

    public event EventHandler onCarInteract;

    public event EventHandler onHelicopterInteract;

    public event EventHandler onPlaneInteract;

    public event EventHandler onWork;

    public event EventHandler onPause;

    public class onChooseEventArgs : EventArgs
    {
        private Vector3 choose;

        public Vector3 Choose
        {
            get { return choose; }
            set { choose = value; }
        }
    }
    private void Awake()
    {
        inputActs=new InputActs();
        inputActs.Player.Enable();
        inputActs.Player.Interact.performed += onInteractPerformed;
        inputActs.Player.Jump.performed+= onJumpPerformed;
        inputActs.Player.Choose.performed += onChoosePerformed;
        inputActs.Player.Work.performed += onWorkPerformed;
        inputActs.Player.Pause.performed += onPausePerformed;
        inputActs.Car.Enable();
        inputActs.Car.Horn.performed += onHornPerformed;
        inputActs.Car.Interact.performed+=onCarInteractPerformed;
        inputActs.Helicopter.Enable();
        inputActs.Helicopter.Interact.performed += onHelicopterInteracted;
        inputActs.Plane.Enable();
        inputActs.Plane.Interact.performed += onPlaneInteracted;
        
    }

    private void onPausePerformed(InputAction.CallbackContext obj)
    {
        onPause?.Invoke(this,EventArgs.Empty);
    }

    private void onWorkPerformed(InputAction.CallbackContext obj)
    {
        onWork?.Invoke(this,EventArgs.Empty);
    }

    private void onPlaneInteracted(InputAction.CallbackContext obj)
    {
        onPlaneInteract?.Invoke(this, EventArgs.Empty);
    }

    private void onHelicopterInteracted(InputAction.CallbackContext obj)
    {
        onHelicopterInteract?.Invoke(this,EventArgs.Empty);
    }

    private void onCarInteractPerformed(InputAction.CallbackContext obj)
    {
        onCarInteract?.Invoke(this, EventArgs.Empty);
    }

    private void onChoosePerformed(InputAction.CallbackContext obj)
    {
        onChoose?.Invoke(this,new onChooseEventArgs { Choose=inputActs.Player.Choose.ReadValue<Vector3>() });
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


