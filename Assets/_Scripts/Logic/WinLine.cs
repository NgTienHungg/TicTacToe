using DG.Tweening;
using UnityEngine;
using Cysharp.Threading.Tasks;

public enum ELine
{
    Horizontal,
    Vertical,
    Cross1,         // chéo xuôi
    Cross2          // chéo ngược
}

public class WinLine : MonoBehaviour
{
    #region Singleton
    public static WinLine Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    #endregion

    [Space]
    [SerializeField] private float _straightLength = 1.05f;
    [SerializeField] private float _diagonalLength = 1.45f;

    [Space]
    [SerializeField] private float _drawDuration = 0.5f;

    private float _targetLength;

    private void Start() {
        Reset();
    }

    public void Reset() {
        transform.localScale = Vector3.zero;
    }

    public void Prepare(ELine lineType, Vector3 linePos) {
        transform.position = linePos;

        switch (lineType) {
            case ELine.Horizontal:
                transform.localEulerAngles = Vector3.forward * 90f;
                _targetLength = _straightLength;
                break;
            case ELine.Vertical:
                _targetLength = _straightLength;
                transform.localEulerAngles = Vector3.forward * 0f;
                break;
            case ELine.Cross1:
                _targetLength = _diagonalLength;
                transform.localEulerAngles = Vector3.forward * 45f;
                break;
            case ELine.Cross2:
                _targetLength = _diagonalLength;
                transform.localEulerAngles = Vector3.forward * 135f;
                break;
        }
    }

    public async UniTask Draw() {
        transform.DOScale(_targetLength, _drawDuration);
        await UniTask.Delay(1000);
    }
}