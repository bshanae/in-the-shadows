using UnityEngine;

namespace Common
{
	public static class QuaternionExtensions
	{
		public static bool IsZero(this Quaternion quaternion)
		{
			var euler = quaternion.eulerAngles;
			return euler.x == 0 && euler.y == 0 && euler.z == 0;
		}
	}
}