using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class CubeRotator : MonoBehaviour
	{
		private InputActions _inputActions;

		public bool IsEnabled => _inputActions.asset.enabled;

		private void Awake()
		{
			_inputActions = new InputActions();
			_inputActions.SceneNavigation.Move.performed += OnCubeRotated;
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

		private void OnCubeRotated(InputAction.CallbackContext context)
		{
			var camera = Camera.main;
			Assert.IsNotNull(camera);

			var rotation = context.ReadValue<Vector2>() * CubeRotatorSettings.Instance.sensitivity;
			var cameraTransform = camera.transform;

			transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
			transform.Rotate(cameraTransform.right, rotation.y, Space.World);
		}
	}
}