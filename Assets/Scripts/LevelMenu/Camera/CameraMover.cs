using System;
using System.Collections;
using Common;
using UnityEngine;

namespace LevelMenu
{
	public class CameraMover : MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private float leftBound;
		[SerializeField] private float rightBound;

		public event Action Moved;

		public bool ShouldMoveTo(float newZ)
		{
			return Mathf.Abs(newZ - transform.position.z) > LevelMenuSettings.Instance.cameraMover.threshold;
		}

		public bool MoveTo(float newZ)
		{
			var offset = newZ - transform.position.z;

			if (!CanSetAt(newZ))
				return false;

			StopAllCoroutines();
			StartCoroutine(MovementRoutine(offset));

			return true;
		}

		public bool MoveImmediatelyTo(float newZ)
		{
			if (!CanSetAt(newZ))
				return false;

			gameObject.transform.position = gameObject.transform.position.SetZ(newZ);
			Moved?.Invoke();

			return true;
		}

		public bool MoveBy(float offset)
		{
			if (!CanSetAt(transform.position.z + offset))
				return false;

			transform.Translate(new Vector3(0, 0, offset), Space.World);
			Moved?.Invoke();
			return true;
		}

		private bool CanSetAt(float newZ)
		{
			return newZ >= leftBound && newZ <= rightBound;
		}

		private IEnumerator MovementRoutine(float offset)
		{
			var startPosition = gameObject.transform.position;
			var finishPosition = startPosition.AddZ(offset);

			var progress = 0f;

			do
			{
				progress += speed * Time.deltaTime;
				gameObject.transform.position = Vector3.Lerp(startPosition, finishPosition, progress);

				Moved?.Invoke();
				yield return null;
			} while (progress < 1f);
		}
	}
}