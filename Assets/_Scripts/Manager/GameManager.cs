using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private void Start() {
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Application.lowMemory += () => GC.Collect();
    }
}