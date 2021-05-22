using System;
using UnityEngine.InputSystem;

namespace Common.Input
{
	public interface InputActionsWrapper
	{
		public bool IsBlocked { get; }

		public void Block();
		public void Unblock();
	}

	public class InputActionsWrapper<T> : InputActionsWrapper where T : IInputActionCollection, new()
	{
		public T InputActions { get; }
		public bool IsBlocked { get; private set; }

		private readonly InputActionsConnector _inputActionsConnector;
		private bool? _stateBeforeBlock;
		
		public InputActionsWrapper()
		{
			InputActions = new T();
			_inputActionsConnector = new InputActionsConnector(InputActions);
		}

		public void RegisterInInputManager()
		{
			Finder.FindInputManager().RegisterInputActionsWrapper(this);
		}

		public void Block()
		{
			_stateBeforeBlock = _inputActionsConnector.IsEnabled;
			IsBlocked = true;

			InputActions.Disable();
		}

		public void Unblock()
		{
			IsBlocked = false;

			if (_stateBeforeBlock is true)
				InputActions.Enable();

			_stateBeforeBlock = null;
		}
	}
}