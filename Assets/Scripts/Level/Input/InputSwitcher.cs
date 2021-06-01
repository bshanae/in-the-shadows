using Common;
using Common.Input;
using Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Level
{
	public class InputSwitcher : InputDelegate<InputActions>
	{
		[SerializeField] private FigureSetInput figureSetInput;

		private Camera _camera;

		private bool _shouldSelectSet;
		private FigureInput _focusedFigureInput;

		protected override void Awake()
		{
			base.Awake();

			_camera = Finder.FindCamera();

			inputActions.Switching.Selection.performed += OnSelectionPerformed;
			inputActions.Switching.Selection.canceled += OnSelectionCancelled;

			inputActions.Switching.SetSelection.performed += OnSetSelectionPerformed;
			inputActions.Switching.SetSelection.canceled += OnSetSelectionCancelled;
		}

		private void OnSelectionPerformed(InputAction.CallbackContext context)
		{
			if (_shouldSelectSet)
			{
				figureSetInput.HaveFocus = true;
				return;
			}

			var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
			if (!Physics.Raycast(ray, out var hit))
				return;

			var figureInput = hit.collider.gameObject.GetComponent<FigureInput>();
			if (figureInput == null)
				return;

			figureInput.HaveFocus = true;
			_focusedFigureInput = figureInput;
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