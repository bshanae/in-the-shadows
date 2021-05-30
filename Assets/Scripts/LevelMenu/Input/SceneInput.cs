using Common;
using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class SceneInput : InputDelegate<InputActions>
	{
		[SerializeField] private float speed;

		private CameraMover _cameraMover;

		protected override void Awake()
		{
			base.Awake();
			
			_cameraMover = Finder.FindCamera().GetComponent<CameraMover>();
			inputActions.SceneControl.Movement.performed += OnSceneMoved;
		}

		private void OnSceneMoved(InputAction.CallbackContext context)
		{
			if (!HaveFocus)
				return;

			var mouseShift = context.ReadValue<Vector2>();
			var shift = -1f * mouseShift.x * speed;

			_cameraMover.MoveBy(shift);
		}
	}
}