using Level;
using UnityEngine;

namespace Common
{
	public static class MathTools
	{
		public static bool HaveReachedValue(float start, float finish, float current)
		{
			if (start > finish)
				return current <= finish;
			else if (start < finish)
				return current >= finish;
			else
				return true;
		}

		public static bool IsApproximatelyEqual(float a, float b, float threshold)
		{
			return Mathf.Abs(a - b) < threshold;
		}

		public static bool IsApproximatelyEqual(Vector3 a, Vector3 b, Vector3 threshold)
		{
			for (var i = 0; i < 3; i++)
			{
				if (!IsApproximatelyEqual(a[i], b[i], threshold[i]))
					return false;
			}

			return true;
		}
	}
}