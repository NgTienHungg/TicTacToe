using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private float _timeChange = 0.6f;

    private TextMeshProUGUI _fpsText;
    private float _timer;
    private int _fps;

    private void Awake() {
        _fpsText = GetComponent<TextMeshProUGUI>();
        _fps = Mathf.FloorToInt(1f / Time.deltaTime);
        _fpsText.text = _fps.ToString();
    }

    private void Update() {
        if (Time.timeScale == 0) {
            _fpsText.text = "--";
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _timeChange) {
            _timer = 0f;
            _fps = Mathf.FloorToInt(1f / Time.deltaTime);
            _fpsText.text = _fps.ToString();

            if (_fps <= 30) {
                _fpsText.color = Color.red;
            }
            else if (_fps <= 50) {
                _fpsText.color = Color.yellow;
            }
            else {
                _fpsText.color = Color.green;
            }
        }
    }
}