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

	public ParticleSystem[]orbiterParticles;
	public ParticleSystem wakeParticles;
	public ParticleSystem wakeParticleBurst;
	private bool particlesOn;

	// Use this for initialization
	void Start () 
	{
		if (playerNumber == 1) {
			ParticleColors (Color.yellow);
		} else if (playerNumber == 2) {
			ParticleColors (Color.red);
		} else if (playerNumber == 3) {
			ParticleColors (Color.blue);
		} else if (playerNumber == 4) {
			ParticleColors (Color.green);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (cooldownTimer <= Time.time) {
			EnableParticles ();
		}
		if (GameManager._GAMEMANAGER.gameState == GameManager.GameState.CoinGameMode) {
			if (playerNumber == 1 && cooldownTimer <= Time.time) 
			{
				if (Input.GetKeyDown (KeyCode.Joystick1Button0) && GameManager._GAMEMANAGER.p1Color != GameManager.PlayerColor.Green) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color = Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Green);
					DisableParticles ();
					ParticleColors (Color.green);
					WakeParticles (Color.green);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");

				}
				if (Input.GetKeyDown (KeyCode.Joystick1Button1) && GameManager._GAMEMANAGER.p1Color != GameManager.PlayerColor.Red) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Red);
					DisableParticles ();
					ParticleColors (Color.red);
					WakeParticles(Color.red);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");

				}
				if (Input.GetKeyDown (KeyCode.Joystick1Button2) && GameManager._GAMEMANAGER.p1Color != GameManager.PlayerColor.Blue) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Blue);
					DisableParticles ();
					ParticleColors (Color.blue);
					WakeParticles(Color.blue);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick1Button3) && GameManager._GAMEMANAGER.p1Color != GameManager.PlayerColor.Yellow) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p1Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (1, GameManager.PlayerColor.Yellow);
					DisableParticles ();
					ParticleColors (Color.yellow);
					WakeParticles(Color.yellow);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
			}


			if (playerNumber == 2 && cooldownTimer <= Time.time) 
			{

				if (Input.GetKeyDown (KeyCode.Joystick2Button0) && GameManager._GAMEMANAGER.p2Color != GameManager.PlayerColor.Green) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Green);
					DisableParticles ();
					ParticleColors (Color.green);
					WakeParticles (Color.green);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick2Button1) && GameManager._GAMEMANAGER.p2Color != GameManager.PlayerColor.Red) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Red);
					DisableParticles ();
					ParticleColors (Color.red);
					WakeParticles(Color.red);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick2Button2) && GameManager._GAMEMANAGER.p2Color != GameManager.PlayerColor.Blue) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Blue);
					DisableParticles ();
					ParticleColors (Color.blue);
					WakeParticles(Color.blue);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick2Button3) && GameManager._GAMEMANAGER.p2Color != GameManager.PlayerColor.Yellow) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p2Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (2, GameManager.PlayerColor.Yellow);
					DisableParticles ();
					ParticleColors (Color.yellow);
					WakeParticles(Color.yellow);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
			}


			if (playerNumber == 3 && cooldownTimer <= Time.time) 
			{
				if (Input.GetKeyDown (KeyCode.Joystick3Button0) && GameManager._GAMEMANAGER.p3Color != GameManager.PlayerColor.Green) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Green);
					DisableParticles ();
					ParticleColors (Color.green);
					WakeParticles (Color.green);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick3Button1) && GameManager._GAMEMANAGER.p3Color != GameManager.PlayerColor.Red) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Red);
					DisableParticles ();
					ParticleColors (Color.red);
					WakeParticles(Color.red);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick3Button2)  && GameManager._GAMEMANAGER.p3Color != GameManager.PlayerColor.Blue) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Blue);
					DisableParticles ();
					ParticleColors (Color.blue);
					WakeParticles(Color.blue);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick3Button3) && GameManager._GAMEMANAGER.p3Color != GameManager.PlayerColor.Yellow) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					cooldownTimer = (Time.time + cooldownTimeAmount);
					GameManager._GAMEMANAGER.p3Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (3, GameManager.PlayerColor.Yellow);
					DisableParticles ();
					ParticleColors (Color.yellow);
					WakeParticles(Color.yellow);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
			}


			if (playerNumber == 4 && cooldownTimer <= Time.time) 
			{
				if (Input.GetKeyDown (KeyCode.Joystick4Button0) && GameManager._GAMEMANAGER.p4Color != GameManager.PlayerColor.Green) {
					Prims.GetComponent<MeshRenderer> ().material = GreenPrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Green;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.green;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Green);
					DisableParticles ();
					ParticleColors (Color.green);
					WakeParticles (Color.green);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick4Button1) && GameManager._GAMEMANAGER.p4Color != GameManager.PlayerColor.Red) {
					Prims.GetComponent<MeshRenderer> ().material = RedPrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Red;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.red;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Red);
					DisableParticles ();
					ParticleColors (Color.red);
					WakeParticles(Color.red);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick4Button2) && GameManager._GAMEMANAGER.p4Color != GameManager.PlayerColor.Blue) {
					Prims.GetComponent<MeshRenderer> ().material = BluePrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Blue;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.blue;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Blue);
					DisableParticles ();
					ParticleColors (Color.blue);
					WakeParticles(Color.blue);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
				if (Input.GetKeyDown (KeyCode.Joystick4Button3) && GameManager._GAMEMANAGER.p4Color != GameManager.PlayerColor.Yellow) {
					Prims.GetComponent<MeshRenderer> ().material = YellowPrism;
					GameManager._GAMEMANAGER.p4Color = GameManager.PlayerColor.Yellow;
					this.gameObject.GetComponent<ShipGridManager> ().colorWake.m_Color= Color.yellow;
					GameManager._GAMEMANAGER.UIObject.GetComponent<GameUI> ().UpdateColor (4, GameManager.PlayerColor.Yellow);
					DisableParticles ();
					ParticleColors (Color.yellow);
					WakeParticles(Color.yellow);
					AudioManager._AUDIOMANAGER.playSound ("SwapColor");
				}
			}
		}
	}

	public void ParticleColors(Color allButThisColor)
	{
		var color1 = orbiterParticles[0].main;
		var color2 = orbiterParticles[1].main;
		var color3 = orbiterParticles[2].main;
		if (allButThisColor == Color.green) {
			color1.startColor = Color.red;
			color2.startColor = Color.yellow;
			color3.startColor = Color.blue;
		}else if(allButThisColor == Color.red){
			color1.startColor = Color.green;
			color2.startColor = Color.yellow;
			color3.startColor = Color.blue;
		}else if(allButThisColor == Color.yellow){
			color1.startColor = Color.blue;
			color2.startColor = Color.green;
			color3.startColor = Color.red;
		}else if(allButThisColor == Color.blue){
			color1.startColor = Color.red;
			color2.startColor = Color.green;
			color3.startColor = Color.yellow;
		}
	}

	public void WakeParticles(Color switchToMe)
	{
		var color1 = wakeParticles.main;
		var color2 = wakeParticleBurst.main;
		if (switchToMe == Color.green) {
			color1.startColor = Color.green;
			color2.startColor = Color.green;
			wakeParticleBurst.Emit (100);
		}else if(switchToMe == Color.red){
			color1.startColor = Color.red;
			color2.startColor = Color.red;
			wakeParticleBurst.Emit (100);
		}else if(switchToMe == Color.yellow){
			color1.startColor = Color.yellow;
			color2.startColor = Color.yellow;
			wakeParticleBurst.Emit (100);
		}else if(switchToMe == Color.blue){
			color1.startColor = Color.blue;
			color2.startColor = Color.blue;
			wakeParticleBurst.Emit (100);
		}
	}

	public void EnableParticles()
	{
		if (particlesOn == false) {
			foreach (ParticleSystem temp in orbiterParticles) {
				temp.Play ();
			}
			particlesOn = true;
		}
	}

	public void DisableParticles()
	{
		if (particlesOn == true) {
			foreach (ParticleSystem temp in orbiterParticles) {
				temp.Stop ();
			}
			particlesOn = false;
		}
	}
}
