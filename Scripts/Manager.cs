using UnityEngine;

public class Manager : MonoBehaviour {
    public virtual void Init() => Debug.Log($"{name} is initialized!");
}