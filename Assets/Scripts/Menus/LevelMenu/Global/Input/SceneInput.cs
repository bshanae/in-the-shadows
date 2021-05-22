using Common;
using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class SceneInput : MonoBehaviour
	{
		[SerializeField] private float speed;

		private CameraMover _cameraMover;
		private InputActionsWrapper<InputActions> _inputActionsWrapper;

		private void Awake()
		{
			_cameraMover = Finder.FindCamera().GetComponent<CameraMover>();

			_inputActionsWrapper = new InputActionsWrapper<InputActions>();
			_inputActionsWrapper.InputActions.SceneControl.Movement.performed += OnSceneMoved;
		}

		private void Start()
		{
			_inputActionsWrapper.RegisterInInputManager();
		}

		private void OnDisable()
		{
			_inputActionsWrapper.InputActions.Disable();
		}

		public void Selected()
		{
			_inputActionsWrapper.InputActions.Enable();
		}

		public void Unselected()
		{
			_inputActionsWrapper.InputActions.Disable();
		}

		private void OnSceneMoved(InputAction.CallbackContext context)
		{
			var mouseShift = context.ReadValue<Vector2>();
			var xShift = -1f * mouseShift.x * speed;

			_cameraMover.MoveBy(xShift);
		}
	}
}