using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoundScreen : MonoBehaviour {

	public int numWinsRequired = 1;
	public bool[] playersInGame = new bool[4];
	public bool uiStillOnScreen = false;

	public EndRoundTrophyRow[] rows;
	bool gotStuff;

	void Awake()
	{
		this.gameObject.SetActive (false);
		this.gameObject.name = "_EndRoundUI";
	}

	public void GiveMeInformationYum(int numWins, bool[]players)
	{
		if (gotStuff == false) {
			numWinsRequired = numWins;
			playersInGame = players;
			gotStuff = true;
		}
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < playersInGame.Length; i++) {
			if (playersInGame [i] == true) {
				rows [i].gameObject.SetActive (false);
			}
		}
	}

	public void Update()
	{
		if (uiStillOnScreen == true) {
			if (InputManager.IsStartPressed || InputManager.IsSubmitPressed) {
				uiStillOnScreen = false;
			}
		}
	}
	

	public void RoundComplete(int playerWhoWon)
	{
		uiStillOnScreen = true;
		//1 based

	}

	public void Reset()
	{
		//Needs to be called when we are returning to the main menu
		Destroy(GameManager._GAMEMANAGER.gameObject);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTestMainMenu");
		Destroy (this.gameObject);
	}
}
