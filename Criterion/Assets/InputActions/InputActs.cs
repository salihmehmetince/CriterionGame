//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputActions/InputActs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9784dfb1-0e84-461c-a861-a36cfe475c7e"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""841a3f27-f81b-4f30-9883-de46d3515a41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3fa3d0f2-ae34-4656-8738-564cd5a84705"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""04badada-510f-4e7f-9c4a-a60cdbcc21f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Choose"",
                    ""type"": ""Value"",
                    ""id"": ""89dd4c43-90b6-4534-9028-e5523c3e08bb"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""637a1f31-f285-4f93-914d-39f904602a38"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""19ed3156-151a-435c-838f-e4b5f7c21778"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84a67f55-2640-47b0-9211-65087ccd909d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d6a9d03-0dcd-41ec-b0fd-46b4eefbffd5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a2b8024e-2df8-45ed-a15d-69f1603696eb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f6286bc4-3db4-43b2-93fc-93851676525a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""23c64e78-38a6-4c93-9760-f96dbdd9daf1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""8cd4f563-54db-431f-a0cc-537684ced9e7"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe00b40d-aeac-4aad-8e49-ed4a312b3b8c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fa6cbe11-eba2-41f7-a6c1-cff88c5524da"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d22217e5-eea0-4947-aff5-bc77a9c9ab22"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fe7fdc66-1ac9-436e-a0f0-eeb4e80682f8"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""af51a7c3-83ca-40a4-9d69-0376903a37dc"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""c416dcad-09f0-44a8-973c-2ddb6dc0776d"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Car"",
            ""id"": ""930b76cd-96e0-4889-a5b2-9ef3d134afc8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7f201e94-361c-420b-a75d-0dff86dde093"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Horn"",
                    ""type"": ""Button"",
                    ""id"": ""3be667ba-0439-4664-b74f-157a8112823f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d7e15b34-0ff7-4c6a-943b-e52423faac53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1992eb1a-d892-42a4-9af4-97ed9157e313"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""95fb85cc-5fad-4b2b-8cef-1f20a64dcf7e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""59a29ece-4467-4dbf-9e1f-362215406b8c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""93e8cdb1-1e0a-4590-9dc9-abcedad7ee34"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6c4ac96d-f9b3-481d-bfb1-9a5b5c7137fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""51463b5a-96c4-4eef-a112-89ad8e27a0be"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7486712b-87aa-4018-a36c-f1192d094028"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Helicopter"",
            ""id"": ""a901604a-3e45-49c1-a20a-47b53a6b3842"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d603b419-d25c-4283-a935-742b8d5e61c5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Altitude"",
                    ""type"": ""Value"",
                    ""id"": ""77651ca2-4457-4b03-ac1a-7715b7ea7bea"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4d1cd267-620d-4276-9ae5-2c8a2f2ff105"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""54d08fa0-fd90-4d9f-92c3-f31c6d891b43"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c3ee168e-0e75-433f-afaf-982b44545f39"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bdb85ae9-29af-432c-a999-f9f4136dbb02"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""28113c1d-857c-4e9f-8844-72fe0a847e71"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""496ec617-bfcf-4b6c-b231-1d28a153075d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TY"",
                    ""id"": ""50588176-2fbb-42b1-95f9-72e010534e1a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Altitude"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5742f9dc-c791-4c10-9240-d50f3cf7685c"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Altitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5620f352-4c42-4a3d-8e55-4c140c375757"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Altitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""899fe255-5502-40bc-8c03-4a37ec8f58c9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Plane"",
            ""id"": ""5eb301ec-6508-42c9-a651-9b06c9fe0acc"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4b59bbc0-2459-452c-bd1b-1efb36f5fb24"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""16d1591e-474d-4515-9d45-abc25943bcc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6fe4af36-7f76-4b15-ab8e-0a6fef028ea1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c9bb4720-8e2c-4ed7-884b-0b7cc694ec84"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0b72b349-678e-4411-afbe-45a297c1e13b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3dc61234-2ed9-404f-9071-277aced719cd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""965e2349-1c5a-40a0-a32e-6575b119c8fa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5db8c93b-03fc-4a4c-be5a-baf07cc2793f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Choose = m_Player.FindAction("Choose", throwIfNotFound: true);
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Movement = m_Car.FindAction("Movement", throwIfNotFound: true);
        m_Car_Horn = m_Car.FindAction("Horn", throwIfNotFound: true);
        m_Car_Interact = m_Car.FindAction("Interact", throwIfNotFound: true);
        // Helicopter
        m_Helicopter = asset.FindActionMap("Helicopter", throwIfNotFound: true);
        m_Helicopter_Movement = m_Helicopter.FindAction("Movement", throwIfNotFound: true);
        m_Helicopter_Altitude = m_Helicopter.FindAction("Altitude", throwIfNotFound: true);
        m_Helicopter_Interact = m_Helicopter.FindAction("Interact", throwIfNotFound: true);
        // Plane
        m_Plane = asset.FindActionMap("Plane", throwIfNotFound: true);
        m_Plane_Movement = m_Plane.FindAction("Movement", throwIfNotFound: true);
        m_Plane_Interact = m_Plane.FindAction("Interact", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Choose;
    public struct PlayerActions
    {
        private @InputActs m_Wrapper;
        public PlayerActions(@InputActs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Choose => m_Wrapper.m_Player_Choose;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Choose.started += instance.OnChoose;
            @Choose.performed += instance.OnChoose;
            @Choose.canceled += instance.OnChoose;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Choose.started -= instance.OnChoose;
            @Choose.performed -= instance.OnChoose;
            @Choose.canceled -= instance.OnChoose;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Car
    private readonly InputActionMap m_Car;
    private List<ICarActions> m_CarActionsCallbackInterfaces = new List<ICarActions>();
    private readonly InputAction m_Car_Movement;
    private readonly InputAction m_Car_Horn;
    private readonly InputAction m_Car_Interact;
    public struct CarActions
    {
        private @InputActs m_Wrapper;
        public CarActions(@InputActs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Car_Movement;
        public InputAction @Horn => m_Wrapper.m_Car_Horn;
        public InputAction @Interact => m_Wrapper.m_Car_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void AddCallbacks(ICarActions instance)
        {
            if (instance == null || m_Wrapper.m_CarActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CarActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Horn.started += instance.OnHorn;
            @Horn.performed += instance.OnHorn;
            @Horn.canceled += instance.OnHorn;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(ICarActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Horn.started -= instance.OnHorn;
            @Horn.performed -= instance.OnHorn;
            @Horn.canceled -= instance.OnHorn;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICarActions instance)
        {
            foreach (var item in m_Wrapper.m_CarActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CarActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CarActions @Car => new CarActions(this);

    // Helicopter
    private readonly InputActionMap m_Helicopter;
    private List<IHelicopterActions> m_HelicopterActionsCallbackInterfaces = new List<IHelicopterActions>();
    private readonly InputAction m_Helicopter_Movement;
    private readonly InputAction m_Helicopter_Altitude;
    private readonly InputAction m_Helicopter_Interact;
    public struct HelicopterActions
    {
        private @InputActs m_Wrapper;
        public HelicopterActions(@InputActs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Helicopter_Movement;
        public InputAction @Altitude => m_Wrapper.m_Helicopter_Altitude;
        public InputAction @Interact => m_Wrapper.m_Helicopter_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Helicopter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HelicopterActions set) { return set.Get(); }
        public void AddCallbacks(IHelicopterActions instance)
        {
            if (instance == null || m_Wrapper.m_HelicopterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HelicopterActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Altitude.started += instance.OnAltitude;
            @Altitude.performed += instance.OnAltitude;
            @Altitude.canceled += instance.OnAltitude;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IHelicopterActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Altitude.started -= instance.OnAltitude;
            @Altitude.performed -= instance.OnAltitude;
            @Altitude.canceled -= instance.OnAltitude;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IHelicopterActions instance)
        {
            if (m_Wrapper.m_HelicopterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHelicopterActions instance)
        {
            foreach (var item in m_Wrapper.m_HelicopterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HelicopterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HelicopterActions @Helicopter => new HelicopterActions(this);

    // Plane
    private readonly InputActionMap m_Plane;
    private List<IPlaneActions> m_PlaneActionsCallbackInterfaces = new List<IPlaneActions>();
    private readonly InputAction m_Plane_Movement;
    private readonly InputAction m_Plane_Interact;
    public struct PlaneActions
    {
        private @InputActs m_Wrapper;
        public PlaneActions(@InputActs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Plane_Movement;
        public InputAction @Interact => m_Wrapper.m_Plane_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Plane; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlaneActions set) { return set.Get(); }
        public void AddCallbacks(IPlaneActions instance)
        {
            if (instance == null || m_Wrapper.m_PlaneActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlaneActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IPlaneActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IPlaneActions instance)
        {
            if (m_Wrapper.m_PlaneActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlaneActions instance)
        {
            foreach (var item in m_Wrapper.m_PlaneActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlaneActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlaneActions @Plane => new PlaneActions(this);
    public interface IPlayerActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnChoose(InputAction.CallbackContext context);
    }
    public interface ICarActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnHorn(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IHelicopterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAltitude(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IPlaneActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
