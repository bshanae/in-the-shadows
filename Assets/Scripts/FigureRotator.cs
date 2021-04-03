using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class FigureRotator : MonoBehaviour
{
	[SerializeField] private float sensitivity;

	private InputController _inputController;
	private bool            _isBusy;

	private void Awake()
	{
		_inputController = new InputController();
		_inputController.Figure.Click.performed += TryStartRotation;
		_inputController.Figure.Click.canceled  += CancelRotation;

		_isBusy = false;
	}

	private void OnEnable()
	{
		_inputController.Enable();
	}

	private void OnDisable()
	{
		_inputController.Disable();
	}

	private void TryStartRotation(InputAction.CallbackContext context)
	{
		if (!_isBusy)
		{
			_inputController.Figure.Rotation.performed += PerformRotation;
			_isBusy = true;
		}
	}

	private void CancelRotation(InputAction.CallbackContext context)
	{
		_inputController.Figure.Rotation.performed -= PerformRotation;
		_isBusy = false;
	}

	private void PerformRotation(InputAction.CallbackContext context)
	{
		var camera = Camera.main;
		var rotation = context.ReadValue<Vector2>() * sensitivity;

		Assert.IsNotNull(camera);

		var cameraTransform = camera.transform;
		
		transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
		transform.Rotate(cameraTransform.right, rotation.y, Space.World);
	}
}