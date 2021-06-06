using System;
using System.Collections;
using Common;
using UnityEngine;

using Math = Common.Math;

namespace LevelMenu
{
	public class CubeLocker : MonoBehaviour
	{
		private Material _material;

		private Color _originalBaseColor;
		private Color _originalEmissiveColor;

		private void Awake()
		{
			_material = GetComponent<Renderer>().material;

			_originalBaseColor = _material.GetBaseColor();
			_originalEmissiveColor = _material.GetEmissiveColor();
		}

		public void Lock()
		{
			_material.SetBaseColor(LevelMenuSettings.Instance.levelLocker.lockedBaseColor);
			_material.SetEmissiveColor(Color.black);
		}

		public void Unlock()
		{
			_material.SetBaseColor(_originalBaseColor);
			_material.SetEmissiveColor(_originalEmissiveColor);
		}

		public void ShowUnlockingAnimation(Action onFinish)
		{
			StartCoroutine(Routine());

			IEnumerator Routine()
			{
				var emissiveColorRoutine = Routines.MaterialEmissiveColorLerp(
					_material,
					LevelMenuSettings.Instance.levelLocker.unlockEmissiveColor,
					LevelMenuSettings.Instance.levelLocker.unlockDuration,
					Math.EaseInSine);

				yield return emissiveColorRoutine;

				_material.SetBaseColor(_originalBaseColor);
				onFinish?.Invoke();
			}
		}
	}
}