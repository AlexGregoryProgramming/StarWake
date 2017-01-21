using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float movementSpeed = 1.5f;

    public float rotationSpeed = 3.0f;

    private float heading = 0.0f;

    string LeftStickHorizontalAxis = "P1LeftStickHorizontal";
    string LeftStickVerticalAxis = "P1LeftStickVertical";

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
		float lh = Input.GetAxis (LeftStickHorizontalAxis);
		float lv = Input.GetAxis (LeftStickVerticalAxis);
		heading = Mathf.Atan2 (-lh, lv);
		Quaternion targetRotation = Quaternion.Euler (0f, 0f, heading * Mathf.Rad2Deg);

        transform.forward = Vector3.up;
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float lh = Input.GetAxis(LeftStickHorizontalAxis);
        float lv = Input.GetAxis(LeftStickVerticalAxis);
        if ((lh != 0) || (lv != 0)) {
            heading = Mathf.Atan2(-lh, lv);
        }

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }
}
