using System;
using System.IO;
using UnityEngine;

public class SaveManager : Manager {
    public Action OnSave;
    public Action OnLoad;

    public SaveData SaveData;
    private string dataLocation;

    private void Start() {
        LoadCheck();
    }

    public override void Init() {
        base.Init();
        var sm = ServiceManager.Instance;
        sm.RegisterManager<SaveManager>(this);
        dataLocation = Application.persistentDataPath + "/SaveData.json";
    }

    private void LoadCheck() {
        if (File.Exists(dataLocation)) Load();
    }

    [ContextMenu("Save")]
    public void Save() {
        OnSave?.Invoke();
        SaveToFile();
    }

    [ContextMenu("Load")]
    public void Load() {
        LoadFromFile();
        OnLoad?.Invoke();
    }

    [ContextMenu("Delete")]
    public void Delete() {
        if (File.Exists(dataLocation)) File.Delete(dataLocation);
    }

    public void SaveToFile() {
        string json = JsonUtility.ToJson(SaveData, true);
        File.WriteAllText(dataLocation, json);
    }

    public void LoadFromFile() {
        string json = File.ReadAllText(dataLocation);
        SaveData = JsonUtility.FromJson<SaveData>(json);
    }

    private void OnApplicationQuit() {
        Save(); // auto save at exit
    }
}