/*
Custom head message. it ignores the parameters and uses the custom npcMessages only
*/

protected void UserCode_RPCNotificationAboveHead__String__String(string message1, string messageAddon)
{
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.messagePrefab, base.transform.position + Vector3.up * 1.8f, Quaternion.identity);
    
    string[] MOD_npcMessages = {													    // Edit: custom message
        "NPC custom message 1",											                //
        "NPC custom message 2",											                //
        "NPC custom message 3"													        //
    };																			        //
    string text = MOD_npcMessages[UnityEngine.Random.Range(0, MOD_npcMessages.Length)];	// pick random
    gameObject.GetComponent<TextMeshPro>().text = text;
    gameObject.SetActive(true);
}
