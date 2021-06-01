namespace Common.Input
{
	public static class InputTools
	{
		public static void EnableAllInput()
		{
			foreach (var inputDelegate in Finder.FindInputDelegates())
				inputDelegate.enabled = true;
		}

		public static void DisableAllInput()
		{
			foreach (var inputDelegate in Finder.FindInputDelegates())
				inputDelegate.enabled = false;
		}
	}
}