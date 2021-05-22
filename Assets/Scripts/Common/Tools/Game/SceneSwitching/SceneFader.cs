using System;

namespace Common
{
	public interface SceneFader
	{
		public void FadeIn(Action onFinished);
		public void FadeOut(Action onFinished);
	}
}