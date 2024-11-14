/*
Testing notifications with 'k' bottom and 'l' top
*/

private void Update()
{
    if (Input.GetKeyDown(KeyCode.K)) { CreateCanvasNotification("custom1"); }       // Edit
    if (Input.GetKeyDown(KeyCode.L)) { CreateImportantNotification("custom2"); }    //
    this.ShowInteractableInfo();
}