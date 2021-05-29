using Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public class InputSwitcher : MonoBehaviour
	{
		[SerializeField] private FigureSetInput figureSetInput;

		private Camera _camera;
		private InputActions _inputActions;

		private bool _shouldSetSelected;
		private FigureInput _focusedFigureInput;

		private void Awake()
		{
			_camera = Finder.FindCamera();

			_inputActions = new InputActions();

			_inputActions.Switching.Selection.performed += OnSelectionPerformed;
			_inputActions.Switching.Selection.canceled += OnSelectionCancelled;

			_inputActions.Switching.SetSelection.performed += OnSetSelectionPerformed;
			_inputActions.Switching.SetSelection.canceled += OnSetSelectionCancelled;
		}

		private void OnEnable() => _inputActions.Enable();
		private void OnDisable() => _inputActions.Disable();

		private void OnSelectionPerformed(InputAction.CallbackContext context)
		{
			if (_shouldSetSelected)
				figureSetInput.HasFocus = true;

			var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
			if (Physics.Raycast(ray, out var hit))
			{
				var figureInput = hit.collider.gameObject.GetComponent<FigureInput>();
				if (figureInput != null)
				{
					figureInput.HaveFocus = true;
					_focusedFigureInput = figureInput;
				}
			}
		}

		private void OnSelectionCancelled(InputAction.CallbackContext context)
		{
			if (_shouldSetSelected)
			{
				figureSetInput.HasFocus = false;
			}
			else if (_focusedFigureInput != null)
			{
				_focusedFigureInput.HaveFocus = false;
				_focusedFigureInput = null;
			}
		}

		private void OnSetSelectionPerformed(InputAction.CallbackContext context)
		{
			_shouldSetSelected = true;
		}

		private void OnSetSelectionCancelled(InputAction.CallbackContext context)
		{
			_shouldSetSelected = false;
		}
	}
}