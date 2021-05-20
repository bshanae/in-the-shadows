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
            ""name"": ""CubeRotation"",
            ""id"": ""39c86813-daee-4bfc-91df-8638bd1a5228"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ffd7c01f-d776-44a8-a62a-52781bcc0514"",
                    ""expectedControlType"": ""Vector2"",
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
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SceneNavigation"",
            ""id"": ""2ece32ad-a9f0-42a7-805c-7f428a5d4e8e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
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
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InputSwitching"",
            ""id"": ""543f73be-fd3b-4f1f-a587-05b2b645703c"",
            ""actions"": [
                {
                    ""name"": ""Select"",
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
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CubeRotation
            m_CubeRotation = asset.FindActionMap("CubeRotation", throwIfNotFound: true);
            m_CubeRotation_Rotate = m_CubeRotation.FindAction("Rotate", throwIfNotFound: true);
            // SceneNavigation
            m_SceneNavigation = asset.FindActionMap("SceneNavigation", throwIfNotFound: true);
            m_SceneNavigation_Move = m_SceneNavigation.FindAction("Move", throwIfNotFound: true);
            // InputSwitching
            m_InputSwitching = asset.FindActionMap("InputSwitching", throwIfNotFound: true);
            m_InputSwitching_Select = m_InputSwitching.FindAction("Select", throwIfNotFound: true);
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

        // CubeRotation
        private readonly InputActionMap m_CubeRotation;
        private ICubeRotationActions m_CubeRotationActionsCallbackInterface;
        private readonly InputAction m_CubeRotation_Rotate;
        public struct CubeRotationActions
        {
            private @InputActions m_Wrapper;
            public CubeRotationActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotate => m_Wrapper.m_CubeRotation_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_CubeRotation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CubeRotationActions set) { return set.Get(); }
            public void SetCallbacks(ICubeRotationActions instance)
            {
                if (m_Wrapper.m_CubeRotationActionsCallbackInterface != null)
                {
                    @Rotate.started -= m_Wrapper.m_CubeRotationActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_CubeRotationActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_CubeRotationActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_CubeRotationActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public CubeRotationActions @CubeRotation => new CubeRotationActions(this);

        // SceneNavigation
        private readonly InputActionMap m_SceneNavigation;
        private ISceneNavigationActions m_SceneNavigationActionsCallbackInterface;
        private readonly InputAction m_SceneNavigation_Move;
        public struct SceneNavigationActions
        {
            private @InputActions m_Wrapper;
            public SceneNavigationActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_SceneNavigation_Move;
            public InputActionMap Get() { return m_Wrapper.m_SceneNavigation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SceneNavigationActions set) { return set.Get(); }
            public void SetCallbacks(ISceneNavigationActions instance)
            {
                if (m_Wrapper.m_SceneNavigationActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_SceneNavigationActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_SceneNavigationActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_SceneNavigationActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_SceneNavigationActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public SceneNavigationActions @SceneNavigation => new SceneNavigationActions(this);

        // InputSwitching
        private readonly InputActionMap m_InputSwitching;
        private IInputSwitchingActions m_InputSwitchingActionsCallbackInterface;
        private readonly InputAction m_InputSwitching_Select;
        public struct InputSwitchingActions
        {
            private @InputActions m_Wrapper;
            public InputSwitchingActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Select => m_Wrapper.m_InputSwitching_Select;
            public InputActionMap Get() { return m_Wrapper.m_InputSwitching; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InputSwitchingActions set) { return set.Get(); }
            public void SetCallbacks(IInputSwitchingActions instance)
            {
                if (m_Wrapper.m_InputSwitchingActionsCallbackInterface != null)
                {
                    @Select.started -= m_Wrapper.m_InputSwitchingActionsCallbackInterface.OnSelect;
                    @Select.performed -= m_Wrapper.m_InputSwitchingActionsCallbackInterface.OnSelect;
                    @Select.canceled -= m_Wrapper.m_InputSwitchingActionsCallbackInterface.OnSelect;
                }
                m_Wrapper.m_InputSwitchingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Select.started += instance.OnSelect;
                    @Select.performed += instance.OnSelect;
                    @Select.canceled += instance.OnSelect;
                }
            }
        }
        public InputSwitchingActions @InputSwitching => new InputSwitchingActions(this);
        public interface ICubeRotationActions
        {
            void OnRotate(InputAction.CallbackContext context);
        }
        public interface ISceneNavigationActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
        public interface IInputSwitchingActions
        {
            void OnSelect(InputAction.CallbackContext context);
        }
    }
}
