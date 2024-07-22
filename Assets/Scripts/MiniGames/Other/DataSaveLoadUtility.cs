using UnityEngine;

public static class DataSaveLoadUtility
{
    public static void SaveInt(string key, int value) => PlayerPrefs.SetInt(key, value);
    public static int GetInt(string key) => !PlayerPrefs.HasKey(key) ? 0 : PlayerPrefs.GetInt(key);
}
