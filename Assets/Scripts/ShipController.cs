using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float movementSpeed = 1.5f;
    public float rotationSpeed = 3.0f;

	public float lh;
	public float lv;
    private float heading = 0.0f;

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

		if (shipColor.playerNumber == 1)
		{
			lv = -1.0f;
		}

		if (shipColor.playerNumber == 2)
		{
			lh = -1.0f;
		}

		if (shipColor.playerNumber == 3)
		{
			lh = 1.0f;
		}

		if (shipColor.playerNumber == 4)
		{
			lv = 1.0f;
		}
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
		if (GameManager._GAMEMANAGER.gameState == GameManager.GameState.CoinGameMode) 
		{
			if (Time.timeSinceLevelLoad < 8.1) 
			{
				heading = Mathf.Atan2 (-lh, lv);
				Quaternion targetRotation = Quaternion.Euler (0f, 0f, heading * Mathf.Rad2Deg);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
				Vector3 position = transform.up * movementSpeed * Time.deltaTime;
				transform.position += new Vector3 (position.x, position.y, 0.0f);
			}
			if (Time.timeSinceLevelLoad > 8.1) 
			{
				lh = Input.GetAxis (LeftStickHorizontalAxis);
				lv = Input.GetAxis (LeftStickVerticalAxis);
				if ((lh != 0) || (lv != 0)) {
					heading = Mathf.Atan2 (-lh, lv);
				}

				Quaternion targetRotation = Quaternion.Euler (0f, 0f, heading * Mathf.Rad2Deg);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
				Vector3 position = transform.up * movementSpeed * Time.deltaTime;
				transform.position += new Vector3 (position.x, position.y, 0.0f);
			}
		}
    }
}
