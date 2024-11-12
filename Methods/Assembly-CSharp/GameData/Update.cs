/*
Trash Spawning Mod with 'b'
*/

private void Update()
{
	if (base.isServer && !this.keyPress && Input.anyKeyDown)
	{
		this.keyPress = true;
	}
	if (Input.GetKeyDown(KeyCode.B))				// EDIT: press 'b' to spawn trash 
	{												//
		base.StartCoroutine(this.SpawnTrash());		//
	}												//
}