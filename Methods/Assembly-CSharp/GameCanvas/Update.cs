/*
Testing notifications with 'k' bottom and 'l' top
*/

private void Update()
{
    if (Input.GetKeyDown(KeyCode.K))                // EDIT
    {                                               //
        CreateCanvasNotification("custom1");        // bottom
    }                                               //
    if (Input.GetKeyDown(KeyCode.L))                //
    {                                               //
        CreateImportantNotification("custom2");     // top
    }                                               //

    this.ShowInteractableInfo();
}