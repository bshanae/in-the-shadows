using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level
{
	public class FigureSetRotator : MonoBehaviour
	{
		private List<Transform> _children;

		private void Awake()
		{
			_children = new List<Transform>();

			foreach (Transform child in transform)
				_children.Add(child);
		}

		public void Rotate(float value)
		{
			var childrenRotations = _children.Select(child => child.rotation).ToArray();

			var rotation = value * LevelSettings.Instance.figureSetRotator.sensitivity;
			transform.Rotate(new Vector3(0, 1, 0), -1f * rotation, Space.World);

			for (var i = 0; i < _children.Count; i++)
				_children[i].rotation = childrenRotations[i];
		}
	}
}