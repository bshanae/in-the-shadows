// GENERATED AUTOMATICALLY FROM 'Assets/Profiles/Input/Level.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Level"",
    ""maps"": [
        {
            ""name"": ""FigureControl"",
            ""id"": ""8f465ec3-1981-459c-9e5e-2282ee03e5b0"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b4a0354-67ce-41ea-93fc-741dfb31a867"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseAlternativeRotation"",
                    ""type"": ""Button"",
                    ""id"": ""17ccd9be-1ce9-4408-a1e4-109f3eed0f86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dc5dd4de-3131-47a8-99bc-03de11387228"",
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
                    ""id"": ""a0808147-842c-4008-9bef-66eb41372e24"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseAlternativeRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FigureSetControl"",
            ""id"": ""7bf498c7-d69c-499b-9784-735b7d3f9536"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""be89c154-baab-4879-97f2-97928ce10142"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0121ed96-ab39-4448-ba5e-5448e3ed1687"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Switching"",
            ""id"": ""ac609a7a-e11b-490d-b49e-597b582b9c93"",
            ""actions"": [
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""1a87fc00-e0d5-4f53-9011-4edb19fdbd2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SetSelection"",
                    ""type"": ""Button"",
                    ""id"": ""e67eb007-c8e5-410b-a9fd-42e101dcc70b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""daa29731-1c44-48d2-b137-a4316c87cccd"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2cba063-469d-43b0-8b7c-23d19905b158"",
                    ""path"": ""<Keyboard>/leftMeta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // FigureControl
            m_FigureControl = asset.FindActionMap("FigureControl", throwIfNotFound: true);
            m_FigureControl_Rotation = m_FigureControl.FindAction("Rotation", throwIfNotFound: true);
            m_FigureControl_UseAlternativeRotation = m_FigureControl.FindAction("UseAlternativeRotation", throwIfNotFound: true);
            // FigureSetControl
            m_FigureSetControl = asset.FindActionMap("FigureSetControl", throwIfNotFound: true);
            m_FigureSetControl_Rotation = m_FigureSetControl.FindAction("Rotation", throwIfNotFound: true);
            // Switching
            m_Switching = asset.FindActionMap("Switching", throwIfNotFound: true);
            m_Switching_Selection = m_Switching.FindAction("Selection", throwIfNotFound: true);
            m_Switching_SetSelection = m_Switching.FindAction("SetSelection", throwIfNotFound: true);
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

        // FigureControl
        private readonly InputActionMap m_FigureControl;
        private IFigureControlActions m_FigureControlActionsCallbackInterface;
        private readonly InputAction m_FigureControl_Rotation;
        private readonly InputAction m_FigureControl_UseAlternativeRotation;
        public struct FigureControlActions
        {
            private @InputActions m_Wrapper;
            public FigureControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotation => m_Wrapper.m_FigureControl_Rotation;
            public InputAction @UseAlternativeRotation => m_Wrapper.m_FigureControl_UseAlternativeRotation;
            public InputActionMap Get() { return m_Wrapper.m_FigureControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(FigureControlActions set) { return set.Get(); }
            public void SetCallbacks(IFigureControlActions instance)
            {
                if (m_Wrapper.m_FigureControlActionsCallbackInterface != null)
                {
                    @Rotation.started -= m_Wrapper.m_FigureControlActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_FigureControlActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_FigureControlActionsCallbackInterface.OnRotation;
                    @UseAlternativeRotation.started -= m_Wrapper.m_FigureControlActionsCallbackInterface.OnUseAlternativeRotation;
                    @UseAlternativeRotation.performed -= m_Wrapper.m_FigureControlActionsCallbackInterface.OnUseAlternativeRotation;
                    @UseAlternativeRotation.canceled -= m_Wrapper.m_FigureControlActionsCallbackInterface.OnUseAlternativeRotation;
                }
                m_Wrapper.m_FigureControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                    @UseAlternativeRotation.started += instance.OnUseAlternativeRotation;
                    @UseAlternativeRotation.performed += instance.OnUseAlternativeRotation;
                    @UseAlternativeRotation.canceled += instance.OnUseAlternativeRotation;
                }
            }
        }
        public FigureControlActions @FigureControl => new FigureControlActions(this);

        // FigureSetControl
        private readonly InputActionMap m_FigureSetControl;
        private IFigureSetControlActions m_FigureSetControlActionsCallbackInterface;
        private readonly InputAction m_FigureSetControl_Rotation;
        public struct FigureSetControlActions
        {
            private @InputActions m_Wrapper;
            public FigureSetControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotation => m_Wrapper.m_FigureSetControl_Rotation;
            public InputActionMap Get() { return m_Wrapper.m_FigureSetControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(FigureSetControlActions set) { return set.Get(); }
            public void SetCallbacks(IFigureSetControlActions instance)
            {
                if (m_Wrapper.m_FigureSetControlActionsCallbackInterface != null)
                {
                    @Rotation.started -= m_Wrapper.m_FigureSetControlActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_FigureSetControlActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_FigureSetControlActionsCallbackInterface.OnRotation;
                }
                m_Wrapper.m_FigureSetControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                }
            }
        }
        public FigureSetControlActions @FigureSetControl => new FigureSetControlActions(this);

        // Switching
        private readonly InputActionMap m_Switching;
        private ISwitchingActions m_SwitchingActionsCallbackInterface;
        private readonly InputAction m_Switching_Selection;
        private readonly InputAction m_Switching_SetSelection;
        public struct SwitchingActions
        {
            private @InputActions m_Wrapper;
            public SwitchingActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Selection => m_Wrapper.m_Switching_Selection;
            public InputAction @SetSelection => m_Wrapper.m_Switching_SetSelection;
            public InputActionMap Get() { return m_Wrapper.m_Switching; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SwitchingActions set) { return set.Get(); }
            public void SetCallbacks(ISwitchingActions instance)
            {
                if (m_Wrapper.m_SwitchingActionsCallbackInterface != null)
                {
                    @Selection.started -= m_Wrapper.m_SwitchingActionsCallbackInterface.OnSelection;
                    @Selection.performed -= m_Wrapper.m_SwitchingActionsCallbackInterface.OnSelection;
                    @Selection.canceled -= m_Wrapper.m_SwitchingActionsCallbackInterface.OnSelection;
                    @SetSelection.started -= m_Wrapper.m_SwitchingActionsCallbackInterface.OnSetSelection;
                    @SetSelection.performed -= m_Wrapper.m_SwitchingActionsCallbackInterface.OnSetSelection;
                    @SetSelection.canceled -= m_Wrapper.m_SwitchingActionsCallbackInterface.OnSetSelection;
                }
                m_Wrapper.m_SwitchingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Selection.started += instance.OnSelection;
                    @Selection.performed += instance.OnSelection;
                    @Selection.canceled += instance.OnSelection;
                    @SetSelection.started += instance.OnSetSelection;
                    @SetSelection.performed += instance.OnSetSelection;
                    @SetSelection.canceled += instance.OnSetSelection;
                }
            }
        }
        public SwitchingActions @Switching => new SwitchingActions(this);
        public interface IFigureControlActions
        {
            void OnRotation(InputAction.CallbackContext context);
            void OnUseAlternativeRotation(InputAction.CallbackContext context);
        }
        public interface IFigureSetControlActions
        {
            void OnRotation(InputAction.CallbackContext context);
        }
        public interface ISwitchingActions
        {
            void OnSelection(InputAction.CallbackContext context);
            void OnSetSelection(InputAction.CallbackContext context);
        }
    }
}
