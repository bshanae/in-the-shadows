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
	}
}