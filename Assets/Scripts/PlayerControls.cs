//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""P1"",
            ""id"": ""f16307b3-a17f-4c10-b0af-5b02ab024cf1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""36df65b3-2d1f-4892-96e8-c656e8b7ef0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0db44068-63e3-4618-bbeb-61b9f4e32d6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""242539bf-42c1-4fb7-8ec9-ee2f0ca86c1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7174187f-e371-41f3-9ea0-851081faf1f2"",
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
                    ""id"": ""256e7638-32bb-4f4f-b278-457818e3e4e7"",
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
                    ""id"": ""ddf0fd83-03db-4565-9877-21201c9734fb"",
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
                    ""id"": ""e2ec8e20-496b-4d22-98ee-024e9d5dee25"",
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
                    ""id"": ""0aabbb2c-a436-43e0-b3bc-e307d842f206"",
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
                    ""id"": ""476dcf2d-3f17-469d-af58-ada5a1564c8e"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a9cb154-81a6-4c39-b3d5-befcfff7587b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""P2"",
            ""id"": ""a98f9bcf-a7bf-4b8c-adfa-d674e2ca4b78"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""aedbdd84-5e3e-4c16-be03-c73aa19d53dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""884229f4-c1c0-4d0f-89c5-491f14c4fc40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b0ff1c4d-1249-4049-8a2a-e5d75279804f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b00f3a87-f03f-4f66-b35c-55b95d9c2ae1"",
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
                    ""id"": ""4ce46953-4e1d-4403-9ac4-7a4c6a78914d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c404696a-b664-4bcb-80ab-1ca91577d15e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f8ee08c0-41db-46e6-8330-b774efcb6723"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c36d250b-2c33-48f0-8d48-f71272ed240a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cf534c7a-de78-4766-be42-275b3972ccf1"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""535fee03-6c38-4fa0-93f5-f8ed3b49a02d"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // P1
        m_P1 = asset.FindActionMap("P1", throwIfNotFound: true);
        m_P1_Movement = m_P1.FindAction("Movement", throwIfNotFound: true);
        m_P1_Interact = m_P1.FindAction("Interact", throwIfNotFound: true);
        m_P1_Submit = m_P1.FindAction("Submit", throwIfNotFound: true);
        // P2
        m_P2 = asset.FindActionMap("P2", throwIfNotFound: true);
        m_P2_Movement = m_P2.FindAction("Movement", throwIfNotFound: true);
        m_P2_Submit = m_P2.FindAction("Submit", throwIfNotFound: true);
        m_P2_Interact = m_P2.FindAction("Interact", throwIfNotFound: true);
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

    // P1
    private readonly InputActionMap m_P1;
    private List<IP1Actions> m_P1ActionsCallbackInterfaces = new List<IP1Actions>();
    private readonly InputAction m_P1_Movement;
    private readonly InputAction m_P1_Interact;
    private readonly InputAction m_P1_Submit;
    public struct P1Actions
    {
        private @PlayerControls m_Wrapper;
        public P1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_P1_Movement;
        public InputAction @Interact => m_Wrapper.m_P1_Interact;
        public InputAction @Submit => m_Wrapper.m_P1_Submit;
        public InputActionMap Get() { return m_Wrapper.m_P1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P1Actions set) { return set.Get(); }
        public void AddCallbacks(IP1Actions instance)
        {
            if (instance == null || m_Wrapper.m_P1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_P1ActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Submit.started += instance.OnSubmit;
            @Submit.performed += instance.OnSubmit;
            @Submit.canceled += instance.OnSubmit;
        }

        private void UnregisterCallbacks(IP1Actions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Submit.started -= instance.OnSubmit;
            @Submit.performed -= instance.OnSubmit;
            @Submit.canceled -= instance.OnSubmit;
        }

        public void RemoveCallbacks(IP1Actions instance)
        {
            if (m_Wrapper.m_P1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IP1Actions instance)
        {
            foreach (var item in m_Wrapper.m_P1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_P1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public P1Actions @P1 => new P1Actions(this);

    // P2
    private readonly InputActionMap m_P2;
    private List<IP2Actions> m_P2ActionsCallbackInterfaces = new List<IP2Actions>();
    private readonly InputAction m_P2_Movement;
    private readonly InputAction m_P2_Submit;
    private readonly InputAction m_P2_Interact;
    public struct P2Actions
    {
        private @PlayerControls m_Wrapper;
        public P2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_P2_Movement;
        public InputAction @Submit => m_Wrapper.m_P2_Submit;
        public InputAction @Interact => m_Wrapper.m_P2_Interact;
        public InputActionMap Get() { return m_Wrapper.m_P2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P2Actions set) { return set.Get(); }
        public void AddCallbacks(IP2Actions instance)
        {
            if (instance == null || m_Wrapper.m_P2ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_P2ActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Submit.started += instance.OnSubmit;
            @Submit.performed += instance.OnSubmit;
            @Submit.canceled += instance.OnSubmit;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IP2Actions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Submit.started -= instance.OnSubmit;
            @Submit.performed -= instance.OnSubmit;
            @Submit.canceled -= instance.OnSubmit;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IP2Actions instance)
        {
            if (m_Wrapper.m_P2ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IP2Actions instance)
        {
            foreach (var item in m_Wrapper.m_P2ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_P2ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public P2Actions @P2 => new P2Actions(this);
    public interface IP1Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IP2Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
