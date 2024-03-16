using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    private InputActs inputActs;

    public event EventHandler onInteract;

    private void Awake()
    {
        inputActs=new InputActs();
        inputActs.Player.Enable();
        inputActs.Player.Interact.performed += onInteractPerformed;
    }

    private void onInteractPerformed(InputAction.CallbackContext obj)
    {
        onInteract?.Invoke(this,EventArgs.Empty);
    }

}
