namespace Common
{
	public static partial class Math
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
	}
}