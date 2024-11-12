# Features

- Flying (WASD, SPACE, R)
- Spawn Trash (B)
- Price Tooltip
- Custom Notifications (KL)
- Custom NPC dialogue

# Idea list

- Franchise points progressbar
- NPC rigidbody manipulation

# Instructions - COMING SOON

1. Open the game files. You can do this by right-clicking on your game in steam and clicking `manager > browse local files`. Go to the `Managed` folder.
2. Drag the files from my `EasyFiles` (GitHub) to the `Managed` folder (Game) to replace the games code with the modded code.
3. To delete the mod, in the `Managed` file delete the .dll files that you dragged in. Then go to steam and click `Manage > verify integrity of game files` on the game. This will reset the game code back to the original.

# Instructions for programmers

1. Install dnSpy [here](https://github.com/dnSpy/dnSpy).
2. Open the games code `C:\Program Files (x86)\Steam\steamapps\common\SupermarketTogether\SupermarketTogether_Data\Managed\Assembly-CSharp.dll` or click `Manage > Browse local files` in steam.
3. Replace the ingame methods with my GitHub methods.
4. Use the **Common Modding Errors** chapter in this README to fix errors for compiling.
5. Safe each module you edited.
6. Run the game.
7. To delete the mod, in the `Managed` file delete the .dll files you edited. Then go to steam and click `Manage > verify integrity of game files` on the game.

# Common Modding Errors

> 'IEnumerator': type used in a using statement must be implicitly converitble to 'System.IDisposable'

replace the IEnumerate with a foreach loop (ask ChatGPT for the code)

> 'Random' is an ambiguous reference between 'UnityEngine.Random' and 'System.Random'

replace 'Random' with 'UnityEngine.Random'

> 'Object' is an ambiguous reference between 'UnityEngine.Object' and 'Object'

replace 'Object' with 'UnityEngine.Object'

> The call is ambiguous between the following methods or properties: 'NetworkServer.Spawn(GameObject, GameObject)' and 'NetworkServer.Spawn(GameObject, NetworkConnection)'

replace 'NetworkServer.Spawn(gameObject, null);' with 'NetworkServer.Spawn(gameObject, (NetworkConnection)null);'

> 'GameData.SerializeSyncVars(NetworkWriter, bool)': cannot change access modifiers when overriding 'protected' inherited member 'NetworkBehaviour.SeriualizeSyncVars(NetworkWriter, bool)'

replace 'public' with 'protected'

> 'GameData.DeserializeSyncVars(NetworkReader, bool': cannot change access modifiers when overriding 'protected' inherited member 'NetworkBehaviour.DeserializeSyncVars(NetworkReader, bool)'

replace 'public' with 'protected'
