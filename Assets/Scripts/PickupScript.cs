using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupScript : MonoBehaviour {
	public int value;
	public float fillTime;

	public float collectionForce;
	public float collectionRadius;
	public Image pickUP;

	public GameManager.PlayerColor collectorColor;
	// Use this for initialization
	void Start () 
	{
		pickUP.fillAmount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pickUP.fillAmount != 1.0f) 
		{
			pickUP.fillAmount += 1 / fillTime * Time.deltaTime;
		}


	}

	public void OnCollisionEnter(Collision col)
	{
		print ("A collision");
		if (pickUP.fillAmount == 1 && col.gameObject.GetComponent<ShipColor> () != null) 
		{
			print ("A collision we want");
			int playerNum = col.gameObject.GetComponent<ShipColor> ().playerNumber;
			collectorColor = GameManager._GAMEMANAGER.GetPlayerColor (playerNum);

			col.gameObject.GetComponent<ShipGridManager>().colorWake.m_VectorGrid.AddGridForce (col.gameObject.GetComponent<Transform> ().position, collectionForce, collectionRadius, col.gameObject.GetComponent<ShipGridManager>().colorWake.m_Color, true);
			col.gameObject.GetComponent<ShipGridManager>().leftWake.m_VectorGrid.AddGridForce (col.gameObject.GetComponent<Transform> ().position, collectionForce, collectionRadius, col.gameObject.GetComponent<ShipGridManager>().colorWake.m_Color, true);
			col.gameObject.GetComponent<ShipGridManager>().rightWake.m_VectorGrid.AddGridForce (col.gameObject.GetComponent<Transform> ().position, collectionForce, collectionRadius, col.gameObject.GetComponent<ShipGridManager>().colorWake.m_Color, true);


			if (collectorColor == GameManager.PlayerColor.Blue) 
			{
				GameManager._GAMEMANAGER.bluePointsScored (value);
			}

			if (collectorColor == GameManager.PlayerColor.Green) 
			{
				GameManager._GAMEMANAGER.greenPointsScored (value);
			}

			if (collectorColor == GameManager.PlayerColor.Red) 
			{
				GameManager._GAMEMANAGER.redPointsScored (value);
			}

			if (collectorColor == GameManager.PlayerColor.Yellow) 
			{
				GameManager._GAMEMANAGER.yellowPointsScored (value);
			}

			print (collectorColor);
			Destroy(this.gameObject);
		
		}
	}
}
