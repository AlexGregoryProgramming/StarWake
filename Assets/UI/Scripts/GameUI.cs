using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	public CornerCycleColor[] corners;
	public Text timer;

	//Sequences for cycling
	public Color[] red;
	public Color[] green;
	public Color[] blue;
	public Color[] yellow;
	public float cycleSpeed;

	public IntroCountdown countdown;
	//Images for updating the UI
	public void Awake()
	{
		corners [0].Initialize (yellow, cycleSpeed);
		corners [1].Initialize (red, cycleSpeed);
		corners [2].Initialize (blue, cycleSpeed);
		corners [3].Initialize (green, cycleSpeed);
	}

	public void UpdateColor(int player, GameManager.PlayerColor color)
	{
		Color[] temp = red;
		switch (color) {
		case GameManager.PlayerColor.Red:
			temp = red;
			break;
		case GameManager.PlayerColor.Green:
			temp = green;
			break;
		case GameManager.PlayerColor.Blue:
			temp = blue;
			break;
		case GameManager.PlayerColor.Yellow:
			temp = yellow;
			break;
		}
		corners [player-1].SwitchColor (temp);
	}

	public void SetCurrentLeader(int player)
	{
		for (int i = 0; i < corners.Length; i++) {
			if (i == player - 1) {
				corners [i].EnableParticles ();
			} else {
				corners [i].DisableParticles ();
			}
		}
	}

	public void UpdateScore(int score, int player)
	{
		corners [player - 1].Score (score);
	}

	public void UpdateTimer(string time)
	{
		timer.text = time;
	}
	

}
