using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float moveSensitivity = 3.0f;

    string RightStickHorizontalAxis = "RightStickHorizontal";
    string RightStickVerticalAxis = "RightStickVertical";

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) {
            RightStickHorizontalAxis = "RightStickHorizontalOSX";
            RightStickVerticalAxis = "RightStickVerticalOSX";
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float lh = Input.GetAxis(RightStickHorizontalAxis);
        float lv = Input.GetAxis(RightStickVerticalAxis);

        transform.position += new Vector3(lh, lv, 0f).normalized * moveSensitivity * Time.deltaTime;
    }
}
