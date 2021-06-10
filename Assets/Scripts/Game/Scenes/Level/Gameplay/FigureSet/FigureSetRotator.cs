using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Level
{
	public class FigureSetRotator : MonoBehaviour
	{
		public void Rotate(float value)
		{
			var childrenRotations = _children.Select(child => child.rotation).ToArray();

			var rotation = value * LevelSettings.Instance.figureSetRotator.sensitivity;
			transform.Rotate(RotationAxis, -1f * rotation, Space.World);

			for (var i = 0; i < _children.Count; i++)
				_children[i].rotation = childrenRotations[i];
		}

		private List<Transform> _children;
		private Vector3? _rotationAxis;

		private Vector3 RotationAxis => _rotationAxis ??= GetRotationAxis();

		private void Awake()
		{
			_children = new List<Transform>();

			foreach (Transform child in transform)
				_children.Add(child);
		}

		private static Vector3 GetRotationAxis()
		{
			return LevelSettings.Instance.figureSetRotator.rotationMode switch
			{
				FigureSetRotationMode.None => new Vector3(0, 0, 0),
				FigureSetRotationMode.XZ => new Vector3(1, 0, 1),
				FigureSetRotationMode.YZ => new Vector3(0, 1, 1),
				_ => throw new ArgumentOutOfRangeException()
			};
		}
	}
}