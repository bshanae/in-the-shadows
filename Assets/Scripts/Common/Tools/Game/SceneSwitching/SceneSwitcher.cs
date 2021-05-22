using Common.Input;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
	public class SceneSwitcher : MonoBehaviour
	{
		private SceneFader _sceneFader;
		private InputManager _inputManager;

		private void Awake()
		{
			_sceneFader = GetComponent<SceneFader>();

			if (_sceneFader == null)
				Debug.Log($"Scene fader is not used in {name}");

			_inputManager = Finder.FindInputManager();
		}

		private void Start()
		{
			_inputManager.BlockAll();
			_sceneFader?.FadeIn(() => _inputManager.UnblockAll());
		}
		
		[UsedImplicitly]
		public void SwitchToScene(string sceneName)
		{
			_sceneFader?.FadeOut(() => SceneManager.LoadScene(sceneName));
		}
	}
}