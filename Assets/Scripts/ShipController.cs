using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float movementSpeed = 1.5f;
    public float rotationSpeed = 3.0f;

    internal float heading = 0.0f;

    string LeftStickHorizontalAxis = "P1LeftStickHorizontal";
    string LeftStickVerticalAxis = "P1LeftStickVertical";

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ShipColor shipColor = GetComponent<ShipColor>();
        if (shipColor != null)
		{
            int playerNumber = shipColor.playerNumber;
            LeftStickHorizontalAxis = string.Format("P{0}LeftStickHorizontal", playerNumber);
            LeftStickVerticalAxis = string.Format("P{0}LeftStickVertical", playerNumber);
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float lh = Input.GetAxis (LeftStickHorizontalAxis);
        float lv = Input.GetAxis (LeftStickVerticalAxis);
        if ((lh != 0) || (lv != 0)) {
            heading = Mathf.Atan2 (-lh, lv);
        }

        Quaternion targetRotation = Quaternion.Euler (0f, 0f, heading * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        Vector3 position = transform.up * movementSpeed * Time.deltaTime;
        transform.position += new Vector3 (position.x, position.y, 0.0f);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other) {
        Vector3 rayLength = transform.up * 0.5f;
        Ray ray = new Ray(transform.position, rayLength);
        //Debug.DrawRay(transform.position, rayLength);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f)) {
            Vector3 reflectedDir = Vector3.Reflect(ray.direction, hit.normal);
            heading = Mathf.Atan2(reflectedDir.x, reflectedDir.y);
        }
    }
}
