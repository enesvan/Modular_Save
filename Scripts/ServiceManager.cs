using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : MonoBehaviour {
    [SerializeField] private List<Manager> managerList; // add all managers to list at the scene
    private Dictionary<Type, object> managerDic;

    public static ServiceManager Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        } else Destroy(this);
        Init();
    }

    public void Init() {
        managerDic = new Dictionary<Type, object>();
        foreach (var manager in managerList) manager.Init();
    }

    public void RegisterManager<T>(T manager) => managerDic[typeof(T)] = manager;
    public T GetManager<T>() => (T)managerDic[typeof(T)];
}