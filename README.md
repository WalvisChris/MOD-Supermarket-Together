# OUTDATED!

**The mod is outdated due to the new update. I will be working on an updated version. Feel free to share mod ideas!**

# Features

- Flying (WASD, SPACE, R)
- Spawn Trash (B)
- Pricegun Tooltip
- Custom Notifications (KL)
- Custom NPC messages
- Franchise points progressbar (P)

# Idea list

- Faster Cleaning Robots
- NPC rigidbody manipulation
- Custom broom hitting
- NPC conversation (+ reputation)
- RGB Lights

# Instructions

1. Open your Supermarket Together game files. You can do this by right-clicking on your game in steam and clicking `manage > browse local files`. Go to the `Managed` folder.
2. Download the files from my `dll Files` folder (GitHub).
3. In `dll Files` choose the folder with the mods you want and download the .dll files inside.
4. Drag the files from my `dll Files` (GitHub) to the `Managed` folder (Game) to replace the game code with the modded code.
5. To remove the mods, in the `Managed` file delete the .dll files that you dragged in from my mod. Then go to steam and click `Manage > verify integrity of game files` on the game. This will reset the game code back to the original.

# Images

Pricegun tooltip:
![skriensjot](https://github.com/user-attachments/assets/eb816d84-2499-45d8-bfbb-79bd86790f10)

Franchise progression indicator:
![skriensjot2](https://github.com/user-attachments/assets/0d25bf6f-1d30-4025-8997-56b00070b5b7)

# Instructions for programmers

1. Install dnSpy [here](https://github.com/dnSpy/dnSpy).
2. Open the games code `C:\Program Files (x86)\Steam\steamapps\common\Supermarket Together\Supermarket Together_Data\Managed\Assembly-CSharp.dll` or click `Manage > Browse local files` in steam.
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
