using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class InputSwitcher : MonoBehaviour
	{
		[SerializeField] private SceneInput sceneInput;

		private Camera _camera;
		private InputActions _inputActions;
		private CubeInput _currentCubeInput;

		private void Awake()
		{
			_camera = Finder.FindCamera();

			_inputActions = new InputActions();

			_inputActions.Switching.Selection.performed += SwitchPerformed;
			_inputActions.Switching.Selection.canceled += SwitchCanceled;
		}

		private void OnEnable()
		{
			_inputActions.Enable();
		}

		private void OnDisable()
		{
			_inputActions.Disable();
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
				_currentCubeInput.EnableInput();
				sceneInput.DisableInput();
			}
			else
			{
				sceneInput.EnableInput();	
			}
		}

		private void SwitchCanceled(InputAction.CallbackContext context)
		{
			if (_currentCubeInput != null)
			{
				_currentCubeInput.DisableInput();
				_currentCubeInput = null;
			}

			sceneInput.DisableInput();
		}
	}
}