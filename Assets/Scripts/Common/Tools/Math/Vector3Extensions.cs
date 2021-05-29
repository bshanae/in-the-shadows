using UnityEngine;

namespace Common.Math
{
	public static class Vector3Extensions
	{
		public static Vector3 AddX(this Vector3 vector, float delta)
		{
			return new Vector3(vector.x + delta, vector.y, vector.z);
		}

		public static Vector3 AddY(this Vector3 vector, float delta)
		{
			return new Vector3(vector.x, vector.y + delta, vector.z);
		}

		public static Vector3 AddZ(this Vector3 vector, float delta)
		{
			return new Vector3(vector.x, vector.y, vector.z + delta);
		}
	}
}