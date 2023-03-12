#nullable enable

using UnityEngine;

[System.Serializable]
public struct TmjProperty
{
    public string name;
    public string value;
}

[System.Serializable]
public struct TmjLayer
{
    public string name;
    public byte[] data;
    public TmjProperty[]? properties;
}

[System.Serializable]
public struct TmjLevel
{
    public uint width;
    public uint height;
    public TmjLayer[] layers;

    public static TmjLevel Load(string name)
    {
        return JsonUtility.FromJson<TmjLevel>(Resources.Load<TextAsset>($"Levels/{name}").text);
    }
}
