using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Math;
using UnityEngine;

namespace LevelMenu
{
	public class CameraMover : MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private float leftBound;
		[SerializeField] private float rightBound;
		[SerializeField] private List<GameObject> accessories;

		private Coroutine _coroutine;

		public bool MoveTo(float newX)
		{
			if (!CanSetAtX(newX))
				return false;

			if (_coroutine == null)
			{
				var offset = newX - transform.position.x;
				_coroutine = StartCoroutine(MoveSelfAndAccessoriesByOffsetRoutine(offset));
			}

			return true;
		}

		public bool MoveBy(float offset)
		{
			var currentX = transform.position.x;

			if (!CanSetAtX(currentX + offset))
				return false;

			MoveSelfAndAccessoriesByOffset(offset);
			return true;
		}

		private bool CanSetAtX(float newX)
		{
			return newX >= leftBound && newX <= rightBound;
		}

		private void MoveSelfAndAccessoriesByOffset(float offset)
		{
			transform.Translate(offset, 0, 0);

			foreach (var accessory in accessories)
				accessory.transform.Translate(offset, 0, 0);
		}

		private IEnumerator MoveSelfAndAccessoriesByOffsetRoutine(float offset)
		{
			var targets = GetTargets(gameObject, accessories);
			var originalPositions = GetOriginalPositions(targets);

			var progress = 0f;

			do
			{
				progress += speed * Time.deltaTime;

				for (int i = 0; i < targets.Length; i++)
				{
					targets[i].position = Vector3.Lerp(
						originalPositions[i],
						originalPositions[i].AddX(offset),
						progress);
				}

				yield return null;
			} while (progress < 1f);

			_coroutine = null;

			static Transform[] GetTargets(GameObject self, IEnumerable<GameObject> accessories)
			{
				var targets = new List<Transform> {self.transform};
				targets.AddRange(accessories.Select(accessory => accessory.transform));

				return targets.ToArray();
			}

			static Vector3[] GetOriginalPositions(Transform[] targets)
			{
				return targets.Select(target => target.position).ToArray();
			}
		}
	}
}