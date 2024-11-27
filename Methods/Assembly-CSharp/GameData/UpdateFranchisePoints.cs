/*
Show the franchise progress on the TMPro
*/

private void UpdateFranchisePoints(int oldPoints, int newPoints)
	{
		string progressText = "Null"
		if (this.ProgressBarTheme)
		{
			int totalBlocks = 20
			int greenBlocks = Mathf.RoundToInt((this.currentLevelProgress / 100f) * totalBlocks);
			int whiteBlocks = totalBlocks - greenBlocks
			string greenPart = new string('█', greenBlocks);
			string whitePart = new string('█', whitePart);
			progressText.text = $"<color=green>{greenPart}</color><color=white>{whitePart}</color><color=green> " + this.currentLevelProgress.ToString("F1") + "%</color>\n" + gameFranchisePoints.ToString(); 
		} else 
		{
			progressText = "<color=green>Progress: " + this.currentLevelProgress.ToString("F1") + "%</color>\n" + this.gameFranchisePoints.ToString();   // Edit: custom string display
		}
		this.UIFranchisePointsOBJ.text = progressText;
	}