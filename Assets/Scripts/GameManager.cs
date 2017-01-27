using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public const int PlayerCount = 4;

	public float deathExplosionRadius;
	public float deathExplosionForce;

	public VectorGrid gameGrid;

	public static GameManager _GAMEMANAGER = null;

	public GameObject UIObject;

	public GameObject p1ShipPrefab;
	public GameObject p2ShipPrefab;
	public GameObject p3ShipPrefab;
	public GameObject p4ShipPrefab;

	public EndRoundScreen endRoundUI;

	public bool winnerFound = false;
	//Game info
	public int winsNeeded;

	public enum GameState {MainMenu, CountdownStart, Countdown, CoinGameModeStart, CoinGameMode, EndOfRoundResults, EndOfGameResultsStart, EndOfGameResults}

	//Player color info
	public enum PlayerColor {
        Red,
        Blue,
        Green,
        Yellow,
        Dead
    }

	public int incrementalPoints = 12;
	public MatchResults matchResults;

    public class Player {
        public readonly int playerNumber;
        public PlayerColor color;
        public float score;
        public int wins;
        public bool joined;
        public GameObject ship;
        public GameObject spawnPoint;
        public ShipGridManager gridManager;

        public Player(int playerNumber_) {
            playerNumber = playerNumber_;
        }
    };

    Dictionary<int, Player> _players;

	public GameObject pickupSpawner;

	//Data for drawing the points split
	[System.Serializable]
	public class MatchResults
	{
		public float dividedPoints;
	}

	public int deathTime = 5;
	public int invulnTime = 1;
	public IntroCountdown countdown;

    public IEnumerable<Player> Players {
        get {
            return _players.Values;
        }
    }

    public static Color PlayerColorToColor(PlayerColor playerColor) {
        switch (playerColor) {
            case PlayerColor.Red:
                return Color.red;

            case PlayerColor.Blue:
                return Color.blue;

            case PlayerColor.Green:
                return Color.green;

            case PlayerColor.Yellow:
                return Color.yellow;

            default:
                return Color.white;
        }
    }

    public PlayerColor GetPlayerColor(int playerNumber)
    {
        if (playerNumber > 0 && playerNumber <= PlayerCount) {
            return _players[playerNumber].color;
        }

        return PlayerColor.Dead;
    }

    public void SetPlayerColor(int playerNumber, PlayerColor playerColor) {
        if (playerNumber > 0 && playerNumber <= PlayerCount) {
            _players[playerNumber].color = playerColor;
        }
    }

    public void SetPlayerJoined(int playerNumber, bool joined) {
        if (playerNumber > 0 && playerNumber <= PlayerCount) {
            _players[playerNumber].joined = joined;
        }
    }

    public void ScorePoints(PlayerColor color, int points) {
        int scoringPlayers = 0;

        foreach (var player in Players) {
            if (player.color == color) {
                scoringPlayers++;
            }
        }

        foreach (var player in Players) {
            if (player.color == color) {
                player.score += points / scoringPlayers;
                UIObject.GetComponent<GameUI>().UpdateScore((int)player.score, player.playerNumber);
            }
        }

        if (scoringPlayers > 0) {
            matchResults.dividedPoints = points / scoringPlayers;
        }
    }

	public IEnumerator deadPlayerIEnumerator(GameObject deadPlayer, int time)
	{
        ShipColor shipColor = deadPlayer.GetComponent<ShipColor>();
        if ((shipColor != null) && !shipColor.isInvulnerable) {
            AudioManager._AUDIOMANAGER.playSound("Explosion");
            deadPlayer.SetActive(false);

            PlayerColor tempColor = PlayerColor.Dead;
            Player player = _players[shipColor.playerNumber];

            if (player.color != PlayerColor.Dead) {
                tempColor = player.color;
                player.color = PlayerColor.Dead;
                player.gridManager.colorWake.m_VectorGrid.AddGridForce(player.ship.transform.position, deathExplosionForce, deathExplosionRadius, player.gridManager.colorWake.m_Color, true);
                player.gridManager.leftWake.m_VectorGrid.AddGridForce(player.ship.transform.position, deathExplosionForce, deathExplosionRadius, player.gridManager.colorWake.m_Color, true);
                player.gridManager.rightWake.m_VectorGrid.AddGridForce(player.ship.transform.position, deathExplosionForce, deathExplosionRadius, player.gridManager.colorWake.m_Color, true);
            }

            //wait the timer
            for (int i = time; i >= 0; i--) {
                //update time left on UI
                yield return new WaitForSeconds(1);
            }

            if (player.ship != null) {
                deadPlayer.SetActive(true);
                deadPlayer.transform.position = player.spawnPoint.transform.position;
                player.color = tempColor;
                shipColor.isInvulnerable = true;

                Color tempWakeColor = player.gridManager.colorWake.m_Color;
                player.gridManager.colorWake.m_Color = Color.white;

                yield return new WaitForSeconds(invulnTime);

                shipColor.isInvulnerable = false;
                player.gridManager.colorWake.m_Color = tempWakeColor;
            }
        }
	}

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
        foreach (Player player in _players.Values) {
            player.wins = 0;
        }
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
		UIObject = GameObject.FindGameObjectWithTag ("inGameUI");

        _players[1].spawnPoint = GameObject.FindGameObjectWithTag("northSpawnPoint");
        _players[2].spawnPoint = GameObject.FindGameObjectWithTag("eastSpawnPoint");
        _players[3].spawnPoint = GameObject.FindGameObjectWithTag("southSpawnPoint");
        _players[4].spawnPoint = GameObject.FindGameObjectWithTag("westSpawnPoint");

        _players[1].score = _players[2].score = _players[3].score = _players[4].score = 0;

        GameObject[] shipPrefabs = new[] { p1ShipPrefab, p2ShipPrefab, p3ShipPrefab, p4ShipPrefab };

        foreach (Player player in _players.Values) {
            if (player.joined) {
                GameObject prefab = shipPrefabs[player.playerNumber - 1];
                player.ship = Instantiate(prefab, player.spawnPoint.transform.position, player.spawnPoint.transform.rotation);
                player.ship.GetComponent<ShipController>().heading = player.spawnPoint.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
                player.gridManager = player.ship.GetComponent<ShipGridManager>();
            }
        }

		gameGrid = GameObject.FindGameObjectWithTag("VectorGrid").GetComponent<VectorGrid>();

		UIObject.GetComponent<GameUI>().countdown.StartCountdown();
		yield return new WaitForSeconds(8);
		countDownTextObject.text = "";
		gameState = GameState.CoinGameModeStart;
	}

	//The game timer countdown
	public IEnumerator CoinGameModeStart(int time)
	{
		for (int i = time; i >= 0; i--) {
			UIObject.GetComponent<GameUI>().UpdateTimer(i.ToString());

            ScorePoints(PlayerColor.Red, incrementalPoints);
            ScorePoints(PlayerColor.Blue, incrementalPoints);
            ScorePoints(PlayerColor.Green, incrementalPoints);
            ScorePoints(PlayerColor.Yellow, incrementalPoints);

            foreach (Player player in _players.Values) {
			    UIObject.GetComponent<GameUI>().UpdateScore((int)player.score, player.playerNumber);
            }

			yield return new WaitForSeconds(1);
        }

		//Temporary Random Player winning:
        Player highestScoringPlayer = null;
        float highestScore = 0;

        foreach (Player player in _players.Values) {
            if (player.score > highestScore) {
                highestScore = player.score;
                highestScoringPlayer = player;
            }
        }

        if (highestScoringPlayer != null) {
			endRoundUI.RoundComplete(highestScoringPlayer.playerNumber);
            string winText = string.Format("Wave Winner: P{0}", highestScoringPlayer.playerNumber);
			UIObject.GetComponent<GameUI>().UpdateTimer(winText);
        }

		gameState = GameState.EndOfRoundResults;
	}

	public IEnumerator EndOfGameDelay()
	{
		yield return new WaitForSeconds(0);
		gameState = GameState.EndOfGameResults;
	}

	void Awake()
	{
        if (_GAMEMANAGER != null) {
            Destroy(this);
        } else {
            DontDestroyOnLoad(this);
            _GAMEMANAGER = this;
            Initialize();
        }
	}

    void Initialize() {
        _players = new Dictionary<int, Player>(PlayerCount);
        for (int playerNumber = 1; playerNumber <= PlayerCount; ++playerNumber) {
            _players[playerNumber] = new Player(playerNumber);
        }
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
			countDownTextObject = GameObject.FindGameObjectWithTag("CountdownText").GetComponent<Text>();
			StartCoroutine (CountdownStart (countdownTimerLength));

            foreach (Player player in _players.Values) {
                if (player.joined) {
                    player.ship.GetComponent<ShipController>().enabled = false;
                }
            }

			gameState = GameState.Countdown;
		}

		if (gameState == GameState.CoinGameModeStart)
		{
			endRoundUI = GameObject.Find ("_EndRoundUI").GetComponent<EndRoundScreen> ();
			bool[] playersInGame = new bool[4];
			playersInGame [0] = _players [1].joined;
			playersInGame [1] = _players [2].joined;
			playersInGame [2] = _players [3].joined;
			playersInGame [3] = _players [4].joined;
			endRoundUI.GiveMeInformationYum (winsNeeded, playersInGame);

			gameTimeTextObject = GameObject.FindGameObjectWithTag("GameTimeText").GetComponent<Text>();

			StartCoroutine(CoinGameModeStart(roundTime));

			gameState = GameState.CoinGameMode;
		}

		if (gameState == GameState.CoinGameMode)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				KillPlayer(_players[1].ship);
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				KillPlayer(_players[2].ship);
			}

			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				KillPlayer(_players[3].ship);
			}

			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				KillPlayer(_players[4].ship);
			}

			if (Time.timeSinceLevelLoad > 8.1)
			{
                foreach (Player player in _players.Values) {
                    if (player.joined) {
                        player.ship.GetComponent<ShipController>().enabled = true;
                    }
                }
            }
		}

		if (gameState == GameState.EndOfRoundResults)
		{

			if (endRoundUI.uiStillOnScreen == false) {
				endResults ();
			}
		}

		if (gameState == GameState.EndOfGameResultsStart)
		{

		}

		if (gameState == GameState.EndOfGameResults)
		{

			if (InputManager.IsSubmitPressed)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene("resultsScene");

				_players[1].color = PlayerColor.Yellow;
				_players[2].color = PlayerColor.Red;
				_players[3].color = PlayerColor.Blue;
				_players[4].color = PlayerColor.Green;

				gameState = GameState.MainMenu;
			}
		}
	}
}
