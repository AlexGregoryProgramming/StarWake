using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {
	public int value;
	public float fillTime;
	public int pickUpTier;
	public float collectionForce;
	public float collectionRadius;
	public Image pickUP;

	// Use this for initialization
	void Start()
	{
        GetComponent<Collider>().isTrigger = true;
		pickUP.fillAmount = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		if (pickUP.fillAmount < 1.0f)
		{
			pickUP.fillAmount += 1 / fillTime * Time.deltaTime;
		}
	}

	public void OnCollisionEnter(Collision col)
	{
        CheckContact(col.gameObject);
	}

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        CheckContact(other.gameObject);
    }

    private void CheckContact(GameObject otherGameObject) {
        if (pickUP.fillAmount < 1f) {
            return;
        }

        ShipColor shipColor = otherGameObject.GetComponent<ShipColor>();
		if (shipColor != null)
		{
            string sfxName = string.Format("PointCollect{0}", pickUpTier);
            AudioManager._AUDIOMANAGER.playSound(sfxName);

            ShipGridManager shipGridManager = otherGameObject.GetComponent<ShipGridManager>();
            if (shipGridManager != null) {
                shipGridManager.colorWake.m_VectorGrid.AddGridForce(otherGameObject.transform.position, collectionForce, collectionRadius, shipGridManager.colorWake.m_Color, true);
            }

			GameManager.PlayerColor collectorColor = GameManager._GAMEMANAGER.GetPlayerColor(shipColor.playerNumber);
            GameManager._GAMEMANAGER.ScorePoints(collectorColor, value);

			Destroy(gameObject);
		}
    }
}
