using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float movementSpeed = 1.5f;
    public float rotationSpeed = 3.0f;

    internal float heading = 0.0f;

    private Quaternion targetRotation;
    private float bounceTime;
    private bool bouncing = false;

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

        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider != null) {
            collider.isTrigger = true;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (bouncing && (Time.time - bounceTime) >= 0.25f) {
            bouncing = false;
        }

        if (!bouncing) {
            float lh = Input.GetAxis (LeftStickHorizontalAxis);
            float lv = Input.GetAxis (LeftStickVerticalAxis);
            if ((lh != 0) || (lv != 0)) {
                heading = Mathf.Atan2 (-lh, lv);
            }

        }

        targetRotation = Quaternion.Euler (0f, 0f, heading * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        Vector3 position = transform.up * movementSpeed * Time.deltaTime;
        transform.position += new Vector3 (position.x, position.y, 0.0f);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other) {
        if (!bouncing && other.GetComponent<Wall>() != null) {
            Bounce(other);
        }
    }

    void Bounce(Collider other) {
        float rayLength = 0.75f;
        Vector3 rayDirection = transform.up * rayLength;
        Ray ray = new Ray(transform.position, rayDirection);
//        Debug.DrawRay(transform.position, rayDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength)) {
            Vector3 reflectedDir = Vector3.Reflect(hit.point, hit.normal);
            if ((Mathf.Abs(reflectedDir.x) < 0.1f) || (Mathf.Abs(reflectedDir.y) < 0.1f)) {
//                Debug.Log("Updated from (" + reflectedDir.x + ", " + reflectedDir.y + ")");
                reflectedDir = Vector3.Reflect(hit.point - transform.position, hit.normal);
            }
//            float oldHeading = heading;
            heading = Mathf.Atan2(reflectedDir.x, reflectedDir.y);
            bouncing = true;
            bounceTime = Time.time + 0.25f;
//            Debug.Log(other.gameObject.name + " trigger changed heading changed from " + (oldHeading * Mathf.Rad2Deg) + " to " + (heading * Mathf.Rad2Deg) + " (" + reflectedDir.x + ", " + reflectedDir.y + ")");
        }
    }
}
