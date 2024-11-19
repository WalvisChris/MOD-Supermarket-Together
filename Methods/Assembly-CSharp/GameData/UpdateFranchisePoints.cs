/*
Show the franchise progress on the TMPro
*/

private void UpdateFranchisePoints(int oldPoints, int newPoints)
	{
		string progressText = "<color=green>Progress: " + this.currentLevelProgress.ToString("F1") + "%</color>\n" + this.gameFranchisePoints.ToString();   // Edit: custom string display
		this.UIFranchisePointsOBJ.text = progressText;
	}