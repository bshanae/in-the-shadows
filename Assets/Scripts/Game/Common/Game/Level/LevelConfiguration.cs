using UnityEngine;

namespace Common
{
	public enum FigureRotationMode
	{
		// H - Horizontal rotation
		// V - Vertical rotation
		// A - Alternative rotation

		None,
		H,
		HV,
		HVA
	}

	public enum FigureSetRotationMode
	{
		None,
		XZ,
		YZ
	}

	[CreateAssetMenu(fileName = "Level", menuName = "Level configuration", order = 1)]
	public class LevelConfiguration : ScriptableObject
	{
		[SerializeField] private int levelIndex;
		[SerializeField] private string levelName;
		[SerializeField] private string figurePrefab;
		[SerializeField] private FigureRotationMode figureRotationMode;
		[SerializeField] private float figureSolutionThreshold;
		[SerializeField] private FigureSetRotationMode figureSetRotationMode;
		[SerializeField] private float figureSetSolutionThreshold;

		public int LevelIndex => levelIndex;
		public string LevelName => levelName;
		public string FigurePrefab => figurePrefab;
		public FigureRotationMode FigureRotationMode => figureRotationMode;
		public float FigureSolutionThreshold => figureSolutionThreshold;
		public FigureSetRotationMode FigureSetRotationMode => figureSetRotationMode;
		public float FigureSetSolutionThreshold => figureSetSolutionThreshold;


		public bool IsOpened => PlayerProgress.Instance.CurrentLevelIndex >= levelIndex;
		public bool IsNew => PlayerProgress.Instance.NewLevelIndex == levelIndex;
	}
}