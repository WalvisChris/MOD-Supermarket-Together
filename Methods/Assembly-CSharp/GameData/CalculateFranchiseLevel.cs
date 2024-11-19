/*
Caculating Franchise progession
*/

private float currentLevelProgress;     // Edit: don't forget to add this

private void CalculateFranchiseLevel(int oldExp, int newExp)
	{
		int num = 0;
		int num2 = 1;
		while ((float)num2 < float.PositiveInfinity)
		{
			num += num2 * 100;
			if (num > newExp)
			{
				float num3 = (float)(newExp - (num - num2 * 100));
				float num4 = (float)(num2 * 100);
				this.currentLevelProgress = num3 / num4 * 100f;     // Edit: get %
				this.currentLevelXPRequired = num4;                 // temp
				this.gameFranchiseLevel = num2;
				this.UIFranchiseLevelOBJ.text = num2.ToString();
				this.franchiseProgressionImage.fillAmount = 0.2f + 0.62f * num3 / num4;
				return;
			}
			num2++;
		}
	}