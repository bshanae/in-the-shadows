using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Level
{
	[RequireComponent(typeof(FigureRotator))]
	public class FigureInput : InputDelegate<InputActions>
	{
		private FigureRotator _figureRotator;
		private bool _useAlternativeRotation;

		protected override void Awake()
		{
			base.Awake();

			_figureRotator = GetComponent<FigureRotator>();

			inputActions.FigureControl.Rotation.performed += OnFigureRotated;
			inputActions.FigureControl.UseAlternativeRotation.performed += OnUseAlternativeRotationPerformed;
			inputActions.FigureControl.UseAlternativeRotation.canceled += OnUseAlternativeRotationCancelled;

		}

		private void OnFigureRotated(InputAction.CallbackContext context)
		{
			if (!HaveFocus)
				return;

			var mouseDelta = context.ReadValue<Vector2>();
			
			if (!_useAlternativeRotation)
				_figureRotator.Rotate(mouseDelta);
			else
				_figureRotator.RotateAlternatively(mouseDelta.y);
		}

		private void OnUseAlternativeRotationPerformed(InputAction.CallbackContext context)
		{
			_useAlternativeRotation = true;
		}

		private void OnUseAlternativeRotationCancelled(InputAction.CallbackContext context)
		{
			_useAlternativeRotation = false;
		}
	}
}