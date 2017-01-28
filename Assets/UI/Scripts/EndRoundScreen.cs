using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRoundScreen : MonoBehaviour {

	public Text title;
	public Image AButton;

	public int numWinsRequired = 1;
	public bool[] playersInGame = new bool[4];
	public bool uiStillOnScreen = false;
	public VectorGridForce[] fireWorksArray;

	public EndRoundTrophyRow[] rows;
	bool gotStuff;
	float delay = 0;
	bool gameOver=false;
	bool fireworks = false;
	Color fireworksColor;
	float fireworkDelay = 0;

	public static EndRoundScreen _EndRoundUI = null;

	void Awake()
	{
		AButton.color = new Color (1, 1, 1, 0);
		if (_EndRoundUI != null) {
			Destroy(this);
		} else {
			DontDestroyOnLoad(this);
			_EndRoundUI = this;
		}
		this.gameObject.SetActive (false);
	}

	public void GiveMeInformationYum(int numWins, bool[]players)
	{
		if (gotStuff == false) {
			numWinsRequired = numWins;
			playersInGame = players;
			gotStuff = true;
		}
		foreach (EndRoundTrophyRow row in rows) {
			row.TurnOffTrophiesNotInUse (numWins);
		}
		for (int i = 0; i < playersInGame.Length; i++) {
			if (playersInGame [i] != true) {
				rows [i].gameObject.SetActive (false);
			}
		}

        // TODO: MRB@HV: This is a workaround for the game scene being destroyed/reloaded after the result screen finishes.
        int index = 0;
        foreach (var go in GameObject.Find("PickupSpawnObject").GetComponent<PickupSpawner>().spawnerArray) {
            var vgf = go.GetComponent<VectorGridForce>();
            if (vgf != null) {
                fireWorksArray[index++] = vgf;
            }
        }
	}

	public void Update()
	{
		if (uiStillOnScreen == true) {
			delay += Time.deltaTime;
			if (delay > 1.5f && gameOver == false) {
				AButton.color = new Color (1, 1, 1, 1);
				if (InputManager.IsStartPressed || InputManager.IsSubmitPressed) {
					uiStillOnScreen = false;
					AButton.color = new Color (1, 1, 1, 0);
					this.gameObject.SetActive (false);
					delay = 0;
				}
			} else if (delay > 5.0f && gameOver == true) {
				AButton.color = new Color (1, 1, 1, 1);
				if (InputManager.IsStartPressed || InputManager.IsSubmitPressed) {
					Reset ();
					AButton.color = new Color (1, 1, 1, 0);
					this.gameObject.SetActive (false);
					delay = 0;
				}
			}
		}
		if (fireworks == true) {
			fireworkDelay += Time.deltaTime;
			if (fireworkDelay >= 1f) {
				fireworkDelay = 0;
				int rand = Random.Range (3, fireWorksArray.Length);
				for (int i = 0; i < rand; i++) {
					int arraySpot = Random.Range (0, fireWorksArray.Length);
					fireWorksArray [arraySpot].m_VectorGrid.AddGridForce (fireWorksArray [arraySpot].transform.position, Random.Range(0.025f, 0.175f), Random.Range(0.25f, 1.25f), fireworksColor, true);
				}
			}
		}
	}


	public void RoundComplete(int playerWhoWon)
	{
		this.gameObject.SetActive (true);
		uiStillOnScreen = true;
		delay = 0;
		//1 based
		rows[playerWhoWon-1].AwardATrophy();
		foreach (EndRoundTrophyRow row in rows) {
			if (row.numWins >= numWinsRequired) {
				//Someone won. Do the gameoverthings
				gameOver=true;
				Invoke ("SetWinner", 3.0f);
			}
		}
	}

	public void Reset()
	{
		//Needs to be called when we are returning to the main menu
		Destroy(GameManager._GAMEMANAGER.gameObject);
		_EndRoundUI = null;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTestMainMenu");
		Destroy (this.gameObject);
	}

	public void SetWinner()
	{
		fireworks = true;
		int winner = -1;
		for (int i = 0; i < rows.Length; i++) {
			if (rows [i].numWins >= numWinsRequired) {
				title.text = string.Format("PLAYER {0} WINS!", i+1);
				winner = i;
				fireworksColor = rows [i].trophiesLit [0].og;
			}
		}
		for (int i = 0; i < rows.Length; i++) {
			if (i != winner) {
				rows [i].Winner (rows [winner].trophiesLit [0].og);
			}
		}
	}
}
