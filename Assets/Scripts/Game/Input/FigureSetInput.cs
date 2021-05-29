using UnityEngine;

namespace Game
{
	public class FigureSetInput : MonoBehaviour
	{
		private InputActions _inputActions;

		public bool HasFocus
		{
			set => FocusChanged(value);
		}		
		
		private void Awake()
		{
			_inputActions = new InputActions();
		}

		private void OnEnable() => _inputActions.Enable();
		private void OnDisable() => _inputActions.Disable();

		private void FocusChanged(bool hasFocus)
		{
			if (hasFocus)
				_inputActions.Enable();
			else
				_inputActions.Disable();
		}
	}
}