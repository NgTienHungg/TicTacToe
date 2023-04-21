using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public static class Extensions
{
    /// <summary>
    /// kiểm tra xem chuột có đang nằm trên UI hay không?
    /// UI có tick chọn RaycastTarget
    /// </summary>
    private static PointerEventData _eventDataCurrentPosition;
    private static List<RaycastResult> _results;
    public static bool IsOverUI() {
        _eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        _eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        _results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
        return _results.Count > 0;
    }

    /// <summary>
    /// lấy vị trí chuột theo đơn vị World
    /// </summary>
    private static Camera _mainCam;
    public static Vector3 MouseWorldPos() {
        if (_mainCam == null) {
            _mainCam = Camera.main;
        }
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = _mainCam.ScreenToWorldPoint(mousePos); // z = -10
        return new Vector3(mouseWorldPos.x, mouseWorldPos.y);
    }

    public static bool InRange(this int value, int min, int max) {
        return value >= min && value <= max;
    }

    public static int Rand(int min, int max) {
        return Random.Range(min, max + 1);
    }

    public static bool RandBool() {
        return Random.Range(0, 2) == 1;
    }

    public static void Fade(this Image image, float alpha) {
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }

    public static void Fade(this TextMeshProUGUI text, float alpha) {
        var color = text.color;
        color.a = alpha;
        text.color = color;
    }

    public static void Fade(this SpriteRenderer renderer, float alpha) {
        var color = renderer.color;
        color.a = alpha;
        renderer.color = color;
    }

    public static T Rand<T>(this IList<T> list) {
        if (list.Count == 0) {
            Debug.LogError("IList is empty");
        }
        return list[Random.Range(0, list.Count)];
    }

    public static T Rand<T>(this T[] array) {
        return array[Random.Range(0, array.Length)];
    }

    public static async void Wait(this MonoBehaviour mono, int milisec, UnityAction action) {
        await UniTask.Delay(milisec);
        action.Invoke();
    }

    public static int Millisecond(this float second) {
        return Mathf.FloorToInt(second * 1000);
    }

    public static int Int(this float x) {
        return Mathf.FloorToInt(x);
    }

    public static int Percent(this float x) {
        return (100 * x).Int();
    }

    public static int Int(this TextMeshProUGUI text) {
        return float.Parse(text.text).Int();
    }
}