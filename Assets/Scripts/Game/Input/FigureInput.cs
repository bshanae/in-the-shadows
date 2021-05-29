using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	[RequireComponent(typeof(FigureRotator))]
	public class FigureInput : InputDelegate<InputActions>
	{
		private FigureRotator _figureRotator;

		protected override void Awake()
		{
			base.Awake();

			inputActions.FigureControl.Rotation.performed += OnFigureRotated;
			_figureRotator = GetComponent<FigureRotator>();
		}

		private void OnFigureRotated(InputAction.CallbackContext context)
		{
			if (!HaveFocus)
				return;

			_figureRotator.Rotate(context.ReadValue<Vector2>());
		}
	}
}