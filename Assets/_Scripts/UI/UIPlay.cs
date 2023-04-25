using UnityEngine;

public class UIPlay : MonoBehaviour
{
    public void OnPauseButton() {
        UIPause.Instance.Open();
    }
}