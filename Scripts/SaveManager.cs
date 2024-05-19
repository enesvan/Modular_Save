using System;
using System.IO;
using UnityEngine;

public class SaveManager : Manager {
    public Action OnSave;
    public Action OnLoad;

    public SaveData SaveData;
    private string dataPath;

    public override void AwakeManager() {
        base.AwakeManager();
        var sm = ServiceManager.Instance;
        sm.RegisterManager<SaveManager>(this);
    }

    public void SetPath(int id) => dataPath = Application.persistentDataPath + "/SaveData" + id + ".json";
    public bool IsValidPath(int id) => File.Exists(Application.persistentDataPath + "/SaveData" + id + ".json");

    [ContextMenu("Save")]
    public void Save() {
        OnSave?.Invoke();
        SaveToFile();
    }

    [ContextMenu("Load")]
    public void Load() {
        if (!File.Exists(dataPath)) return;
        LoadFromFile();
        OnLoad?.Invoke();
    }

    [ContextMenu("Delete")]
    public void Delete() {
        if (File.Exists(dataPath)) File.Delete(dataPath);
    }

    public void SaveToFile() {
        string json = JsonUtility.ToJson(SaveData, true);
        File.WriteAllText(dataPath, json);
    }

    public void LoadFromFile() {
        string json = File.ReadAllText(dataPath);
        SaveData = JsonUtility.FromJson<SaveData>(json);
    }
}