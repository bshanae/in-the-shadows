using Common.Input;
using Level;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public class FigureSetInput : InputDelegate<InputActions>
	{
		[SerializeField] private FigureSetRotator figureSetRotator;

		protected override void Awake()
		{
			base.Awake();
			inputActions.FigureSetControl.Rotation.performed += OnSetRotationPerformed;
		}

		private void OnSetRotationPerformed(InputAction.CallbackContext context)
		{
			if (!HaveFocus)
				return;

			var mouseDelta = context.ReadValue<Vector2>();
			figureSetRotator.Rotate(mouseDelta.x);
		}
	}
}