using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class				FigureRotator : MonoBehaviour
{
	private InputController	_inputController;

	private void			Awake() 
	{
		_inputController = new InputController();
		_inputController.Figure.Rotation.performed += RotationPerformed;
	}

	private void			OnEnable()
	{
		_inputController.Enable();
	}

	private void			OnDisable()
	{
		_inputController.Disable();
	}

	private void			RotationPerformed(InputAction.CallbackContext context)
	{
		float rotation = context.ReadValue<float>() * 10;
		
		Debug.Log($"Rotation = {rotation}");
		transform.Rotate(rotation, 0f, 0f);
	}
}