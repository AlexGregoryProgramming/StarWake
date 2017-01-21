using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScrips : MonoBehaviour {

	public void OneWinsNeeded()
	{
		GameManager._GAMEMANAGER.winsNeeded = 1;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		GameManager._GAMEMANAGER.winnerFound = false;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}

	public void TwoWinsNeeded()
	{
		GameManager._GAMEMANAGER.winsNeeded = 2;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		GameManager._GAMEMANAGER.winnerFound = false;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}

	public void ThreeWinsNeeded()
	{
		GameManager._GAMEMANAGER.winsNeeded = 3;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		GameManager._GAMEMANAGER.winnerFound = false;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}

	public void FourWinsNeeded()
	{
		GameManager._GAMEMANAGER.winsNeeded = 4;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		GameManager._GAMEMANAGER.winnerFound = false;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
