using Common.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeRotator))]
	[RequireComponent(typeof(CubeCameraMover))]
	[RequireComponent(typeof(CubeHighlighter))]
	[RequireComponent(typeof(CubeLevelOpener))]
	public class CubeInput : InputDelegate<InputActions>
	{
		private CubeRotator _cubeRotator;
		private CubeCameraMover _cubeCameraMover;
		private CubeHighlighter _highlighter;
		private CubeLevelOpener _cubeLevelOpener;

		private Vector2 _totalRotationThisTime;

		protected override void Awake()
		{
			base.Awake();

			inputActions.CubeControl.Rotation.performed += OnRotationPerformed;

			_cubeRotator = GetComponent<CubeRotator>();
			_cubeCameraMover = GetComponent<CubeCameraMover>();
			_highlighter = GetComponent<CubeHighlighter>();
			_cubeLevelOpener = GetComponent<CubeLevelOpener>();
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
				_cubeLevelOpener.OpenLevel();
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
			return _cubeCameraMover.TryMoveCamera();
		}
	}
}