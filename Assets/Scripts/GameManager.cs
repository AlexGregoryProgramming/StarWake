﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	private PlayerColor tempColor;
	public static GameManager _GAMEMANAGER = null; 

	public GameObject northSpawnPoint;
	public GameObject eastSpawnPoint;
	public GameObject southSpawnPoint;
	public GameObject westSpawnPoint;

	public GameObject p1ShipPrefab;
	public GameObject p2ShipPrefab;
	public GameObject p3ShipPrefab;
	public GameObject p4ShipPrefab;

	public GameObject p1Ship;
	public GameObject p2Ship;
	public GameObject p3Ship;
	public GameObject p4Ship;

	public GameObject[] spawnPointArray;

	public int p1Wins;
	public int p2Wins;
	public int p3Wins;
	public int p4Wins;
	public bool winnerFound = false;
	//Game info
	public int winsNeeded;

	public enum GameState {MainMenu, CountdownStart, Countdown, CoinGameModeStart, CoinGameMode, EndOfRoundResults, EndOfGameResultsStart, EndOfGameResults}

	//Player color info
	public enum PlayerColor {Red, Blue, Green, Yellow, Dead}
	public PlayerColor p1Color;
	public PlayerColor p2Color;
	public PlayerColor p3Color;
	public PlayerColor p4Color;

	//The color of the points earned

	//Player Score info
	public float p1Score;
	public float p2Score;
	public float p3Score;
	public float p4Score;
	public int incrementalPoints = 12;
	public MatchResults matchResults;
	//Data for drawing the points split
	[System.Serializable]
	public class MatchResults
	{
		public bool p1Match;
		public bool p2Match;
		public bool p3Match;
		public bool p4Match;
		public float dividedPoints;
	}
	public int deathTime = 5;
	public int invulnTime = 2;

	public MatchResults redPointsScored(int pointsScored)
	{

		int scoringPlayers = 0;

		if (p1Color == PlayerColor.Red) 
		{
			scoringPlayers++;
			matchResults.p1Match = true;
		}
		if (p2Color == PlayerColor.Red) 
		{
			scoringPlayers++;
			matchResults.p2Match = true;
		}
		if (p3Color == PlayerColor.Red) 
		{
			scoringPlayers++;
			matchResults.p3Match = true;
		}
		if (p4Color == PlayerColor.Red) 
		{
			scoringPlayers++;
			matchResults.p4Match = true;
		}

		if (p1Color == PlayerColor.Red) 
		{
			p1Score += (pointsScored / scoringPlayers);
		}
		if (p2Color == PlayerColor.Red) 
		{
			p2Score += (pointsScored / scoringPlayers);
		}
		if (p3Color == PlayerColor.Red) 
		{
			p3Score += (pointsScored / scoringPlayers);
		}
		if (p4Color == PlayerColor.Red) 
		{
			p4Score += (pointsScored / scoringPlayers);
		}

		if (scoringPlayers != 0) 
		{
			matchResults.dividedPoints = pointsScored / scoringPlayers;
		}

		return matchResults;
	}

	public MatchResults greenPointsScored(int pointsScored)
	{

		int scoringPlayers = 0;

		if (p1Color == PlayerColor.Green) 
		{
			scoringPlayers++;
			matchResults.p1Match = true;
		}
		if (p2Color == PlayerColor.Green) 
		{
			scoringPlayers++;
			matchResults.p2Match = true;
		}
		if (p3Color == PlayerColor.Green) 
		{
			scoringPlayers++;
			matchResults.p3Match = true;
		}
		if (p4Color == PlayerColor.Green) 
		{
			scoringPlayers++;
			matchResults.p4Match = true;
		}

		if (p1Color == PlayerColor.Green) 
		{
			p1Score += (pointsScored / scoringPlayers);
		}
		if (p2Color == PlayerColor.Green) 
		{
			p2Score += (pointsScored / scoringPlayers);
		}
		if (p3Color == PlayerColor.Green) 
		{
			p3Score += (pointsScored / scoringPlayers);
		}
		if (p4Color == PlayerColor.Green) 
		{
			p4Score += (pointsScored / scoringPlayers);
		}

		if (scoringPlayers != 0) 
		{
			matchResults.dividedPoints = pointsScored / scoringPlayers;
		}
		return matchResults;
	}

	public MatchResults bluePointsScored(int pointsScored)
	{

		int scoringPlayers = 0;

		if (p1Color == PlayerColor.Blue) 
		{
			scoringPlayers++;
			matchResults.p1Match = true;
		}
		if (p2Color == PlayerColor.Blue) 
		{
			scoringPlayers++;
			matchResults.p2Match = true;
		}
		if (p3Color == PlayerColor.Blue) 
		{
			scoringPlayers++;
			matchResults.p3Match = true;
		}
		if (p4Color == PlayerColor.Blue) 
		{
			scoringPlayers++;
			matchResults.p4Match = true;
		}

		if (p1Color == PlayerColor.Blue) 
		{
			p1Score += (pointsScored / scoringPlayers);
		}
		if (p2Color == PlayerColor.Blue) 
		{
			p2Score += (pointsScored / scoringPlayers);
		}
		if (p3Color == PlayerColor.Blue) 
		{
			p3Score += (pointsScored / scoringPlayers);
		}
		if (p4Color == PlayerColor.Blue) 
		{
			p4Score += (pointsScored / scoringPlayers);
		}

		if (scoringPlayers != 0) 
		{
			matchResults.dividedPoints = pointsScored / scoringPlayers;
		}
		return matchResults;
	}


	public MatchResults yellowPointsScored(int pointsScored)
	{

		int scoringPlayers = 0;

		if (p1Color == PlayerColor.Yellow) 
		{
			scoringPlayers++;
			matchResults.p1Match = true;
		}
		if (p2Color == PlayerColor.Yellow) 
		{
			scoringPlayers++;
			matchResults.p2Match = true;
		}
		if (p3Color == PlayerColor.Yellow) 
		{
			scoringPlayers++;
			matchResults.p3Match = true;
		}
		if (p4Color == PlayerColor.Yellow) 
		{
			scoringPlayers++;
			matchResults.p4Match = true;
		}

		if (p1Color == PlayerColor.Yellow) 
		{
			p1Score += (pointsScored / scoringPlayers);
		}
		if (p2Color == PlayerColor.Yellow) 
		{
			p2Score += (pointsScored / scoringPlayers);
		}
		if (p3Color == PlayerColor.Yellow) 
		{
			p3Score += (pointsScored / scoringPlayers);
		}
		if (p4Color == PlayerColor.Yellow) 
		{
			p4Score += (pointsScored / scoringPlayers);
		}

		if (scoringPlayers != 0) 
		{
			matchResults.dividedPoints = pointsScored / scoringPlayers;
		}

		return matchResults;
	}

	public IEnumerator deadPlayerIEnumerator(GameObject deadPlayer, int time)
	{
		if (deadPlayer.GetComponent<ShipColor> ().isInvulnerable == false) 
		{
			deadPlayer.SetActive (false);

			//If player 1 is who died
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 1) {
				tempColor = p1Color;
				p1Color = PlayerColor.Dead;
			}
			//If player 2
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 2) {
				tempColor = p2Color;
				p2Color = PlayerColor.Dead;
			}
			//If player 3
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 3) {
				tempColor = p3Color;
				p3Color = PlayerColor.Dead;
			}
			//If player 4
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 4) {
				tempColor = p4Color;
				p4Color = PlayerColor.Dead;
			}
			//wait the timer
			for (int i = time; i >= 0; i--) {
				//update time left on UI
				yield return new WaitForSeconds (1); 
			}

			//If player 1 is who died
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 1) {
				deadPlayer.SetActive (true);
				deadPlayer.GetComponent<Transform> ().position = northSpawnPoint.GetComponent<Transform> ().position;
				p1Color = tempColor;
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = true;
				for (int i = invulnTime; i > 0; i--) 
				{
					yield return new WaitForSeconds (1); 
				}
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = false;
			}

			//If player 2
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 2) {
				deadPlayer.SetActive (true);
				deadPlayer.GetComponent<Transform> ().position = eastSpawnPoint.GetComponent<Transform> ().position;
				p2Color = tempColor;
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = true;
				for (int i = invulnTime; i > 0; i--) 
				{
					yield return new WaitForSeconds (1); 
				}
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = false;

			}

			//If player 3
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 3) {
				deadPlayer.SetActive (true);
				deadPlayer.GetComponent<Transform> ().position = westSpawnPoint.GetComponent<Transform> ().position;
				p3Color = tempColor;
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = true;
				for (int i = invulnTime; i > 0; i--) 
				{
					yield return new WaitForSeconds (1); 
				}
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = false;
			}

			//If player 4
			if (deadPlayer.GetComponent<ShipColor> ().playerNumber == 4) {
				deadPlayer.SetActive (true);
				deadPlayer.GetComponent<Transform> ().position = southSpawnPoint.GetComponent<Transform> ().position;
				p4Color = tempColor;
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = true;
				for (int i = invulnTime; i > 0; i--) 
				{
					yield return new WaitForSeconds (1); 
				}
				deadPlayer.GetComponent<ShipColor> ().isInvulnerable = false;
			}
			//reactiviate the player and set their color back to what it was.

		}






	}
	//public void testRadius(GameObject testObject)
	//{
		//Collider[] hitColliders = Physics.OverlapSphere(testObject.GetComponent<Transform>();
	//}
	public void KillPlayer(GameObject playerShip)
	{
		StartCoroutine(deadPlayerIEnumerator(playerShip, deathTime));
	}

	public GameState gameState;

	//Countdown stuff
	public Text countDownTextObject;
	public int countdownTimerLength = 5;
	public int countDownTimer;

	//Game time stuff
	public Text gameTimeTextObject;
	public int roundTime = 5;
	public int playTimer;


	public GameObject endRoundButton;

	//Sets the state to countdownStart
	public void setCountdownStart()
	{
		gameState = GameState.CountdownStart;
	}

	//A function to reset the wins of all the players between games
	public void resetScores()
	{
		p1Wins = 0;
		p2Wins = 0;
		p3Wins = 0;
		p4Wins = 0;
	}

	//Reset to a new round after showing round results
	public void endResults()
	{
		gameState = GameState.CountdownStart;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");
	}

	//The big middle screen countdown, also resets the round score
	public IEnumerator CountdownStart(int time)
	{
		northSpawnPoint = GameObject.FindGameObjectWithTag ("northSpawnPoint");
		eastSpawnPoint = GameObject.FindGameObjectWithTag ("eastSpawnPoint");
		southSpawnPoint = GameObject.FindGameObjectWithTag ("southSpawnPoint");
		westSpawnPoint = GameObject.FindGameObjectWithTag ("westSpawnPoint");
		spawnPointArray [0] = GameObject.FindGameObjectWithTag ("northSpawnPoint");
		spawnPointArray [1] = GameObject.FindGameObjectWithTag ("eastSpawnPoint");
		spawnPointArray [2] = GameObject.FindGameObjectWithTag ("southSpawnPoint");
		spawnPointArray [3] = GameObject.FindGameObjectWithTag ("westSpawnPoint");
		p1Score = 0;
		p2Score = 0;
		p3Score = 0;
		p4Score = 0;

		p1Ship = Instantiate (p1ShipPrefab, northSpawnPoint.GetComponent<Transform> ().position, northSpawnPoint.GetComponent<Transform> ().rotation);
		p2Ship = Instantiate (p2ShipPrefab, eastSpawnPoint.GetComponent<Transform> ().position, eastSpawnPoint.GetComponent<Transform> ().rotation);
		p3Ship = Instantiate (p3ShipPrefab, southSpawnPoint.GetComponent<Transform> ().position, southSpawnPoint.GetComponent<Transform> ().rotation);
		p4Ship = Instantiate (p4ShipPrefab, westSpawnPoint.GetComponent<Transform> ().position, westSpawnPoint.GetComponent<Transform> ().rotation);

		p1Ship.GetComponent<VectorGridForce>().m_VectorGrid = GameObject.FindGameObjectWithTag ("VectorGrid").GetComponent<VectorGrid>();
		p2Ship.GetComponent<VectorGridForce>().m_VectorGrid = GameObject.FindGameObjectWithTag ("VectorGrid").GetComponent<VectorGrid>();
		p3Ship.GetComponent<VectorGridForce>().m_VectorGrid = GameObject.FindGameObjectWithTag ("VectorGrid").GetComponent<VectorGrid>();
		p4Ship.GetComponent<VectorGridForce>().m_VectorGrid = GameObject.FindGameObjectWithTag ("VectorGrid").GetComponent<VectorGrid>();

		for (int i = time; i >= 0; i--) 
		{
			countDownTextObject.text = i.ToString();
			print (countDownTimer);
			countDownTimer -= 1;
			yield return new WaitForSeconds (1);

		}
		countDownTextObject.text = "";
		gameState = GameState.CoinGameModeStart;

	}

	//The game timer countdown
	public IEnumerator CoinGameModeStart(int time)
	{
		for(int i = time; i >= 0; i--)
			{
			gameTimeTextObject.text = i.ToString();
			redPointsScored (incrementalPoints);
			bluePointsScored(incrementalPoints);
			greenPointsScored(incrementalPoints);
			yellowPointsScored(incrementalPoints);
			yield return new WaitForSeconds (1); 
			}
		//Temporary Random Player winning:

		if (p1Score > p2Score && p1Score > p3Score && p1Score > p4Score) 
		{
			p1Wins++;
		}

		if (p2Score > p1Score && p2Score > p3Score && p2Score > p4Score) 
		{
			p2Wins++;
		}

		if (p3Score > p2Score && p3Score > p1Score && p3Score > p4Score) 
		{
			p3Wins++;
		}

		if (p4Score > p2Score && p4Score > p3Score && p4Score > p1Score) 
		{
			p4Wins++;
		}
		gameState = GameState.EndOfRoundResults;
	}

	public IEnumerator EndOfGameDelay()
	{
		yield return new WaitForSeconds (1);
		gameState = GameState.EndOfGameResults;
	}

	void Awake()
	{
		//Check if instance already exists
		if (_GAMEMANAGER == null)

			//if not, set instance to this
			_GAMEMANAGER = this;

		//If instance already exists and it's not this:
		else if (_GAMEMANAGER != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	// Use this for initialization
	}


	void Start () 
	{
		gameState = GameState.MainMenu;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameState == GameState.MainMenu) 
		{
			
		}

		if (gameState == GameState.CountdownStart) 
		{
			countDownTextObject = GameObject.FindGameObjectWithTag ("CountdownText").GetComponent<Text>();
			StartCoroutine (CountdownStart (countdownTimerLength));

			gameState = GameState.Countdown;
		}

		if (gameState == GameState.CoinGameModeStart) 
		{
			gameTimeTextObject = GameObject.FindGameObjectWithTag ("GameTimeText").GetComponent<Text>();

			StartCoroutine (CoinGameModeStart (roundTime));

			gameState = GameState.CoinGameMode;
		}

		if (gameState == GameState.CoinGameMode) 
		{
			if (Input.GetKeyDown (KeyCode.Alpha1)) 
			{
				redPointsScored (1200);
				KillPlayer (p1Ship);
			}

			if (Input.GetKeyDown (KeyCode.Alpha2)) 
			{
				greenPointsScored (1200);
				KillPlayer (p2Ship);
			}

			if (Input.GetKeyDown (KeyCode.Alpha3)) 
			{
				bluePointsScored (1200);
				KillPlayer (p3Ship);
			}

			if (Input.GetKeyDown (KeyCode.Alpha4)) 
			{
				yellowPointsScored (1200);
				KillPlayer (p4Ship);
			}
		}

		if (gameState == GameState.EndOfRoundResults) 
		{	
			if (p1Wins == winsNeeded || p2Wins == winsNeeded || p3Wins == winsNeeded || p4Wins == winsNeeded) 
			{
				winnerFound = true;
			}
			gameTimeTextObject.text = "P1: " + p1Wins + " P2: " + p2Wins + " P3: " + p3Wins + " P4: " + p4Wins;
			if (winnerFound == false && Input.GetKeyDown (KeyCode.Space)) 
			{
				endResults ();
			}
			if(winnerFound == true && Input.GetKeyDown (KeyCode.Space)) 
			{
				gameState = GameState.EndOfGameResultsStart;
				StartCoroutine(EndOfGameDelay());
			}
		}

		if (gameState == GameState.EndOfGameResultsStart) 
		{
			
		}

		if (gameState == GameState.EndOfGameResults) 
		{
			if (p1Wins > p2Wins && p1Wins > p3Wins && p1Wins > p4Wins) 
			{
				gameTimeTextObject.text = "Player 1 Wins!";
	
			}

			if (p2Wins > p1Wins && p2Wins > p3Wins && p2Wins > p4Wins) 
			{
				gameTimeTextObject.text = "Player 2 Wins!";
			}

			if (p3Wins > p2Wins && p3Wins > p1Wins && p3Wins > p4Wins) 
			{
				gameTimeTextObject.text = "Player 2 Wins!";
			}

			if (p4Wins > p2Wins && p4Wins > p3Wins && p4Wins > p1Wins) 
			{
				gameTimeTextObject.text = "Player 4 Wins!";
			}

			if(Input.GetKeyDown (KeyCode.Space)) 
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene ("alexTestMainMenu");
			}
		}
	}
}
