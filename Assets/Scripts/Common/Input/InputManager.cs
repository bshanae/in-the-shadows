using System.Collections.Generic;
using UnityEngine;

namespace Common.Input
{
	public class InputManager : MonoBehaviour
	{
		private List<InputActionsWrapper> _inputActionsWrappers;

		private void Awake()
		{
			_inputActionsWrappers = new List<InputActionsWrapper>();
		}
		
		public void RegisterInputActionsWrapper(InputActionsWrapper inputActionsWrapper)
		{
			_inputActionsWrappers.Add(inputActionsWrapper);
		}
		
		public void BlockAll()
		{
			foreach (var inputActionsWrapper in _inputActionsWrappers)
				inputActionsWrapper.Block();
		}

		public void UnblockAll()
		{
			foreach (var inputActionsWrapper in _inputActionsWrappers)
				inputActionsWrapper.Unblock();
		}
	}
}