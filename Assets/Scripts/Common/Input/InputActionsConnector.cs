using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
	public class InputActionsConnector
	{
		private readonly InputActionAsset _inputActionsAsset;

		public bool IsEnabled => _inputActionsAsset.enabled;

		public InputActionsConnector(IInputActionCollection inputActionCollection)
		{
			_inputActionsAsset = GetInputActionsAssetViaReflection(inputActionCollection);
		}

		public void Enable()
		{
			_inputActionsAsset.Enable();
		}

		public void Disable()
		{
			_inputActionsAsset.Disable();
		}

		private InputActionAsset GetInputActionsAssetViaReflection(IInputActionCollection inputActionCollection)
		{
			try

			{
				var type = inputActionCollection.GetType();
				var property = type.GetProperty("asset");
				var value = (InputActionAsset) property.GetValue(inputActionCollection, null);

				return value;
			}
			catch (Exception exception)
			{
				Debug.LogError($"Couldn't get input actions asset : {exception}");
				return null;
			}
		}
	}
}