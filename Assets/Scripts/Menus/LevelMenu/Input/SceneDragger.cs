using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	public class SceneDragger : MonoBehaviour
	{
		[SerializeField] private Light spotLight;

		[SerializeField] private float speed;
		[SerializeField] private float leftBound;
		[SerializeField] private float rightBound;
		
		private InputActions _inputActions;

		private void Awake()
		{
			_inputActions = new InputActions();
			_inputActions.SceneNavigation.Move.performed += OnSceneMoved;
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
			var camera = Camera.main;
			Assert.IsNotNull(camera);
			
			var shift = ComputeShift();

			camera.transform.Translate(shift, 0 , 0);
			spotLight.transform.Translate(shift, 0 , 0);
			
			float ComputeShift()
			{
				var mouseShift = context.ReadValue<Vector2>();

				var oldCameraPosition = camera.transform.position;
				var newCameraPosition = oldCameraPosition;

				newCameraPosition.x += -1f * mouseShift.x * speed;
				newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, leftBound, rightBound);

				return newCameraPosition.x - oldCameraPosition.x;
			}
		}
	}
}