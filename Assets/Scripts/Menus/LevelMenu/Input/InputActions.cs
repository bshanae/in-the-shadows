// GENERATED AUTOMATICALLY FROM 'Assets/Profiles/Input/LevelMenu.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LevelMenu
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""LevelMenu"",
    ""maps"": [
        {
            ""name"": ""CubeControl"",
            ""id"": ""39c86813-daee-4bfc-91df-8638bd1a5228"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ffd7c01f-d776-44a8-a62a-52781bcc0514"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""c20c14aa-7a57-48c0-8dd4-8c3c41a1c9e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11f2b311-f018-4de7-9723-4da220615bb6"",
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
                    ""id"": ""36a6747f-a3ff-4535-9a16-3dc75082f83e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SceneControl"",
            ""id"": ""2ece32ad-a9f0-42a7-805c-7f428a5d4e8e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d75bec8-c8b3-41ef-8dd2-73bfd3544945"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ef74f30-20b6-4003-868c-2bd7853d44dd"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Switching"",
            ""id"": ""543f73be-fd3b-4f1f-a587-05b2b645703c"",
            ""actions"": [
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""bc639b2e-e5fd-4632-85ea-218d4d4f26ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed4d4475-f777-4619-82ac-5c445aad5751"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CubeControl
            m_CubeControl = asset.FindActionMap("CubeControl", throwIfNotFound: true);
            m_CubeControl_Rotation = m_CubeControl.FindAction("Rotation", throwIfNotFound: true);
            m_CubeControl_Selection = m_CubeControl.FindAction("Selection", throwIfNotFound: true);
            // SceneControl
            m_SceneControl = asset.FindActionMap("SceneControl", throwIfNotFound: true);
            m_SceneControl_Movement = m_SceneControl.FindAction("Movement", throwIfNotFound: true);
            // Switching
            m_Switching = asset.FindActionMap("Switching", throwIfNotFound: true);
            m_Switching_Selection = m_Switching.FindAction("Selection", throwIfNotFound: true);
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

        // CubeControl
        private readonly InputActionMap m_CubeControl;
        private ICubeControlActions m_CubeControlActionsCallbackInterface;
        private readonly InputAction m_CubeControl_Rotation;
        private readonly InputAction m_CubeControl_Selection;
        public struct CubeControlActions
        {
            private @InputActions m_Wrapper;
            public CubeControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotation => m_Wrapper.m_CubeControl_Rotation;
            public InputAction @Selection => m_Wrapper.m_CubeControl_Selection;
            public InputActionMap Get() { return m_Wrapper.m_CubeControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CubeControlActions set) { return set.Get(); }
            public void SetCallbacks(ICubeControlActions instance)
            {
                if (m_Wrapper.m_CubeControlActionsCallbackInterface != null)
                {
                    @Rotation.started -= m_Wrapper.m_CubeControlActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_CubeControlActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_CubeControlActionsCallbackInterface.OnRotation;
                    @Selection.started -= m_Wrapper.m_CubeControlActionsCallbackInterface.OnSelection;
                    @Selection.performed -= m_Wrapper.m_CubeControlActionsCallbackInterface.OnSelection;
                    @Selection.canceled -= m_Wrapper.m_CubeControlActionsCallbackInterface.OnSelection;
                }
                m_Wrapper.m_CubeControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                    @Selection.started += instance.OnSelection;
                    @Selection.performed += instance.OnSelection;
                    @Selection.canceled += instance.OnSelection;
                }
            }
        }
        public CubeControlActions @CubeControl => new CubeControlActions(this);

        // SceneControl
        private readonly InputActionMap m_SceneControl;
        private ISceneControlActions m_SceneControlActionsCallbackInterface;
        private readonly InputAction m_SceneControl_Movement;
        public struct SceneControlActions
        {
            private @InputActions m_Wrapper;
            public SceneControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_SceneControl_Movement;
            public InputActionMap Get() { return m_Wrapper.m_SceneControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SceneControlActions set) { return set.Get(); }
            public void SetCallbacks(ISceneControlActions instance)
            {
                if (m_Wrapper.m_SceneControlActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_SceneControlActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_SceneControlActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_SceneControlActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_SceneControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public SceneControlActions @SceneControl => new SceneControlActions(this);

        // Switching
        private readonly InputActionMap m_Switching;
        private ISwitchingActions m_SwitchingActionsCallbackInterface;
        private readonly InputAction m_Switching_Selection;
        public struct SwitchingActions
        {
            private @InputActions m_Wrapper;
            public SwitchingActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Selection => m_Wrapper.m_Switching_Selection;
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
                }
                m_Wrapper.m_SwitchingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Selection.started += instance.OnSelection;
                    @Selection.performed += instance.OnSelection;
                    @Selection.canceled += instance.OnSelection;
                }
            }
        }
        public SwitchingActions @Switching => new SwitchingActions(this);
        public interface ICubeControlActions
        {
            void OnRotation(InputAction.CallbackContext context);
            void OnSelection(InputAction.CallbackContext context);
        }
        public interface ISceneControlActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
        public interface ISwitchingActions
        {
            void OnSelection(InputAction.CallbackContext context);
        }
    }
}
