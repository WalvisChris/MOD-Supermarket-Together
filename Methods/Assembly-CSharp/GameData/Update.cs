/*
Updating Franchise Progession indicator
Trash Spawning Mod with 'b'
*/

private void Update()
{
	if (base.isServer && !this.keyPress && Input.anyKeyDown)
	{
		this.keyPress = true;
	}
	this.UpdateFranchisePoints(0, this.gameFranchisePoints);						// Edit: make sure the % is updated every frame
	if (Input.GetKeyDown(KeyCode.B)) { base.StartCoroutine(this.SpawnTrash()); } 	// Edit: press B to spawn trash
}