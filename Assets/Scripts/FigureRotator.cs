using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class FigureRotator : MonoBehaviour
{
	#region nested types

	private enum RotationMode
	{
		AccordingToCamera,
		AccordingToPlane
	}

	#endregion

	#region attributes

	[SerializeField] private float sensitivity;

	private InputController _inputController;
	private RotationMode    _rotationMode;
	private bool            _isBusy;

	#endregion

	#region engine event

	private void Awake()
	{
		_inputController = new InputController();

		_inputController.Figure.Select.performed += TryStartRotation;
		_inputController.Figure.Select.canceled += CancelRotation;

		_inputController.Figure.Mode.performed += context => _rotationMode = RotationMode.AccordingToPlane;
		_inputController.Figure.Mode.canceled += context => _rotationMode = RotationMode.AccordingToCamera;

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

	#endregion

	#region service methods

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
		var camera   = Camera.main;
		var rotation = context.ReadValue<Vector2>() * sensitivity;

		Assert.IsNotNull(camera);

		var cameraTransform = camera.transform;

		switch (_rotationMode)
		{
			case RotationMode.AccordingToCamera:
				transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
				transform.Rotate(cameraTransform.right, rotation.y, Space.World);
				break;

			case RotationMode.AccordingToPlane:
				transform.Rotate(new Vector3(1, 0, 0), -1f * rotation.y, Space.World);
				break;

			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	#endregion
}