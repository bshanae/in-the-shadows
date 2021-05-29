using System.Collections;

namespace Common
{
	public interface SceneFader
	{
		public IEnumerator FadingInRoutine(float duration);
		public IEnumerator FadingOutRoutine(float duration);
	}
}