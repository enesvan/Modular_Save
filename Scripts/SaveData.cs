using System;
using UnityEngine;

[Serializable]
public class SaveData {
    public ExampleSaveableData ExampleSaveableData;
    // Custom Datas
}

[Serializable]
public class ExampleSaveableData {
    public string Id;
    public int Health;
    public Vector3 Position;
    public Vector3 Rotation;
}