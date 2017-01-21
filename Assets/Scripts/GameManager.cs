using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public static GameManager _GAMEMANAGER = null; 

	List<GameObject> spawnPointList = new List<GameObject>();
	public GameObject northSpawnPoint;
	public GameObject westSpawnPoint;
	public GameObject southSpawnPoint;
	public GameObject eastSpawnPoint;

	public int p1Wins;
	public int p2Wins;
	public int p3Wins;
	public int p4Wins;
	public bool winnerFound = false;
	//Game info
	public int winsNeeded;

	public enum GameState {MainMenu, CountdownStart, Countdown, CoinGameModeStart, CoinGameMode, EndOfRoundResults, EndOfGameResults}
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

	public void setCountdownStart()
	{
		gameState = GameState.CountdownStart;
	}

	public void resetScores()
	{
		p1Wins = 0;
		p2Wins = 0;
		p3Wins = 0;
		p4Wins = 0;
	}
	public void endResults()
	{
		gameState = GameState.CountdownStart;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");
	}

	public IEnumerator CountdownStart(int time)
	{

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

	public IEnumerator CoinGameModeStart(int time)
	{
		for(int i = time; i >= 0; i--)
			{
			gameTimeTextObject.text = i.ToString();
			yield return new WaitForSeconds (1); 
			}
		//Temporary Random Player winning:

		int tempWinner = Random.Range (1, 5);

		if (tempWinner == 1) 
		{
			p1Wins++;
		}

		if (tempWinner == 2) 
		{
			p2Wins++;
		}

		if (tempWinner == 3) 
		{
			p3Wins++;
		}

		if (tempWinner == 4) 
		{
			p4Wins++;
		}
		gameState = GameState.EndOfRoundResults;
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
		spawnPointList.Add (northSpawnPoint);
		spawnPointList.Add (westSpawnPoint);
		spawnPointList.Add (southSpawnPoint);
		spawnPointList.Add (eastSpawnPoint);
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
				gameState = GameState.EndOfGameResults;
			}
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
