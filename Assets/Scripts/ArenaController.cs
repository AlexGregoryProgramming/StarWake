using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArenaController : MonoBehaviour
{
    public bool playerControlledThrust = true;

    public float hoverHeight = 3F;
    public float hoverHeightStrictness = 1F;
    public float forwardThrust = 5000F;
    public float backwardThrust = 2500F;
    public float bankAmount = 0.1F;
    public float bankSpeed = 0.2F;
    public Vector3 bankAxis = new Vector3(-1F, 0F, 0F);
    public float turnSpeed = 8000f;

    public Vector3 forwardDirection = new Vector3(1f, 0f, 0f);

    public float sqrdSpeedThresholdForDrag = 25F;
    public float superDrag = 2F;
    public float fastDrag = 0.5F;
    public float slowDrag = 0.01F;

    // angular drag
    public float sqrdAngularSpeedThresholdForDrag = 5F;
    public float superADrag = 32F;
    public float fastADrag = 16F;
    public float slowADrag = 0.1F;

    new Rigidbody rigidbody;
    float turn = 0f;
    float thrust = 0f;
    float bank = 0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float appliedThrust = thrust;

        if (playerControlledThrust) {
            thrust = Input.GetAxis("Vertical");
        }

        turn = Input.GetAxis("Horizontal") * turnSpeed;

        if (thrust > 0f) {
            appliedThrust *= forwardThrust;
        } else {
            appliedThrust *= backwardThrust;
        }

        rigidbody.AddRelativeTorque(Vector3.up * turn * Time.deltaTime);
        rigidbody.AddRelativeForce(forwardDirection * appliedThrust * Time.deltaTime);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (Mathf.Abs(thrust) > 0.01f) {
            if (rigidbody.velocity.sqrMagnitude > sqrdSpeedThresholdForDrag) {
                rigidbody.drag = fastDrag;
            } else {
                rigidbody.drag = slowDrag;
            }
        } else {
            rigidbody.drag = superDrag;
        }

        if (Mathf.Abs(turn) > 0.01f) {
            if (rigidbody.angularVelocity.sqrMagnitude > sqrdAngularSpeedThresholdForDrag) {
                rigidbody.angularDrag = fastADrag;
            } else {
                rigidbody.angularDrag = slowADrag;
            }
        } else {
            rigidbody.angularDrag = superADrag;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, hoverHeight, transform.position.z), hoverHeightStrictness);

        float amountToBank = rigidbody.angularVelocity.y * bankAmount;
        bank = Mathf.Lerp(bank, amountToBank, bankSpeed);

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation *= Mathf.Deg2Rad;
        rotation.x = 0f;
        rotation.z = 0f;
        rotation += bankAxis * bank;
        rotation *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
