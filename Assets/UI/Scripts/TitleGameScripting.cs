﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class roundSelector{
	public Image highlight;
	public Image num;
	public bool selected;
}

public class TitleGameScripting : MonoBehaviour {

	public Image center;
	public Image top;
	public Image bot;
	public Text start;
	public Transform parentForMovement;
	private float accelMovement;
	private float blink;
	public MainMenuStates mystate;

	//Second phase
	public CornerSlide[] corners;
	public GameObject diamond;

	//Third phase
	public GameObject roundSelecter;
	public GameObject tutorial;
	public Image[] tutorialScreens;
	private int currrentTut;

	public enum MainMenuStates{
		titlecenter,
		top,
		bot,
		waitingForStart,
		moveEverythingDown,
		bringinCorners,
		centerDiamond,
		playersAbleToJoin,
		moveEverythingDown2,
		roundNum,
		tutorial
	};


	private int currentSelectedRounds;
	public roundSelector[] rounds;
	bool roundsSelected;

	private float delay;

	public void Awake()
	{
		diamond.SetActive (false);
		foreach (CornerSlide corner in corners) {
			corner.gameObject.SetActive (false);
		}
	}

	public void Update()
	{
		if (mystate == MainMenuStates.titlecenter) {
			center.color = new Color(center.color.r, center.color.g, center.color.b, center.color.a+(Time.deltaTime/3));
			if (center.color.a >= 1) {
				mystate = MainMenuStates.top;
			}
		} else if (mystate == MainMenuStates.top) {
			if (delay <= 0.5f) {
				delay += Time.deltaTime;
			} else {
				top.fillAmount += Time.deltaTime * 2.5f;
				if (top.fillAmount >= 0.99f) {
					top.fillAmount = 1;
					delay = 0;
					mystate = MainMenuStates.bot;
				}
			}
		} else if (mystate == MainMenuStates.bot) {
			if (delay <= 0.5f) {
				delay += Time.deltaTime;
			} else {
				bot.fillAmount += Time.deltaTime * 2.5f;
				if (bot.fillAmount >= 0.99f) {
					bot.fillAmount = 1;
					delay = 0;
					mystate = MainMenuStates.waitingForStart;
				}
			}
		} else if (mystate == MainMenuStates.waitingForStart) {
			if (delay <= 0.5f) {
				delay += Time.deltaTime;
			} else {
				blink += Time.deltaTime;
				if (blink > 1.0f) {
					blink = 0;
					if (start.color.a > 0) {
						Color temp = new Color (1, 1, 1, 0);
						start.color = temp;
					} else {
						Color temp = new Color (1, 1, 1, 1);
						start.color = temp;
					}
				}
			}

			if (InputManager.IsStartPressed)
			{
				AttachAllObjectsToParent();
			}

		} else if (mystate == MainMenuStates.moveEverythingDown) {
			accelMovement += Time.deltaTime*125;
			parentForMovement.localPosition = new Vector3 (parentForMovement.localPosition.x, parentForMovement.localPosition.y - (Time.deltaTime * 50*accelMovement), parentForMovement.localPosition.z);
			if (parentForMovement.localPosition.y <= -1000) {
				mystate = MainMenuStates.bringinCorners;
				delay = 1000;
			}
		} else if (mystate == MainMenuStates.bringinCorners) {
			delay -= Time.deltaTime*1000;
			if (delay <=0) {
				delay = 0;
				mystate = MainMenuStates.playersAbleToJoin;
				diamond.SetActive (true);
				foreach (CornerSlide corner in corners) {
					corner.FadeIn ();
					corner.gameObject.SetActive (true);
				}
			}
		} else if (mystate == MainMenuStates.playersAbleToJoin) {
			//If player one presses A, turn on green sprite upper left. upperLeftCorner.sprite = lit;
			//Player presses start to go to next screen.
			if(Input.GetKeyDown (KeyCode.Joystick1Button0))
			{
				corners [0].Corner ();
				GameManager._GAMEMANAGER.p1Joined = true;
			}

			if(Input.GetKeyDown (KeyCode.Joystick2Button0))
			{
				corners [1].Corner ();
				GameManager._GAMEMANAGER.p2Joined = true;
			}

			if(Input.GetKeyDown (KeyCode.Joystick3Button0))
			{
				corners [2].Corner ();
				GameManager._GAMEMANAGER.p3Joined = true;
			}

			if(Input.GetKeyDown (KeyCode.Joystick4Button0))
			{
				corners [3].Corner ();
				GameManager._GAMEMANAGER.p4Joined = true;
			}



			if(Input.GetKeyDown (KeyCode.Joystick1Button1))
			{
				corners [0].Center ();
				GameManager._GAMEMANAGER.p1Joined = false;
			}

			if(Input.GetKeyDown (KeyCode.Joystick2Button1))
			{
				corners [1].Center ();
				GameManager._GAMEMANAGER.p2Joined = false;
			}

			if(Input.GetKeyDown (KeyCode.Joystick3Button1))
			{
				corners [2].Center ();
				GameManager._GAMEMANAGER.p3Joined = false;
			}

			if(Input.GetKeyDown (KeyCode.Joystick4Button1))
			{
				corners [3].Center ();
				GameManager._GAMEMANAGER.p4Joined = false;
			}

			if (InputManager.IsStartPressed)
			{
				AttachAllObjectsToParentPart2();
			}

			accelMovement = 0;
		} else if (mystate == MainMenuStates.moveEverythingDown2) {
			accelMovement += Time.deltaTime*125;
			parentForMovement.localPosition = new Vector3 (parentForMovement.localPosition.x, parentForMovement.localPosition.y - (Time.deltaTime * 50*accelMovement), parentForMovement.localPosition.z);
			if (parentForMovement.localPosition.y <= -2000) {
				mystate = MainMenuStates.roundNum;
				roundSelecter.SetActive (true);
			}
		} else if (mystate == MainMenuStates.roundNum) {
			if (roundsSelected == false) {
				ActivateRounds ();
			}
			if (Input.GetKeyDown (KeyCode.Joystick1Button2) || Input.GetKeyDown (KeyCode.Joystick2Button2) || Input.GetKeyDown (KeyCode.Joystick3Button2) || Input.GetKeyDown (KeyCode.Joystick4Button2))
			{
				DecreaseRound ();
			}

			if (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Joystick2Button1) || Input.GetKeyDown (KeyCode.Joystick3Button1) || Input.GetKeyDown (KeyCode.Joystick4Button1))
			{
				IncreaseRound ();
			}
			//if they press left, decrease
			//If they press a or start move to next step. int numrounds is the final selection

			if (InputManager.IsStartPressed)
			{
				mystate = MainMenuStates.tutorial;
				currrentTut = 1;
				delay = 0;
			}

			if(Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetKeyDown (KeyCode.Joystick2Button0) || Input.GetKeyDown (KeyCode.Joystick3Button0) || Input.GetKeyDown (KeyCode.Joystick4Button0))
			{
				mystate = MainMenuStates.tutorial;
				currrentTut = 1;
				delay = 0;
			}


		} else if (mystate == MainMenuStates.tutorial) {
			tutorial.SetActive (true);
			//Press a to start match
			if (delay < 1) {
				delay += Time.deltaTime*2;
				if (delay >= 1) {
					delay = 1;
				}
				tutorialScreens [currrentTut - 1].color = new Color (1, 1, 1, delay);
			} else {
				if (Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetKeyDown (KeyCode.Joystick2Button0) || Input.GetKeyDown (KeyCode.Joystick3Button0) || Input.GetKeyDown (KeyCode.Joystick4Button0))
				{
					NextTutorialScreen ();
				}
			}
		}

	}

	public void NextTutorialScreen()
	{
		if (currrentTut == 4) {
			GameManager._GAMEMANAGER.winsNeeded = numRounds ();
			GameManager._GAMEMANAGER.resetScores ();
			GameManager._GAMEMANAGER.setCountdownStart ();
			GameManager._GAMEMANAGER.winnerFound = false;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("AlexTempTest");
		} else {
			currrentTut += 1;
			delay = 0;
		}
	}

	public void AttachAllObjectsToParent()
	{
		center.gameObject.transform.parent = parentForMovement;
		top.gameObject.transform.parent = parentForMovement;
		bot.gameObject.transform.parent = parentForMovement;
		start.gameObject.transform.parent = parentForMovement;
		mystate = MainMenuStates.moveEverythingDown;
	}

	public void AttachAllObjectsToParentPart2()
	{
		diamond.gameObject.transform.parent = parentForMovement;
		mystate = MainMenuStates.moveEverythingDown2;
	}

	public void IncreaseRound()
	{
		currentSelectedRounds +=1;
		if (currentSelectedRounds >2) {
			currentSelectedRounds = 0;
		}
		for (int i = 0; i < rounds.Length; i++) {
			if (i == currentSelectedRounds) {
				rounds [i].selected = true;
				rounds [i].highlight.color = Color.green;
			} else {
				rounds [i].selected = false;
				rounds [i].highlight.color = new Color (0.75f, 0.75f, 0.75f);
			}
		}
	}

	public void DecreaseRound()
	{
		currentSelectedRounds -=1;
		if (currentSelectedRounds < 0) {
			currentSelectedRounds = 2;
		}
		for (int i = 0; i < rounds.Length; i++) {
			if (i == currentSelectedRounds) {
				rounds [i].selected = true;
				rounds [i].highlight.color = Color.green;
			} else {
				rounds [i].selected = false;
				rounds [i].highlight.color = new Color (0.75f, 0.75f, 0.75f);
			}
		}
	}

	public void ActivateRounds()
	{
		roundsSelected = true;
		foreach (roundSelector round in rounds) {
			round.highlight.gameObject.SetActive (true);
			round.highlight.color = new Color (0.75f, 0.75f, 0.75f);
			round.num.gameObject.SetActive(true);
		}
		rounds [0].selected = true;
		rounds [0].highlight.color = Color.green;
		currentSelectedRounds = 0;
	}

	public int numRounds()
	{
		int returnedRounds = 1;
		for (int i = 0; i < rounds.Length; i++) {
			if (i == currentSelectedRounds) {
				returnedRounds= i + 1;
			}
		}
		return returnedRounds = 1;
	}
}
