/*
Trash Spawning Mod with 'b'
*/

private void Update()
{
	if (base.isServer && !this.keyPress && Input.anyKeyDown)
	{
		this.keyPress = true;
	}
	
	if (Input.GetKeyDown(KeyCode.B)) { base.StartCoroutine(this.SpawnTrash()); } // Edit: press B to spawn trash
}