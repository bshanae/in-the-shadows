using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeRotator))]
	[RequireComponent(typeof(CameraToCubeMover))]
	[RequireComponent(typeof(CubeHighlighter))]
	[RequireComponent(typeof(CubeLevelOpener))]
	public class CubeInput : InputDelegate<InputActions>
	{
		private CubeRotator _cubeRotator;
		private CameraToCubeMover _cameraToCubeMover;
		private CubeHighlighter _highlighter;
		private CubeLevelOpener _levelOpener;

		private Vector2 _totalRotationThisTime;

		protected override void Awake()
		{
			base.Awake();

			inputActions.CubeControl.Rotation.performed += OnRotationPerformed;

			_cubeRotator = GetComponent<CubeRotator>();
			_cameraToCubeMover = GetComponent<CameraToCubeMover>();
			_highlighter = GetComponent<CubeHighlighter>();
			_levelOpener = GetComponent<CubeLevelOpener>();
		}

		protected override void ReceivedFocus()
		{
			_totalRotationThisTime = new Vector2();
			_highlighter.Highlight();
		}

		protected override void LostFocus()
		{
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
			if (!HaveFocus)
				return;

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