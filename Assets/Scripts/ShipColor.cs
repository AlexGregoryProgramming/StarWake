using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipColor : MonoBehaviour {
	public int playerNumber;

	public float cooldownTimeAmount = 3.0f;
	public float cooldownTimer = 0.0f;

	public bool isInvulnerable = false;

	public GameObject Prims;

	public Material GreenPrism;
	public Material RedPrism;
	public Material BluePrism;
	public Material YellowPrism;

	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager._GAMEMANAGER.gameState == GameManager.GameState.CoinGameMode) {
			if (playerNumber == 1 && cooldownTimer <= Time.time) 
			{
				if (Input.GetKeyDown (KeyCode.Joystick1Button0)) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Green);

				}
				if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Red);
				}
				if (Input.GetKeyDown (KeyCode.Joystick1Button2)) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Blue);
				}
				if (Input.GetKeyDown (KeyCode.Joystick1Button3)) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Yellow);
				}
			}


			if (playerNumber == 2 && cooldownTimer <= Time.time) 
			{

				if (Input.GetKeyDown (KeyCode.Joystick2Button0)) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Green);
				}
				if (Input.GetKeyDown (KeyCode.Joystick2Button1)) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Red);
				}
				if (Input.GetKeyDown (KeyCode.Joystick2Button2)) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Blue);
				}
				if (Input.GetKeyDown (KeyCode.Joystick2Button3)) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Yellow);
				}
			}


			if (playerNumber == 3 && cooldownTimer <= Time.time) 
			{
				if (Input.GetKeyDown (KeyCode.Joystick3Button0)) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Green);
				}
				if (Input.GetKeyDown (KeyCode.Joystick3Button1)) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Red);
				}
				if (Input.GetKeyDown (KeyCode.Joystick3Button2)) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Blue);
				}
				if (Input.GetKeyDown (KeyCode.Joystick3Button3)) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Yellow);
				}
			}


			if (playerNumber == 4 && cooldownTimer <= Time.time) 
			{
				if (Input.GetKeyDown (KeyCode.Joystick4Button0)) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Green);
				}
				if (Input.GetKeyDown (KeyCode.Joystick4Button1)) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Red);
				}
				if (Input.GetKeyDown (KeyCode.Joystick4Button2)) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Blue);
				}
				if (Input.GetKeyDown (KeyCode.Joystick4Button3)) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<VectorGridForce> ().m_Color = Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Yellow);
				}
			}
		}
	}
}
