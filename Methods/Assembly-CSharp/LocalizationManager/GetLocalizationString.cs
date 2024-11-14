/*
Enabeling custom notifications
*/

public string GetLocalizationString(string key)
{
    if (key == "custom1") { return "Canvas Notification"; }     // Edit: custom notifications override default messages
    if (key == "custom2") { return "Important Notification"; }  //
    string result = "";
    if (this.LocalizationDictionary.TryGetValue(key, out result))
    {
        return result;
    }
    return "LocError";
}
