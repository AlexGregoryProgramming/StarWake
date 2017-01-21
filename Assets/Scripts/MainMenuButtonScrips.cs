using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScrips : MonoBehaviour {

	public void OneWaveButton()
	{
		GameManager._GAMEMANAGER.wavesSelected = 1;
		GameManager._GAMEMANAGER.wavesLeft = 1;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}

	public void FiveWaveButton()
	{
		GameManager._GAMEMANAGER.wavesSelected = 5;
		GameManager._GAMEMANAGER.wavesLeft = 5;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}	

	public void NineWaveButton()
	{
		GameManager._GAMEMANAGER.wavesSelected = 9;
		GameManager._GAMEMANAGER.wavesLeft = 9;
		GameManager._GAMEMANAGER.setCountdownStart ();
		GameManager._GAMEMANAGER.resetScores ();
		UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
