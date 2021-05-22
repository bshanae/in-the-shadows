using Common;
using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class InputSwitcher : MonoBehaviour
	{
		[SerializeField] private SceneInput sceneInput;

		private Camera _camera;
		private InputActionsWrapper<InputActions> _inputActionsWrapper;
		private CubeInput _currentCubeInput;

		private void Awake()
		{
			_camera = Finder.FindCamera();

			_inputActionsWrapper = new InputActionsWrapper<InputActions>();

			_inputActionsWrapper.InputActions.Switching.Selection.performed += SwitchPerformed;
			_inputActionsWrapper.InputActions.Switching.Selection.canceled += SwitchCanceled;
		}

		private void Start()
		{
			_inputActionsWrapper.RegisterInInputManager();
		}

		private void OnEnable()
		{
			_inputActionsWrapper.InputActions.Enable();
		}

		private void OnDisable()
		{
			_inputActionsWrapper.InputActions.Disable();
		}

		private void SwitchPerformed(InputAction.CallbackContext context)
		{
			var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
			var giveInputToCube = false;

			if (Physics.Raycast(ray, out var hit))
			{
				_currentCubeInput = hit.collider.gameObject.GetComponent<CubeInput>();
				if (_currentCubeInput != null)
					giveInputToCube = true;
			}

			if (giveInputToCube)
			{
				_currentCubeInput.Selected();
				sceneInput.Unselected();
			}
			else
			{
				sceneInput.Selected();
			}
		}

		private void SwitchCanceled(InputAction.CallbackContext context)
		{
			if (_currentCubeInput != null)
			{
				_currentCubeInput.Unselected();
				_currentCubeInput = null;
			}

			sceneInput.Unselected();
		}
	}
}