// GENERATED AUTOMATICALLY FROM 'Assets/Controllers/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Figure"",
            ""id"": ""578ca402-445e-4cfa-a23d-e47fd1c28582"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""a48135e5-e2c7-4e25-9186-17af56176a51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""X-axis"",
                    ""id"": ""6d920bdd-5e54-4a91-97b0-068bf8d9c9f5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7e55833d-a444-4ab3-a3f0-9c8ed1c0a7b7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cddfbfb1-c0f0-4c22-9d2f-af1c5ebad16a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Figure
        m_Figure = asset.FindActionMap("Figure", throwIfNotFound: true);
        m_Figure_Rotation = m_Figure.FindAction("Rotation", throwIfNotFound: true);
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

    // Figure
    private readonly InputActionMap m_Figure;
    private IFigureActions m_FigureActionsCallbackInterface;
    private readonly InputAction m_Figure_Rotation;
    public struct FigureActions
    {
        private @InputController m_Wrapper;
        public FigureActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotation => m_Wrapper.m_Figure_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_Figure; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FigureActions set) { return set.Get(); }
        public void SetCallbacks(IFigureActions instance)
        {
            if (m_Wrapper.m_FigureActionsCallbackInterface != null)
            {
                @Rotation.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_FigureActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public FigureActions @Figure => new FigureActions(this);
    public interface IFigureActions
    {
        void OnRotation(InputAction.CallbackContext context);
    }
}
