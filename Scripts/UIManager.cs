using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager {
    [Header("Save Buttons")]
    [SerializeField] private Button saveButton0;
    [SerializeField] private Button saveButton1;
    [SerializeField] private Button saveButton2;
    [Header("Load Buttons")]
    [SerializeField] private Button loadButton0;
    [SerializeField] private Button loadButton1;
    [SerializeField] private Button loadButton2;

    public override void AwakeManager() {
        base.AwakeManager();
        var sm = ServiceManager.Instance;
        sm.RegisterManager<UIManager>(this);
    }

    private void OnEnable() {
        AddListeners();
    }

    private void OnDisable() {
        RemoveListeners();
    }

    private void Start() {
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        svm.AfterSave += SetLoadStates;
        SetLoadStates();
    }

    public void SetLoadStates() {
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        loadButton0.interactable = svm.IsValidPath(0);
        loadButton1.interactable = svm.IsValidPath(1);
        loadButton2.interactable = svm.IsValidPath(2);
    }

    private void AddListeners() {
        saveButton0.onClick.AddListener(() => SaveButtonOnClick(0));
        saveButton1.onClick.AddListener(() => SaveButtonOnClick(1));
        saveButton2.onClick.AddListener(() => SaveButtonOnClick(2));

        loadButton0.onClick.AddListener(() => LoadButtonOnClick(0));
        loadButton1.onClick.AddListener(() => LoadButtonOnClick(1));
        loadButton2.onClick.AddListener(() => LoadButtonOnClick(2));
    }

    private void RemoveListeners() {
        saveButton0.onClick.RemoveAllListeners();
        saveButton1.onClick.RemoveAllListeners();
        saveButton2.onClick.RemoveAllListeners();

        loadButton0.onClick.RemoveAllListeners();
        loadButton1.onClick.RemoveAllListeners();
        loadButton2.onClick.RemoveAllListeners();
    }

    public void SaveButtonOnClick(int id) {
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        svm.SetPath(id);
        svm.Save();
    }

    public void LoadButtonOnClick(int id) {
        var sm = ServiceManager.Instance;
        var svm = sm.GetManager<SaveManager>();
        svm.SetPath(id);
        svm.Load();
    }
}