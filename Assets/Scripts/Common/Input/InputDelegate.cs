using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
	public class InputDelegate : MonoBehaviour
	{
		private bool _haveFocus;

		public bool HaveFocus
		{
			set
			{
				_haveFocus = value;

				if (_haveFocus)
					ReceivedFocus();
				else
					LostFocus();
			}

			get => _haveFocus;
		}

		protected virtual void ReceivedFocus() {}
		protected virtual void LostFocus() {}
	}

	public class InputDelegate<T> : InputDelegate where T : IInputActionCollection, new()
	{
		protected T inputActions;

		protected virtual void Awake()
		{
			inputActions = new T();
		}

		private void OnEnable() => inputActions.Enable();
		private void OnDisable() => inputActions.Disable();
	}
}