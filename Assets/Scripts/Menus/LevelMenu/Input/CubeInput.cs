using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraToCubeMover))]
	public class CubeInput : MonoBehaviour
	{
		private InputActions _inputActions;
		private CameraToCubeMover _cameraToCubeMover;

		public bool IsEnabled => _inputActions.asset.enabled;

		private void Awake()
		{
			_inputActions = new InputActions();
			_inputActions.CubeControl.Rotation.performed += OnRotationPerformed;

			_cameraToCubeMover = GetComponent<CameraToCubeMover>();
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

			// Mouse is released
			TryMoveCameraToCube();
		}

		private void OnRotationPerformed(InputAction.CallbackContext context)
		{
			var camera = Camera.main;
			Assert.IsNotNull(camera);

			var rotation = context.ReadValue<Vector2>() * Settings.Instance.cubeInput.sensitivity;
			var cameraTransform = camera.transform;

			transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
			transform.Rotate(cameraTransform.right, rotation.y, Space.World);
		}

		private void TryMoveCameraToCube()
		{
			_cameraToCubeMover.TryMoveCameraToCube();
		}
	}
}