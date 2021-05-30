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

		private bool _shouldSelectSet;
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
			var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
			if (!Physics.Raycast(ray, out var hit))
				return;

			var figureInput = hit.collider.gameObject.GetComponent<FigureInput>();
			if (figureInput == null)
				return;

			if (_shouldSelectSet)
			{
				figureSetInput.HaveFocus = true;
			}
			else
			{
				figureInput.HaveFocus = true;
				_focusedFigureInput = figureInput;
			}
		}

		private void OnSelectionCancelled(InputAction.CallbackContext context)
		{
			figureSetInput.HaveFocus = false;

			if (_focusedFigureInput != null)
			{
				_focusedFigureInput.HaveFocus = false;
				_focusedFigureInput = null;
			}
		}

		private void OnSetSelectionPerformed(InputAction.CallbackContext context)
		{
			_shouldSelectSet = true;
		}

		private void OnSetSelectionCancelled(InputAction.CallbackContext context)
		{
			_shouldSelectSet = false;
		}
	}
}