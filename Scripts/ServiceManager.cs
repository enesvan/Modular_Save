using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : MonoBehaviour {
    [SerializeField] private List<Manager> managerList; // add all managers to list at the scene
    private Dictionary<Type, object> managerDic = new Dictionary<Type, object>();

    public static ServiceManager Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        } else Destroy(this);
        AwakeManagers();
    }

    public void AwakeManagers() {
        foreach (var manager in managerList) manager.AwakeManager();
    }

    public void RegisterManager<T>(T manager) => managerDic[typeof(T)] = manager;
    public T GetManager<T>() => (T)managerDic[typeof(T)];
}