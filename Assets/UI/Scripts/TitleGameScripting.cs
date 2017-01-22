using System.Collections;
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
	public Sprite lit;
	public Sprite unlit;
	public GameObject upperRight;
	private Vector3 finalPosUpperRight;
	public Image upperRightCorner;
	public GameObject upperLeft;
	private Vector3 finalPosUpperLeft;
	public Image upperLeftCorner;
	public GameObject lowerLeft;
	private Vector3 finalPosLowerLeft;
	public Image lowerLeftCorner;
	public GameObject lowerRight;
	private Vector3 finalPosLowerRight;
	public Image lowerRightCorner;
	public GameObject diamond;
	public GameObject roundSelecter;
	public GameObject tutorial;

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
		finalPosUpperRight = upperRight.transform.localPosition;
		finalPosLowerRight = lowerRight.transform.localPosition;
		finalPosLowerLeft = lowerLeft.transform.localPosition;
		finalPosUpperLeft = upperLeft.transform.localPosition;
		lowerRight.transform.localPosition= new Vector3(finalPosLowerRight.x+1000, finalPosLowerRight.y-1000, finalPosLowerRight.z);
		lowerLeft.transform.localPosition= new Vector3(finalPosLowerLeft.x-1000, finalPosLowerLeft.y-1000, finalPosLowerLeft.z);
		upperLeft.transform.localPosition= new Vector3(finalPosUpperLeft.x-1000, finalPosUpperLeft.y+1000, finalPosUpperLeft.z);
		upperRight.transform.localPosition= new Vector3(finalPosUpperRight.x+1000, finalPosUpperRight.y+1000, finalPosUpperRight.z);
		diamond.SetActive (false);
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
			//IF START BUTTON IS PRESSED
			//CALL ATTACH ALL OBJECTS TO PARENT
			AttachAllObjectsToParent();
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
			}
			lowerRight.transform.localPosition= new Vector3(finalPosLowerRight.x+delay, finalPosLowerRight.y-delay, finalPosLowerRight.z);
			lowerLeft.transform.localPosition= new Vector3(finalPosLowerLeft.x-delay, finalPosLowerLeft.y-delay, finalPosLowerLeft.z);
			upperLeft.transform.localPosition= new Vector3(finalPosUpperLeft.x-delay, finalPosUpperLeft.y+delay, finalPosUpperLeft.z);
			upperRight.transform.localPosition= new Vector3(finalPosUpperRight.x+delay, finalPosUpperRight.y+delay, finalPosUpperRight.z);
			if (delay == 0) {
				diamond.gameObject.SetActive (true);
				mystate = MainMenuStates.playersAbleToJoin;
			}
		} else if (mystate == MainMenuStates.playersAbleToJoin) {
			//If player one presses A, turn on green sprite upper left. upperLeftCorner.sprite = lit;
			//Player presses start to go to next screen.
			AttachAllObjectsToParentPart2();
			accelMovement = 0;
		} else if (mystate == MainMenuStates.moveEverythingDown2) {
			accelMovement += Time.deltaTime*125;
			parentForMovement.localPosition = new Vector3 (parentForMovement.localPosition.x, parentForMovement.localPosition.y - (Time.deltaTime * 50*accelMovement), parentForMovement.localPosition.z);
			if (parentForMovement.localPosition.y <= -2000) {
				mystate = MainMenuStates.roundNum;
			}
		} else if (mystate == MainMenuStates.roundNum) {
			if (roundsSelected == false) {
				ActivateRounds ();
			}
			//If they press right, increase
			//if they press left, decrease
			//If they press a or start move to next step. int numrounds is the final selection
		} else if (mystate == MainMenuStates.tutorial) {
			tutorial.SetActive (true);
			//Press a to start match
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
		upperLeft.gameObject.transform.parent = parentForMovement;
		lowerLeft.gameObject.transform.parent = parentForMovement;
		lowerRight.gameObject.transform.parent = parentForMovement;
		upperRight.gameObject.transform.parent = parentForMovement;
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
