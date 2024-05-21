using UnityEngine;

public class ExampleSaveable : MonoBehaviour, ISaveable {
    #region Save&Load
    private ExampleSaveableData data = new ExampleSaveableData();
    public void Register() {
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        svm.BeforeSave += Save;
        svm.AfterLoad += Load;
    }
    public void Load() {
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        data = svm.SaveData.ExampleSaveableData;
        LoadFields();
    }
    public void Save() {
        SaveFields();
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        svm.SaveData.ExampleSaveableData = data;
    }
    public void SaveFields() {
        data.Id = id;
        data.Health = health;
        data.Position = transform.position;
        data.Rotation = transform.eulerAngles;
    }
    public void LoadFields() {
        id = data.Id;
        health = data.Health;
        transform.position = data.Position;
        transform.eulerAngles = data.Rotation;
    }
    #endregion

    [SerializeField] private string id;
    [SerializeField] private int health;

    private void Start() {
        Register();
    }
}