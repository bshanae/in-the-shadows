using Common;
using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeRotator))]
	[RequireComponent(typeof(CameraToCubeMover))]
	[RequireComponent(typeof(CubeHighlighter))]
	[RequireComponent(typeof(CubeLevelOpener))]
	public class CubeInput : MonoBehaviour
	{
		private InputActionsWrapper<InputActions> _inputActionsWrapper;

		private CubeRotator _cubeRotator;
		private CameraToCubeMover _cameraToCubeMover;
		private CubeHighlighter _highlighter;
		private CubeLevelOpener _levelOpener;

		private Vector2 _totalRotationThisTime;

		public bool IsEnabled => _inputActionsWrapper.InputActions.asset.enabled;

		private void Awake()
		{
			_inputActionsWrapper = new InputActionsWrapper<InputActions>();
			_inputActionsWrapper.InputActions.CubeControl.Rotation.performed += OnRotationPerformed;

			_cubeRotator = GetComponent<CubeRotator>();
			_cameraToCubeMover = GetComponent<CameraToCubeMover>();
			_highlighter = GetComponent<CubeHighlighter>();
			_levelOpener = GetComponent<CubeLevelOpener>();
		}

		private void Start()
		{
			_inputActionsWrapper.RegisterInInputManager();
		}

		private void OnDisable()
		{
			_inputActionsWrapper.InputActions.Disable();
		}

		public void Selected()
		{
			_totalRotationThisTime = new Vector2();

			_inputActionsWrapper.InputActions.Enable();
			_highlighter.Highlight();
		}

		public void Unselected()
		{
			_inputActionsWrapper.InputActions.Disable();
			_highlighter.Unhighlight();
			
			var isRotationImportant = _cubeRotator.IsImportant(_totalRotationThisTime);
			var didMoveCamera = false;

			if (!isRotationImportant)
				didMoveCamera = TryMoveCameraToCube();

			if (!isRotationImportant && !didMoveCamera)
				_levelOpener.OpenLevel();
		}

		private void OnRotationPerformed(InputAction.CallbackContext context)
		{
			var rotation = context.ReadValue<Vector2>();

			_cubeRotator.TryRotateBy(rotation);
			_totalRotationThisTime += rotation;
		}

		private bool TryMoveCameraToCube()
		{
			return _cameraToCubeMover.TryMoveCameraToCube();
		}
	}
}