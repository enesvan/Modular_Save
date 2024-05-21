using System;
using System.IO;
using UnityEngine;

public class SaveManager : Manager {
    public Action BeforeSave;
    public Action AfterSave;
    public Action AfterLoad;

    public SaveData SaveData;
    private string dataPath;

    [SerializeField] private bool useEncryption = false;
    private const string encryptKeyword = "467104098"; // Use any keyword

    public override void AwakeManager() {
        base.AwakeManager();
        var sm = ServiceManager.Instance;
        sm.RegisterManager<SaveManager>(this);
    }

    public void SetPath(int id) => dataPath = Application.persistentDataPath + "/SaveData" + id + ".json";
    public bool IsValidPath(int id) => File.Exists(Application.persistentDataPath + "/SaveData" + id + ".json");

    [ContextMenu("Save")]
    public void Save() {
        BeforeSave?.Invoke();
        SaveToFile();
        AfterSave?.Invoke();
    }

    [ContextMenu("Load")]
    public void Load() {
        if (!File.Exists(dataPath)) return;
        LoadFromFile();
        AfterLoad?.Invoke();
    }

    [ContextMenu("Delete")]
    public void Delete() {
        if (File.Exists(dataPath)) File.Delete(dataPath);
    }

    public void SaveToFile() {
        string json = JsonUtility.ToJson(SaveData, true);
        if (useEncryption) json = EncryptOrDecrypt(json);
        File.WriteAllText(dataPath, json);
    }

    public void LoadFromFile() {
        string json = File.ReadAllText(dataPath);
        if (useEncryption) json = EncryptOrDecrypt(json);
        SaveData = JsonUtility.FromJson<SaveData>(json);
    }

    private string EncryptOrDecrypt(string json) {
        string result = "";
        for (int i = 0; i < json.Length; i++) {
            result += (char)(json[i] ^ encryptKeyword[i % encryptKeyword.Length]);
        }
        return result;
    }
}