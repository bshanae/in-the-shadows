using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class SceneInput : MonoBehaviour
	{
		[SerializeField] private CameraMover cameraMover;
		[SerializeField] private float speed;

		private InputActions _inputActions;

		private void Awake()
		{
			_inputActions = new InputActions();
			_inputActions.SceneControl.Movement.performed += OnSceneMoved;
		}

		private void OnDisable()
		{
			_inputActions.Disable();
		}

		public void EnableInput()
		{
			_inputActions.Enable();
		}

		public void DisableInput()
		{
			_inputActions.Disable();
		}

		private void OnSceneMoved(InputAction.CallbackContext context)
		{
			var mouseShift = context.ReadValue<Vector2>();
			var xShift = -1f * mouseShift.x * speed;

			cameraMover.MoveBy(xShift);
		}
	}
}