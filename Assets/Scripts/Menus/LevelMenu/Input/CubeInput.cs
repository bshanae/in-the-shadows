using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraToCubeMover))]
	[RequireComponent(typeof(CubeHighlighter))]
	public class CubeInput : MonoBehaviour
	{
		private InputActions _inputActions;

		private CameraToCubeMover _cameraToCubeMover;
		private CubeHighlighter _cubeHighlighter;

		private bool _didRotateLastTime;

		public bool IsEnabled => _inputActions.asset.enabled;

		private void Awake()
		{
			_inputActions = new InputActions();
			_inputActions.CubeControl.Rotation.performed += OnRotationPerformed;

			_cameraToCubeMover = GetComponent<CameraToCubeMover>();
			_cubeHighlighter = GetComponent<CubeHighlighter>();
		}

		private void OnDisable()
		{
			_inputActions.Disable();
		}

		public void EnableInput()
		{
			_didRotateLastTime = false;
			_inputActions.Enable();

			_cubeHighlighter.Highlight();
		}

		public void DisableInput()
		{
			_inputActions.Disable();

			// Mouse is released
			if (!_didRotateLastTime)
				TryMoveCameraToCube();

			_cubeHighlighter.Unhighlight();
		}

		private void OnRotationPerformed(InputAction.CallbackContext context)
		{
			var camera = Camera.main;
			Assert.IsNotNull(camera);

			var rotation = context.ReadValue<Vector2>() * Settings.Instance.cubeInput.sensitivity;
			if (Mathf.Approximately(rotation.x, 0) && Mathf.Approximately(rotation.y, 0))
				return;

			var cameraTransform = camera.transform;

			transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
			transform.Rotate(cameraTransform.right, rotation.y, Space.World);

			_didRotateLastTime = true;
		}

		private void TryMoveCameraToCube()
		{
			_cameraToCubeMover.TryMoveCameraToCube();
		}
	}
}