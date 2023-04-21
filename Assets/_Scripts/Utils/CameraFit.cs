using UnityEngine;

public class CameraFit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rink;

    private void Awake() {

        //FOR VERTICAL FIT
        Camera.main.orthographicSize = _rink.bounds.size.x * Screen.height / Screen.width * 0.5f;


        // FOR HORIZONTAL FIT
        //Camera.main.orthographicSize = _rink.bounds.size.y / 2;


        // FOR ENTIRE FIT
        //float screenRatio = (float)Screen.width / (float)Screen.height;
        //float targetRatio = _rink.bounds.size.x / _rink.bounds.size.y;

        //if (screenRatio >= targetRatio) {
        //    Camera.main.orthographicSize = _rink.bounds.size.y / 2;
        //}
        //else {
        //    float differenceInSize = targetRatio / screenRatio;
        //    Camera.main.orthographicSize = _rink.bounds.size.y / 2 * differenceInSize;
        //}
    }
}