using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class InputSwitcher : MonoBehaviour
	{
		[SerializeField] private new Camera camera;
		[SerializeField] private SceneDragger sceneDragger;

		private InputActions _inputActions;
		private CubeRotator _currentCubeRotator;

		private void Awake()
		{
			_inputActions = new InputActions();

			_inputActions.InputSwitching.Select.performed += SwitchPerformed;
			_inputActions.InputSwitching.Select.canceled += SwitchCanceled;
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
			var ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
			var giveInputToCube = false;

			if (Physics.Raycast(ray, out var hit))
			{
				_currentCubeRotator = hit.collider.gameObject.GetComponent<CubeRotator>();
				if (_currentCubeRotator != null)
					giveInputToCube = true;
			}

			if (giveInputToCube)
			{
				_currentCubeRotator.EnableInput();
				sceneDragger.DisableInput();
			}
			else
			{
				sceneDragger.EnableInput();	
			}
		}

		private void SwitchCanceled(InputAction.CallbackContext context)
		{
			if (_currentCubeRotator != null)
			{
				_currentCubeRotator.DisableInput();
				_currentCubeRotator = null;
			}

			sceneDragger.DisableInput();
		}
	}
}