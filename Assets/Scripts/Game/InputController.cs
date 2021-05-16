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
                    ""type"": ""PassThrough"",
                    ""id"": ""a48135e5-e2c7-4e25-9186-17af56176a51"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mode"",
                    ""type"": ""Button"",
                    ""id"": ""25a6b781-3c7f-448a-b5dc-c1ebcbeec143"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""80a4e1be-0f5f-468b-a4f6-2b29cba3b245"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f0d5f6a-cf96-4fb8-912d-32d131651188"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4da350a-38b9-4966-8968-a81cd8cc4c39"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eed9b8d5-c12e-44ab-a3f0-ce02df78d437"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Figure
        m_Figure = asset.FindActionMap("Figure", throwIfNotFound: true);
        m_Figure_Rotation = m_Figure.FindAction("Rotation", throwIfNotFound: true);
        m_Figure_Mode = m_Figure.FindAction("Mode", throwIfNotFound: true);
        m_Figure_Select = m_Figure.FindAction("Select", throwIfNotFound: true);
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
    private readonly InputAction m_Figure_Mode;
    private readonly InputAction m_Figure_Select;
    public struct FigureActions
    {
        private @InputController m_Wrapper;
        public FigureActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotation => m_Wrapper.m_Figure_Rotation;
        public InputAction @Mode => m_Wrapper.m_Figure_Mode;
        public InputAction @Select => m_Wrapper.m_Figure_Select;
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
                @Mode.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnMode;
                @Mode.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnMode;
                @Mode.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnMode;
                @Select.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_FigureActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Mode.started += instance.OnMode;
                @Mode.performed += instance.OnMode;
                @Mode.canceled += instance.OnMode;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public FigureActions @Figure => new FigureActions(this);
    public interface IFigureActions
    {
        void OnRotation(InputAction.CallbackContext context);
        void OnMode(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
